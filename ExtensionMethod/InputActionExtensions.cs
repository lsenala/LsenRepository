using R3;
using R3.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

namespace ReactiveInputSystem
{
    //AnyGamepadButtonObservable
    internal sealed class AnyGamepadButtonDown : AnyGamepadButtonObservableBase
    {
        public AnyGamepadButtonDown(Gamepad gamepad, CancellationToken cancellationToken) : base(gamepad, cancellationToken) { }

        protected override bool CheckGamepad(Gamepad gamepad, GamepadButton gamepadButton)
        {
            return gamepad[gamepadButton].wasPressedThisFrame;
        }
    }

    internal sealed class AnyGamepadButton : AnyGamepadButtonObservableBase
    {
        public AnyGamepadButton(Gamepad gamepad, CancellationToken cancellationToken) : base(gamepad, cancellationToken) { }

        protected override bool CheckGamepad(Gamepad gamepad, GamepadButton gamepadButton)
        {
            return gamepad[gamepadButton].isPressed;
        }
    }

    internal sealed class AnyGamepadButtonUp : AnyGamepadButtonObservableBase
    {
        public AnyGamepadButtonUp(Gamepad gamepad, CancellationToken cancellationToken) : base(gamepad, cancellationToken) { }

        protected override bool CheckGamepad(Gamepad gamepad, GamepadButton gamepadButton)
        {
            return gamepad[gamepadButton].wasReleasedThisFrame;
        }
    }
    
    internal abstract class AnyGamepadButtonObservableBase : Observable<GamepadButton>
    {
        public AnyGamepadButtonObservableBase(Gamepad gamepad, CancellationToken cancellationToken)
        {
            this.gamepad = gamepad;
            this.cancellationToken = cancellationToken;
        }

        readonly Gamepad gamepad;
        readonly CancellationToken cancellationToken;

        protected abstract bool CheckGamepad(Gamepad gamepad, GamepadButton gamepadButton);

        protected override IDisposable SubscribeCore(Observer<GamepadButton> observer)
        {
            if (observer.IsDisposed) {
                return Disposable.Empty;
            }

            var runner = new FrameRunnerWorkItem(this, observer, gamepad, cancellationToken);
            InputSystemFrameProvider.AfterUpdate.Register(runner);
            return runner;
        }

        sealed class FrameRunnerWorkItem : CancellableFrameRunnerWorkItemBase<GamepadButton>
        {
            static readonly GamepadButton[] allGamepadButtons = (GamepadButton[])Enum.GetValues(typeof(GamepadButton));
            static readonly List<GamepadButton> buffer = new();

            readonly AnyGamepadButtonObservableBase source;
            readonly Gamepad gamepad;

            public FrameRunnerWorkItem(AnyGamepadButtonObservableBase source, Observer<GamepadButton> observer, Gamepad gamepad, CancellationToken cancellationToken) : base(observer, cancellationToken)
            {
                this.source = source;
                this.gamepad = gamepad;
            }

            protected override bool MoveNextCore(long _)
            {
                buffer.Clear();

                try {
                    var gamepad = this.gamepad ?? Gamepad.current;
                    if (gamepad == null)
                        return true;

                    foreach (var button in allGamepadButtons) {
                        if (source.CheckGamepad(gamepad, button)) {
                            buffer.Add(button);
                        }
                    }
                }
                catch (Exception ex) {
                    PublishOnCompleted(ex);
                    return false;
                }

                foreach (var button in buffer) {
                    PublishOnNext(button);
                }

                return true;
            }
        }
    }
    //
    //AnyKeyObservable
    internal sealed class AnyKeyDown : AnyKeyObservableBase
    {
        public AnyKeyDown(Keyboard keyboard, CancellationToken cancellationToken) : base(keyboard, cancellationToken) { }

        protected override bool CheckKey(Keyboard keyboard, Key key)
        {
            return keyboard[key].wasPressedThisFrame;
        }
    }

    internal sealed class AnyKey : AnyKeyObservableBase
    {
        public AnyKey(Keyboard keyboard, CancellationToken cancellationToken) : base(keyboard, cancellationToken) { }

        protected override bool CheckKey(Keyboard keyboard, Key key)
        {
            return keyboard[key].isPressed;
        }
    }

    internal sealed class AnyKeyUp : AnyKeyObservableBase
    {
        public AnyKeyUp(Keyboard keyboard, CancellationToken cancellationToken) : base(keyboard, cancellationToken) { }

        protected override bool CheckKey(Keyboard keyboard, Key key)
        {
            return keyboard[key].wasReleasedThisFrame;
        }
    }

    internal abstract class AnyKeyObservableBase : Observable<Key>
    {
        public AnyKeyObservableBase(Keyboard keyboard, CancellationToken cancellationToken)
        {
            this.keyboard = keyboard;
            this.cancellationToken = cancellationToken;
        }

        readonly Keyboard keyboard;
        readonly CancellationToken cancellationToken;

        protected abstract bool CheckKey(Keyboard keyboard, Key key);

        protected override IDisposable SubscribeCore(Observer<Key> observer)
        {
            if (observer.IsDisposed) {
                return Disposable.Empty;
            }

            var runner = new FrameRunnerWorkItem(this, observer, keyboard, cancellationToken);
            InputSystemFrameProvider.AfterUpdate.Register(runner);
            return runner;
        }

        sealed class FrameRunnerWorkItem : CancellableFrameRunnerWorkItemBase<Key>
        {
            static readonly Key[] allKeys = (Key[])Enum.GetValues(typeof(Key));
            static readonly List<Key> buffer = new();

            readonly AnyKeyObservableBase source;
            readonly Keyboard keyboard;

            public FrameRunnerWorkItem(AnyKeyObservableBase source, Observer<Key> observer, Keyboard keyboard, CancellationToken cancellationToken) : base(observer, cancellationToken)
            {
                this.source = source;
                this.keyboard = keyboard;
            }

            protected override bool MoveNextCore(long _)
            {
                buffer.Clear();

                try {
                    var keyboard = this.keyboard ?? Keyboard.current;
                    if (keyboard == null)
                        return true;

                    var keyCount = keyboard.allKeys.Count;

                    foreach (var key in allKeys) {
                        var index = (int)key - 1;
                        if (index < 0 || index >= keyCount)
                            continue;

                        if (source.CheckKey(keyboard, key)) {
                            buffer.Add(key);
                        }
                    }
                }
                catch (Exception ex) {
                    PublishOnCompleted(ex);
                    return false;
                }

                foreach (var key in buffer) {
                    PublishOnNext(key);
                }

                return true;
            }
        }
    }
    //
    //AnyMouseButtonObservable
    internal sealed class AnyMouseButtonDown : AnyMouseButtonObservableBase
    {
        public AnyMouseButtonDown(Mouse mouse, CancellationToken cancellationToken) : base(mouse, cancellationToken) { }

        protected override bool CheckMouse(Mouse mouse, MouseButton mouseButton)
        {
            return InputControlHelper.GetMouseButtonControl(mouse, mouseButton).wasPressedThisFrame;
        }
    }

    internal sealed class AnyMouseButton : AnyMouseButtonObservableBase
    {
        public AnyMouseButton(Mouse mouse, CancellationToken cancellationToken) : base(mouse, cancellationToken) { }

        protected override bool CheckMouse(Mouse mouse, MouseButton mouseButton)
        {
            return InputControlHelper.GetMouseButtonControl(mouse, mouseButton).isPressed;
        }
    }

    internal sealed class AnyMouseButtonUp : AnyMouseButtonObservableBase
    {
        public AnyMouseButtonUp(Mouse mouse, CancellationToken cancellationToken) : base(mouse, cancellationToken) { }

        protected override bool CheckMouse(Mouse mouse, MouseButton mouseButton)
        {
            return InputControlHelper.GetMouseButtonControl(mouse, mouseButton).wasReleasedThisFrame;
        }
    }

    internal abstract class AnyMouseButtonObservableBase : Observable<MouseButton>
    {
        public AnyMouseButtonObservableBase(Mouse mouse, CancellationToken cancellationToken)
        {
            this.mouse = mouse;
            this.cancellationToken = cancellationToken;
        }

        readonly Mouse mouse;
        readonly CancellationToken cancellationToken;

        protected abstract bool CheckMouse(Mouse mouse, MouseButton mouseButton);

        protected override IDisposable SubscribeCore(Observer<MouseButton> observer)
        {
            if (observer.IsDisposed) {
                return Disposable.Empty;
            }

            var runner = new FrameRunnerWorkItem(this, observer, mouse, cancellationToken);
            InputSystemFrameProvider.AfterUpdate.Register(runner);
            return runner;
        }

        sealed class FrameRunnerWorkItem : CancellableFrameRunnerWorkItemBase<MouseButton>
        {
            static readonly MouseButton[] allMouseButtons = (MouseButton[])Enum.GetValues(typeof(MouseButton));
            static readonly List<MouseButton> buffer = new();

            readonly AnyMouseButtonObservableBase source;
            readonly Mouse mouse;

            public FrameRunnerWorkItem(AnyMouseButtonObservableBase source, Observer<MouseButton> observer, Mouse mouse, CancellationToken cancellationToken) : base(observer, cancellationToken)
            {
                this.source = source;
                this.mouse = mouse;
            }

            protected override bool MoveNextCore(long _)
            {
                buffer.Clear();

                try {
                    var mouse = this.mouse ?? Mouse.current;
                    if (mouse == null)
                        return true;

                    foreach (var button in allMouseButtons) {
                        if (source.CheckMouse(mouse, button)) {
                            buffer.Add(button);
                        }
                    }
                }
                catch (Exception ex) {
                    PublishOnCompleted(ex);
                    return false;
                }

                foreach (var button in buffer) {
                    PublishOnNext(button);
                }

                return true;
            }
        }
    }
    //
    //CancellableFrameRunnerWorkItemBase
    internal static class CancellationTokenExtensions
    {
        public static CancellationTokenRegistration UnsafeRegister(this CancellationToken cancellationToken, Action<object> callback, object state)
        {
            return cancellationToken.Register(callback, state, useSynchronizationContext: false);
        }
    }
    internal abstract class CancellableFrameRunnerWorkItemBase<T> : IFrameRunnerWorkItem, IDisposable
    {
        readonly Observer<T> observer;
        CancellationTokenRegistration cancellationTokenRegistration;
        bool isDisposed;

        public CancellableFrameRunnerWorkItemBase(Observer<T> observer, CancellationToken cancellationToken)
        {
            this.observer = observer;

            if (cancellationToken.CanBeCanceled) {
                this.cancellationTokenRegistration = cancellationToken.UnsafeRegister(static state => {
                    var s = (CancellableFrameRunnerWorkItemBase<T>)state!;
                    s.observer.OnCompleted();
                    s.Dispose();
                }, this);
            }
        }

        public bool MoveNext(long frameCount)
        {
            if (isDisposed) {
                return false;
            }

            if (observer.IsDisposed) {
                Dispose();
                return false;
            }

            return MoveNextCore(frameCount);
        }

        protected abstract bool MoveNextCore(long frameCount);

        public void Dispose()
        {
            if (!isDisposed) {
                isDisposed = true;
                cancellationTokenRegistration.Dispose();
                DisposeCore();
            }
        }

        protected virtual void DisposeCore() { }

        protected void PublishOnNext(T value)
        {
            observer.OnNext(value);
        }

        protected void PublishOnErrorResume(Exception error)
        {
            observer.OnErrorResume(error);
        }

        protected void PublishOnCompleted(Exception error)
        {
            observer.OnCompleted(error);
            Dispose();
        }

        protected void PublishOnCompleted()
        {
            observer.OnCompleted();
            Dispose();
        }
    }
    //
    //InputControllHelper
    internal static class InputControlHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ButtonControl GetMouseButtonControl(Mouse mouse, MouseButton mouseButton)
        {
            return mouseButton switch {
                MouseButton.Left => mouse.leftButton,
                MouseButton.Right => mouse.rightButton,
                MouseButton.Middle => mouse.middleButton,
                MouseButton.Forward => mouse.forwardButton,
                MouseButton.Back => mouse.backButton,
                _ => null
            };
        }
    }
    //
    internal static class Error
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNullException<T>(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
        }
    }
    public static class InputActionExtensions
    {
        public static Observable<InputAction.CallbackContext> PerformedAsObservable(this InputAction inputAction, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(inputAction);
            return Observable.FromEvent<InputAction.CallbackContext>(
                h => inputAction.performed += h,
                h => inputAction.performed -= h,
                cancellationToken
            );
        }
        public static Observable<InputAction.CallbackContext> CanceledAsObservable(this InputAction inputAction, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(inputAction);
            return Observable.FromEvent<InputAction.CallbackContext>(
                h => inputAction.canceled += h,
                h => inputAction.canceled -= h,
                cancellationToken
            );
        }
        public static Observable<InputAction.CallbackContext> StartedAsObservable(this InputAction inputAction, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(inputAction);
            return Observable.FromEvent<InputAction.CallbackContext>(
                h => inputAction.started += h,
                h => inputAction.started -= h,
                cancellationToken
            );
        }
    }
    public static class InputActionMapExtensions
    {
        public static Observable<InputAction.CallbackContext> OnActionTriggered(this InputActionMap inputActions, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(inputActions);
            return Observable.FromEvent<InputAction.CallbackContext>(
                h => inputActions.actionTriggered += h,
                h => inputActions.actionTriggered -= h,
                cancellationToken
            );
        }
    }
    public static class PlayerInputExtensions
    {
        public static Observable<InputAction.CallbackContext> OnActionTriggeredAsObservable(this UnityEngine.InputSystem.PlayerInput playerInput, CancellationToken cancellationToken = default)
        {
            return Observable.FromEvent<InputAction.CallbackContext>(
                h => playerInput.onActionTriggered += h,
                h => playerInput.onActionTriggered -= h,
                cancellationToken
            );
        }

        public static Observable<UnityEngine.InputSystem.PlayerInput> OnControlsChangedAsObservable(this UnityEngine.InputSystem.PlayerInput playerInput, CancellationToken cancellationToken = default)
        {
            return Observable.FromEvent<UnityEngine.InputSystem.PlayerInput>(
                h => playerInput.onControlsChanged += h,
                h => playerInput.onControlsChanged -= h,
                cancellationToken
            );
        }

        public static Observable<UnityEngine.InputSystem.PlayerInput> OnDeviceLostAsObservable(this UnityEngine.InputSystem.PlayerInput playerInput, CancellationToken cancellationToken = default)
        {
            return Observable.FromEvent<UnityEngine.InputSystem.PlayerInput>(
                h => playerInput.onDeviceLost += h,
                h => playerInput.onDeviceLost -= h,
                cancellationToken
            );
        }

        public static Observable<UnityEngine.InputSystem.PlayerInput> OnDeviceRegainedAsObservable(this UnityEngine.InputSystem.PlayerInput playerInput, CancellationToken cancellationToken = default)
        {
            return Observable.FromEvent<UnityEngine.InputSystem.PlayerInput>(
                h => playerInput.onDeviceRegained += h,
                h => playerInput.onDeviceRegained -= h,
                cancellationToken
            );
        }
    }
    public static class PlayerInputManagerExtensions
    {
        public static Observable<UnityEngine.InputSystem.PlayerInput> OnPlayerJoined(this PlayerInputManager playerInputManager, CancellationToken cancellationToken = default)
        {
            return Observable.FromEvent<UnityEngine.InputSystem.PlayerInput>(
                h => playerInputManager.onPlayerJoined += h,
                h => playerInputManager.onPlayerJoined -= h,
                cancellationToken
            );
        }

        public static Observable<UnityEngine.InputSystem.PlayerInput> OnPlayerLeft(this PlayerInputManager playerInputManager, CancellationToken cancellationToken = default)
        {
            return Observable.FromEvent<UnityEngine.InputSystem.PlayerInput>(
                h => playerInputManager.onPlayerLeft += h,
                h => playerInputManager.onPlayerLeft -= h,
                cancellationToken
            );
        }
    }
    public static class InputControlPathEx
    {
        const string KeyboardLayout = "<Keyboard>";
        const string MouseLayout = "<Mouse>";
        const string GamepadLayout = "<Gamepad>";
        const string ButtonStr = "Button";

        static readonly StringBuilder sharedBuilder = new();

        public static string GetControlPath(Key key)
        {
            sharedBuilder.Clear();
            sharedBuilder.Append(KeyboardLayout)
                .Append('/')
                .Append(key.ToString());
            return sharedBuilder.ToString();
        }

        public static string GetControlPath(MouseButton mouseButton)
        {
            sharedBuilder.Clear();
            sharedBuilder.Append(MouseLayout)
                .Append('/')
                .Append(mouseButton.ToString())
                .Append(ButtonStr);
            return sharedBuilder.ToString();
        }

        public static string GetControlPath(GamepadButton gamepadButton)
        {
            static string EnumToString(GamepadButton gamepadButton)
            {
                return gamepadButton switch {
                    GamepadButton.West => GamepadButton.West.ToString(),
                    GamepadButton.North => GamepadButton.North.ToString(),
                    GamepadButton.South => GamepadButton.South.ToString(),
                    GamepadButton.East => GamepadButton.East.ToString(),
                    GamepadButton.DpadUp => "dpad/up",
                    GamepadButton.DpadDown => "dpad/down",
                    GamepadButton.DpadLeft => "dpad/left",
                    GamepadButton.DpadRight => "dpad/right",
                    _ => gamepadButton.ToString()
                };
            }

            sharedBuilder.Clear();
            sharedBuilder.Append(GamepadLayout)
                .Append('/')
                .Append(EnumToString(gamepadButton));
            return sharedBuilder.ToString();
        }
    }
    //InputRx.Events
    public static partial class InputRx
    {
        public static Observable<InputControl> OnAnyButtonPress()
        {
            return InputSystem.onAnyButtonPress.ToObservable();
        }

        public static Observable<InputEventPtr> OnEvent()
        {
            return InputSystem.onEvent.ToObservable();
        }

        public static Observable<R3.Unit> OnBeforeUpdate(CancellationToken cancellationToken = default)
        {
            return Observable.EveryUpdate(InputSystemFrameProvider.BeforeUpdate, cancellationToken);
        }

        public static Observable<R3.Unit> OnAfterUpdate(CancellationToken cancellationToken = default)
        {
            return Observable.EveryUpdate(InputSystemFrameProvider.AfterUpdate, cancellationToken);
        }

        public static Observable<(object, InputActionChange)> OnActionChange(CancellationToken cancellationToken = default)
        {
            return Observable.FromEvent<Action<object, InputActionChange>, (object, InputActionChange)>(
                h => (x, y) => h((x, y)),
                h => InputSystem.onActionChange += h,
                h => InputSystem.onActionChange -= h,
                cancellationToken
            );
        }

        public static Observable<(InputDevice, InputDeviceChange)> OnDeviceChange(CancellationToken cancellationToken = default)
        {
            return Observable.FromEvent<Action<InputDevice, InputDeviceChange>, (InputDevice, InputDeviceChange)>(
                h => (x, y) => h((x, y)),
                h => InputSystem.onDeviceChange += h,
                h => InputSystem.onDeviceChange -= h,
                cancellationToken
            );
        }
    }
    //InputRx.Gamepad
    public static partial class InputRx
    {
        public static Observable<GamepadButton> OnAnyGamepadButtonDown(Gamepad gamepad, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(gamepad);
            return new AnyGamepadButtonDown(gamepad, cancellationToken);
        }

        public static Observable<GamepadButton> OnAnyGamepadButtonDown(CancellationToken cancellationToken = default)
        {
            return new AnyGamepadButtonDown(null, cancellationToken);
        }

        public static Observable<GamepadButton> OnAnyGamepadButton(Gamepad gamepad, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(gamepad);
            return new AnyGamepadButton(gamepad, cancellationToken);
        }

        public static Observable<GamepadButton> OnAnyGamepadButton(CancellationToken cancellationToken = default)
        {
            return new AnyGamepadButton(null, cancellationToken);
        }

        public static Observable<GamepadButton> OnAnyGamepadButtonUp(Gamepad gamepad, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(gamepad);
            return new AnyGamepadButtonUp(gamepad, cancellationToken);
        }

        public static Observable<GamepadButton> OnAnyGamepadButtonUp(CancellationToken cancellationToken = default)
        {
            return new AnyGamepadButton(null, cancellationToken);
        }

        public static Observable<R3.Unit> OnGamepadButtonDown(GamepadButton gamepadButton, CancellationToken cancellationToken = default)
        {
            return OnAfterUpdate(cancellationToken)
                .Where(_ => Gamepad.current != null && Gamepad.current[gamepadButton].wasPressedThisFrame);
        }

        public static Observable<R3.Unit> OnGamepadButtonDown(Gamepad gamepad, GamepadButton gamepadButton, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(gamepad);

            return OnAfterUpdate(cancellationToken)
                .Where(gamepad, (_, gamepad) => gamepad[gamepadButton].wasPressedThisFrame);
        }

        public static Observable<R3.Unit> OnGamepadButton(GamepadButton gamepadButton, CancellationToken cancellationToken = default)
        {
            return OnAfterUpdate(cancellationToken)
                .Where(_ => Gamepad.current != null && Gamepad.current[gamepadButton].isPressed);
        }

        public static Observable<R3.Unit> OnGamepadButton(Gamepad gamepad, GamepadButton gamepadButton, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(gamepad);

            return OnAfterUpdate(cancellationToken)
                .Where(gamepad, (_, gamepad) => gamepad[gamepadButton].isPressed);
        }

        public static Observable<R3.Unit> OnGamepadButtonUp(GamepadButton gamepadButton, CancellationToken cancellationToken = default)
        {
            return OnAfterUpdate(cancellationToken)
                .Where(_ => Gamepad.current != null && Gamepad.current[gamepadButton].wasReleasedThisFrame);
        }

        public static Observable<R3.Unit> OnGamepadButtonUp(Gamepad gamepad, GamepadButton gamepadButton, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(gamepad);

            return OnAfterUpdate(cancellationToken)
                .Where(gamepad, (_, gamepad) => gamepad[gamepadButton].wasReleasedThisFrame);
        }

        public static Observable<UnityEngine.Vector2> OnGamepadLeftStickChanged(CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged(
                staticObject,
                _ => Gamepad.current == null ? default : Gamepad.current.leftStick.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<UnityEngine.Vector2> OnGamepadLeftStickChanged(Gamepad gamepad, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(gamepad);

            return Observable.EveryValueChanged(
                gamepad,
                gamepad => gamepad.leftStick.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<UnityEngine.Vector2> OnGamepadRightStickChanged(CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged(
                staticObject,
                _ => Gamepad.current == null ? default : Gamepad.current.rightStick.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<UnityEngine.Vector2> OnGamepadRightStickChanged(Gamepad gamepad, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(gamepad);

            return Observable.EveryValueChanged(
                gamepad,
                gamepad => gamepad.rightStick.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<float> OnGamepadLeftTriggerChanged(CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged(
                staticObject,
                _ => Gamepad.current == null ? default : Gamepad.current.leftTrigger.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<float> OnGamepadLeftTriggerChanged(Gamepad gamepad, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(gamepad);

            return Observable.EveryValueChanged(
                gamepad,
                gamepad => gamepad.leftTrigger.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<float> OnGamepadRightTriggerChanged(CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged(
                staticObject,
                _ => Gamepad.current == null ? default : Gamepad.current.rightTrigger.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<float> OnGamepadRightTriggerChanged(Gamepad gamepad, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(gamepad);

            return Observable.EveryValueChanged(
                gamepad,
                gamepad => gamepad.rightTrigger.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<UnityEngine.Vector2> OnGamepadDpadChanged(CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged(
                staticObject,
                _ => Gamepad.current == null ? default : Gamepad.current.dpad.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<UnityEngine.Vector2> OnGamepadDpadChanged(Gamepad gamepad, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(gamepad);

            return Observable.EveryValueChanged(
                gamepad,
                gamepad => gamepad.dpad.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

    }
    //InputRx.Joystick
    public static partial class InputRx
    {
        public static Observable<Vector2> OnJoystickStickChanged(CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged(
                staticObject,
                _ => Joystick.current == null ? default : Joystick.current.stick.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<Vector2> OnJoystickStickChanged(Joystick joystick, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(joystick);

            return Observable.EveryValueChanged(
                joystick,
                joystick => joystick.stick.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<float> OnJoystickTriggerChanged(CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged(
                staticObject,
                _ => Joystick.current == null ? default : Joystick.current.trigger.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<float> OnJoystickTriggerChanged(Joystick joystick, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(joystick);

            return Observable.EveryValueChanged(
                joystick,
                joystick => joystick.trigger.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }
    }
    //InputRx.Keyboard
    public static partial class InputRx
    {
        public static Observable<char> OnTextInput(Keyboard keyboard, CancellationToken cancellationToken = default)
        {
            return Observable.FromEvent<char>(
                h => keyboard.onTextInput += h,
                h => keyboard.onTextInput -= h,
                cancellationToken
            );
        }

        public static Observable<char> OnTextInput(CancellationToken cancellationToken = default)
        {
            return Observable.FromEvent<char>(
                h => Keyboard.current.onTextInput += h,
                h => Keyboard.current.onTextInput -= h,
                cancellationToken
            );
        }

        public static Observable<IMECompositionString> OnIMECompositionChange(Keyboard keyboard, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(keyboard);

            return Observable.FromEvent<IMECompositionString>(
                h => keyboard.onIMECompositionChange += h,
                h => keyboard.onIMECompositionChange -= h,
                cancellationToken
            );
        }

        public static Observable<IMECompositionString> OnIMECompositionChange(CancellationToken cancellationToken = default)
        {
            return Observable.FromEvent<IMECompositionString>(
                h => Keyboard.current.onIMECompositionChange += h,
                h => Keyboard.current.onIMECompositionChange -= h,
                cancellationToken
            );
        }

        public static Observable<Key> OnAnyKeyDown(Keyboard keyboard, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(keyboard);
            return new AnyKeyDown(keyboard, cancellationToken);
        }

        public static Observable<Key> OnAnyKeyDown(CancellationToken cancellationToken = default)
        {
            return new AnyKeyDown(null, cancellationToken);
        }

        public static Observable<Key> OnAnyKey(Keyboard keyboard, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(keyboard);
            return new AnyKey(keyboard, cancellationToken);
        }

        public static Observable<Key> OnAnyKey(CancellationToken cancellationToken = default)
        {
            return new AnyKey(null, cancellationToken);
        }


        public static Observable<Key> OnAnyKeyUp(Keyboard keyboard, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(keyboard);
            return new AnyKeyUp(keyboard, cancellationToken);
        }

        public static Observable<Key> OnAnyKeyUp(CancellationToken cancellationToken = default)
        {
            return new AnyKeyUp(null, cancellationToken);
        }

        public static Observable<R3.Unit> OnKeyDown(Keyboard keyboard, Key key, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(keyboard);

            return OnAfterUpdate(cancellationToken)
                .Where((keyboard, key), (_, state) => state.keyboard[state.key].wasPressedThisFrame);
        }

        public static Observable<R3.Unit> OnKeyDown(Key key, CancellationToken cancellationToken = default)
        {
            return OnAfterUpdate(cancellationToken)
                .Where(key, (_, key) => Keyboard.current != null && Keyboard.current[key].wasPressedThisFrame);
        }

        public static Observable<R3.Unit> OnKey(Keyboard keyboard, Key key, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(keyboard);

            return OnAfterUpdate(cancellationToken)
                .Where((keyboard, key), (_, state) => state.keyboard[state.key].isPressed);
        }

        public static Observable<R3.Unit> OnKey(Key key, CancellationToken cancellationToken = default)
        {
            return OnAfterUpdate(cancellationToken)
                .Where(key, (_, key) => Keyboard.current != null && Keyboard.current[key].isPressed);
        }

        public static Observable<R3.Unit> OnKeyUp(Keyboard keyboard, Key key, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(keyboard);

            return OnAfterUpdate(cancellationToken)
                .Where((keyboard, key), (_, state) => state.keyboard[state.key].wasReleasedThisFrame);
        }

        public static Observable<R3.Unit> OnKeyUp(Key key, CancellationToken cancellationToken = default)
        {
            return OnAfterUpdate(cancellationToken)
                .Where(key, (_, key) => Keyboard.current != null && Keyboard.current[key].wasReleasedThisFrame);
        }
    }
    //InputRx.Mouse
    public static partial class InputRx
    {
        static readonly object staticObject = new();

        const int MouseButtonCount = 5;

        public static Observable<MouseButton> OnAnyMouseButtonDown(Mouse mouse, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(mouse);
            return new AnyMouseButtonDown(mouse, cancellationToken);
        }

        public static Observable<MouseButton> OnAnyMouseButtonDown(CancellationToken cancellationToken = default)
        {
            return new AnyMouseButtonDown(null, cancellationToken);
        }

        public static Observable<MouseButton> OnAnyMouseButton(Mouse mouse, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(mouse);
            return new AnyMouseButton(mouse, cancellationToken);
        }

        public static Observable<MouseButton> OnAnyMouseButton(CancellationToken cancellationToken = default)
        {
            return new AnyMouseButton(null, cancellationToken);
        }

        public static Observable<MouseButton> OnAnyMouseButtonUp(Mouse mouse, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(mouse);
            return new AnyMouseButtonUp(mouse, cancellationToken);
        }

        public static Observable<MouseButton> OnAnyMouseButtonUp(CancellationToken cancellationToken = default)
        {
            return new AnyMouseButtonDown(null, cancellationToken);
        }

        public static Observable<R3.Unit> OnMouseButtonDown(Mouse mouse, MouseButton mouseButton, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(mouse);

            return OnAfterUpdate(cancellationToken)
                .Where(mouse, (_, mouse) => InputControlHelper.GetMouseButtonControl(mouse, mouseButton).wasPressedThisFrame);
        }

        public static Observable<R3.Unit> OnMouseButtonDown(MouseButton mouseButton, CancellationToken cancellationToken = default)
        {
            return OnAfterUpdate(cancellationToken)
                .Where(_ => Mouse.current != null)
                .Where(_ => InputControlHelper.GetMouseButtonControl(Mouse.current, mouseButton).wasPressedThisFrame);
        }

        public static Observable<R3.Unit> OnMouseButton(Mouse mouse, MouseButton mouseButton, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(mouse);

            return OnAfterUpdate(cancellationToken)
                .Where(mouse, (_, mouse) => InputControlHelper.GetMouseButtonControl(mouse, mouseButton).isPressed);
        }

        public static Observable<R3.Unit> OnMouseButton(MouseButton mouseButton, CancellationToken cancellationToken = default)
        {
            return OnAfterUpdate(cancellationToken)
                .Where(_ => Mouse.current != null)
                .Where(_ => InputControlHelper.GetMouseButtonControl(Mouse.current, mouseButton).isPressed);
        }

        public static Observable<R3.Unit> OnMouseButtonUp(Mouse mouse, MouseButton mouseButton, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(mouse);

            return OnAfterUpdate(cancellationToken)
                .Where(mouse, (_, mouse) => InputControlHelper.GetMouseButtonControl(mouse, mouseButton).wasReleasedThisFrame);
        }

        public static Observable<R3.Unit> OnMouseButtonUp(MouseButton mouseButton, CancellationToken cancellationToken = default)
        {
            return OnAfterUpdate(cancellationToken)
                .Where(_ => Mouse.current != null)
                .Where(_ => InputControlHelper.GetMouseButtonControl(Mouse.current, mouseButton).wasReleasedThisFrame);
        }

        public static Observable<Vector2> OnMousePositionChanged(Mouse mouse, CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged(mouse, mouse => mouse.position.value, InputSystemFrameProvider.AfterUpdate, cancellationToken);
        }

        public static Observable<Vector2> OnMousePositionChanged(CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged(
                staticObject,
                _ => Mouse.current == null ? default : Mouse.current.position.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<Vector2> OnMouseDeltaChanged(Mouse mouse, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(mouse);

            return Observable.EveryValueChanged(mouse, mouse => mouse.delta.value, InputSystemFrameProvider.AfterUpdate, cancellationToken);
        }

        public static Observable<Vector2> OnMouseDeltaChanged(CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged(
                staticObject,
                _ => Mouse.current == null ? default : Mouse.current.delta.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<Vector2> OnMouseScrollChanged(Mouse mouse, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(mouse);

            return Observable.EveryValueChanged(mouse, mouse => mouse.scroll.value, InputSystemFrameProvider.AfterUpdate, cancellationToken);
        }

        public static Observable<Vector2> OnMouseScrollChanged(CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged(
                staticObject,
                _ => Mouse.current == null ? default : Mouse.current.scroll.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }
    }
    //InputRx.Potinter
    public static partial class InputRx
    {
        public static Observable<R3.Unit> OnPointerDown(Pointer pointer, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(pointer);

            return OnAfterUpdate(cancellationToken)
                .Where(pointer, (_, pointer) => pointer.press.wasPressedThisFrame);
        }

        public static Observable<R3.Unit> OnPointerDown(CancellationToken cancellationToken = default)
        {
            return OnAfterUpdate(cancellationToken)
                .Where(_ => Pointer.current != null && Pointer.current.press.wasPressedThisFrame);
        }

        public static Observable<R3.Unit> OnPointer(Pointer pointer, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(pointer);

            return OnAfterUpdate(cancellationToken)
                .Where(pointer, (_, pointer) => pointer.press.isPressed);
        }

        public static Observable<R3.Unit> OnPointer(CancellationToken cancellationToken = default)
        {
            return OnAfterUpdate(cancellationToken)
                .Where(_ => Pointer.current != null && Pointer.current.press.isPressed);
        }

        public static Observable<R3.Unit> OnPointerUp(Pointer pointer, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(pointer);

            return OnAfterUpdate(cancellationToken)
                .Where(pointer, (_, pointer) => pointer.press.wasReleasedThisFrame);
        }

        public static Observable<R3.Unit> OnPointerUp(CancellationToken cancellationToken = default)
        {
            return OnAfterUpdate(cancellationToken)
                .Where(_ => Pointer.current != null && Pointer.current.press.wasReleasedThisFrame);
        }

        public static Observable<Vector2> OnPointerPositionChanged(Pointer pointer, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(pointer);

            return Observable.EveryValueChanged(pointer, pointer => pointer.position.value, InputSystemFrameProvider.AfterUpdate, cancellationToken);
        }

        public static Observable<Vector2> OnPointerPositionChanged(CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged(
                staticObject,
                _ => Pointer.current == null ? default : Pointer.current.position.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<Vector2> OnPointerDeltaChanged(Pointer pointer, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(pointer);

            return Observable.EveryValueChanged(pointer, pointer => pointer.delta.value, InputSystemFrameProvider.AfterUpdate, cancellationToken);
        }

        public static Observable<Vector2> OnPointerDeltaChanged(CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged(
                staticObject,
                _ => Pointer.current == null ? default : Pointer.current.delta.value,
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }
    }
    //InputRx.Touch
    public static partial class InputRx
    {
        public static Observable<R3.Unit> OnTouchDown(int touchId, CancellationToken cancellationToken = default)
        {
            return OnAfterUpdate(cancellationToken)
                .Where(touchId, (_, touchId) => Touchscreen.current != null &&
                    Touchscreen.current.touches.Count > touchId &&
                    Touchscreen.current.touches[touchId].press.wasPressedThisFrame
                );
        }

        public static Observable<R3.Unit> OnTouchDown(Touchscreen touchscreen, int touchId, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(touchscreen);

            return OnAfterUpdate(cancellationToken)
                .Where((touchscreen, touchId), (_, state) =>
                    state.touchscreen.touches.Count > state.touchId &&
                    state.touchscreen.touches[state.touchId].press.wasPressedThisFrame
                );
        }

        public static Observable<R3.Unit> OnTouch(int touchId, CancellationToken cancellationToken = default)
        {
            return OnAfterUpdate(cancellationToken)
                .Where(touchId, (_, touchId) => Touchscreen.current != null &&
                    Touchscreen.current.touches.Count > touchId &&
                    Touchscreen.current.touches[touchId].press.isPressed
                );
        }

        public static Observable<R3.Unit> OnTouch(Touchscreen touchscreen, int touchId, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(touchscreen);

            return OnAfterUpdate(cancellationToken)
                .Where((touchscreen, touchId), (_, state) =>
                    state.touchscreen.touches.Count > state.touchId &&
                    state.touchscreen.touches[state.touchId].press.isPressed
                );
        }

        public static Observable<R3.Unit> OnTouchUp(int touchId, CancellationToken cancellationToken = default)
        {
            return OnAfterUpdate(cancellationToken)
                .Where(touchId, (_, touchId) => Touchscreen.current != null &&
                    Touchscreen.current.touches.Count > touchId &&
                    Touchscreen.current.touches[touchId].press.wasReleasedThisFrame
                );
        }

        public static Observable<R3.Unit> OnTouchUp(Touchscreen touchscreen, int touchId, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(touchscreen);

            return OnAfterUpdate(cancellationToken)
                .Where((touchscreen, touchId), (_, state) =>
                    state.touchscreen.touches.Count > state.touchId &&
                    state.touchscreen.touches[state.touchId].press.wasReleasedThisFrame
                );
        }

        public static Observable<UnityEngine.InputSystem.TouchPhase> OnTouchPhaseChanged(int touchId, CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged<object, UnityEngine.InputSystem.TouchPhase>(null,
                _ => {
                    if (Touchscreen.current == null || Touchscreen.current.touches.Count <= touchId)
                        return default;
                    return Touchscreen.current.touches[touchId].phase.value;
                },
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<UnityEngine.InputSystem.TouchPhase> OnTouchPhaseChanged(Touchscreen touchscreen, int touchId, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(touchscreen);

            return Observable.EveryValueChanged(touchscreen,
                touchscreen => {
                    if (touchscreen.touches.Count <= touchId)
                        return default;
                    return touchscreen.touches[touchId].phase.value;
                },
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<Vector2> OnTouchPositionChanged(int touchId, CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged<object, Vector2>(null,
                _ => {
                    if (Touchscreen.current == null || Touchscreen.current.touches.Count <= touchId)
                        return default;
                    return Touchscreen.current.touches[touchId].position.value;
                },
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<Vector2> OnTouchPositionChanged(Touchscreen touchscreen, int touchId, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(touchscreen);

            return Observable.EveryValueChanged(touchscreen,
                touchscreen => {
                    if (touchscreen.touches.Count <= touchId)
                        return default;
                    return touchscreen.touches[touchId].position.value;
                },
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<Vector2> OnTouchDeltaChanged(int touchId, CancellationToken cancellationToken = default)
        {
            return Observable.EveryValueChanged<object, Vector2>(null,
                _ => {
                    if (Touchscreen.current == null || Touchscreen.current.touches.Count <= touchId)
                        return default;
                    return Touchscreen.current.touches[touchId].delta.value;
                },
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }

        public static Observable<Vector2> OnTouchDeltaChanged(Touchscreen touchscreen, int touchId, CancellationToken cancellationToken = default)
        {
            Error.ArgumentNullException(touchscreen);

            return Observable.EveryValueChanged(touchscreen,
                touchscreen => {
                    if (touchscreen.touches.Count <= touchId)
                        return default;
                    return touchscreen.touches[touchId].delta.value;
                },
                InputSystemFrameProvider.AfterUpdate,
                cancellationToken
            );
        }
    }
    //InputRx.User
    public static partial class InputRx
    {
        public static Observable<(InputUser, InputUserChange, InputDevice)> OnUserChange(CancellationToken cancellationToken = default)
        {
            return Observable.FromEvent<Action<InputUser, InputUserChange, InputDevice>, (InputUser, InputUserChange, InputDevice)>(
                h => (x, y, z) => h((x, y, z)),
                h => InputUser.onChange += h,
                h => InputUser.onChange -= h,
                cancellationToken
            );
        }

        public static Observable<(InputControl, InputEventPtr)> OnUnpairedDeviceUsed(CancellationToken cancellationToken = default)
        {
            return Observable.FromEvent<Action<InputControl, InputEventPtr>, (InputControl, InputEventPtr)>(
                h => (x, y) => h((x, y)),
                h => InputUser.onUnpairedDeviceUsed += h,
                h => InputUser.onUnpairedDeviceUsed -= h,
                cancellationToken
            );
        }
    }
    public sealed class InputSystemFrameProvider : FrameProvider
    {
        public static readonly FrameProvider BeforeUpdate = new InputSystemFrameProvider();
        public static readonly FrameProvider AfterUpdate = new InputSystemFrameProvider();

        FreeListCore<IFrameRunnerWorkItem> list;
        long frameCount;
        readonly object gate = new();

        InputSystemFrameProvider()
        {
            list = new FreeListCore<IFrameRunnerWorkItem>(gate);
        }

        internal void OnUpdate()
        {
            var span = list.AsSpan();
            for (int i = 0; i < span.Length; i++) {
                ref readonly var item = ref span[i];
                if (item != null) {
                    try {
                        if (!item.MoveNext(frameCount)) {
                            list.Remove(i);
                        }
                    }
                    catch (Exception ex) {
                        list.Remove(i);
                        try {
                            ObservableSystem.GetUnhandledExceptionHandler().Invoke(ex);
                        }
                        catch { }
                    }
                }
            }

            frameCount++;
        }

        public override long GetFrameCount()
        {
            return frameCount;
        }

        public override void Register(IFrameRunnerWorkItem callback)
        {
            list.Add(callback, out _);
        }
    }
    internal static class ReactiveInputSystemInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void Init()
        {
            // register callbacks
            InputSystem.onBeforeUpdate += ((InputSystemFrameProvider)InputSystemFrameProvider.BeforeUpdate).OnUpdate;
            InputSystem.onAfterUpdate += ((InputSystemFrameProvider)InputSystemFrameProvider.AfterUpdate).OnUpdate;
        }
    }
}

