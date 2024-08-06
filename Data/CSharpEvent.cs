using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CSharpEvent : MonoBehaviour
{
    //void OnMoveControll(InputValue value) {
    //    Vector2 moveVal = value.Get<Vector2>();
    //    Debug.Log(moveVal);
    //}
    //public void moveControl(InputAction.CallbackContext value)
    //{
    //    Vector2 moveVal = value.ReadValue<Vector2>();
    //    Debug.Log(moveVal);
    //}
    //private PlayerInputAction playerInputAction;
    //public Vector2 keyboardMoveAxes => playerInputAction.WASD.MoveControll.ReadValue<Vector2>();
    //private void Awake()
    //{
    //    playerInputAction = new PlayerInputAction();
    //}
    //private void OnEnable()
    //{
    //    playerInputAction.WASD.Enable();
    //}
    //private void OnDisable()
    //{
    //    playerInputAction.WASD.Disable();
    //}
    //private void Update()
    //{
    //    movePlayer();
    //}
    //private void movePlayer()
    //{
    //    if (keyboardMoveAxes != Vector2.zero ) {
    //        Debug.Log(keyboardMoveAxes);
    //    }
    //}
    public PlayerInput playerInput;
 
    void MyEventFunction(InputAction.CallbackContext value)
    {
        Debug.Log(value.action.name + (" was triggered"));
    }
}
