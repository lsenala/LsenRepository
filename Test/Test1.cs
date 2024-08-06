using UnityEngine;
using System;
using UnityEngine.InputSystem;
using System.Linq;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using R3;
using System.ComponentModel;
using ReactiveInputSystem;
using Cysharp.Threading.Tasks.Linq;
using DG.Tweening;


public class Test1 : MonoBehaviour ,INotifyPropertyChanged
{
    Subject<int> subject;
    Observable<InputAction.CallbackContext> c;
    Action action;  
    PlayerInput playerInput;
    Renderer r;
    AsyncLazy<int> keyLazy;
    AsyncLazy<float> scrollLazy;
    AsyncLazy<float> mouseBtnLazy;
    AsyncLazy asyncLazy;
    ReactiveProperty<float> key;
    float scroll;
    float mouse;
    public event PropertyChangedEventHandler PropertyChanged;
    Test1 test1;
    int[] ints;
   
    private void Awake()
    {
        playerInput=new PlayerInput();
        r=GetComponent<MeshRenderer>();
        ints = new int[3] { 1,2,3};
    }
    //private async void Start()
    //{
    //    //var token = this.GetCancellationTokenOnDestroy();

    //    //// EveryUpdate()は毎フレームのタイミングで完了するUniTaskを返す
    //    //await UniTaskAsyncEnumerable.EveryUpdate()
    //    //    .Select((_, x) => x)
    //    //    // 5回まで実行する
    //    //    .Take(5)
    //    //    // ForEachAsyncで待機する
    //    //    .ForEachAsync(_ => Debug.Log(Time.frameCount), token);

    //    //Debug.Log("Done!");
    //    //    await UniTaskAsyncEnumerable.EveryUpdate()
    //    //.Select((_, x) => x)
    //    //// 5回まで実行する
    //    //.Take(5)
    //    //// ForEachAwaitAsyncで待機する
    //    //.ForEachAwaitAsync(async _ => {
    //    //    Debug.Log(1);
    //    //    // 10フレーム待ってから次のメッセージを取りに行く
    //    //    await UniTask.DelayFrame(10, cancellationToken: token);
    //    //}, token);
    //    //Debug.Log("Done!");
    //    //var token = this.GetCancellationTokenOnDestroy();
    //    //UniTaskAsyncEnumerable.EveryUpdate()
    //    //    .Select((_, x) => x)
    //    //    .Take(5)
    //    //    .Subscribe(async (_, ct) => {
    //    //        await UniTask.Delay(100, cancellationToken: ct);
    //    //        Debug.Log("Do!");
    //    //    }, token);

    //}
    
    void Start()
    {
        ints.ToUniTaskAsyncEnumerable()
            .WhereAwait(async (i) => {
                Debug.Log(1);
                await UniTask.Delay(7000);
                Debug.Log(2);
                return i == 1||i==3;
            })
            .SelectAwait(async (x) => {
                var v = UniTask.Create(async () => {
                    Debug.Log(3);
                    await UniTask.Delay(10000);
                    Debug.Log(4);
                });
                Debug.Log(5);
                await UniTask.Yield();
                return x;
            })
            .SelectAwait(async (x) => {
                Debug.Log("123");
                await UniTask.Yield();
                return x;
            }).ToListAsync();

        //foreach(var i in v)
        //    Debug.Log(i);
        //Test().Forget();
    }
    public Vector3 worldPosition;
    Plane plane = new Plane(Vector3.up, 0);

    void Update()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance)) {
            worldPosition = ray.GetPoint(distance);
        }
    }
    public UniTask<U> WrapByUniTaskCompletionSource<U>()
    {
        UniTaskCompletionSource<U> utcs = new();
        var v=utcs.Task;
        var trigger=this.GetAsyncCollisionEnterTrigger();
        //var collision=await trigger.OnCollisionEnterAsync();
        // 当操作完成时，调用 utcs.TrySetResult();
        // 当操作失败时, 调用 utcs.TrySetException();
        // 当操作取消时, 调用 utcs.TrySetCanceled();
        
        return utcs.Task; //本质上就是返回了一个UniTask<int>
    }
    async UniTask<T> GenericUniTask<T>(T t)
    {
        await UniTask.Yield ();
        return t;
    }
    async UniTask Test()
    {

        asyncLazy = UniTask.Lazy(async () =>
            await UniTask.Create(async () => {
                //Debug.Log("5");
                await UniTask.Yield();
                action+=UniTask.Action(() => {
                    Debug.Log("6");
                    return new UniTaskVoid();
                });
            }
            )) ;
        //Debug.Log("1");
        await asyncLazy.Task;
        //Debug.Log("2");
        await asyncLazy.Task;
        //Debug.Log("3");
        await asyncLazy.Task;
    }
    private void OnMouseMove(InputAction.CallbackContext context)
    {
        //Debug.Log(context.ReadValue<Vector2>());
        if (context.started)
            r.material.color = Color.yellow;
        else if (context.performed)
            r.material.color = Color.green;
        else if (context.canceled)
            r.material.color = Color.red;
    }
    private void OnKeyPress(InputAction.CallbackContext context)
    {
        float o = context.ReadValue<float>();
        var s=Observable.ObservePropertyChanged(test1, Test1 =>scroll);
        Observable<float> observable = ObservableExtensions.AsObservable(s);
        Observable.EveryValueChanged(transform, t => t.transform);
        if (context.started)
            r.material.color = Color.gray;
        else if (context.performed) {
            r.material.color = Color.magenta;
            var kp = UniTask.Create(async () => {
                Debug.Log("kp");
                await UniTask.Yield();
            });
            kp.Forget();


            //UniTask.Create(async () => { var t = await keyLazy.Task; Debug.Log(t); }).Forget();
            key = new ReactiveProperty<float>(context.ReadValue<float>());
            Debug.Log("Key Press ");
        }
        else if (context.canceled)
            r.material.color = Color.black;
    }
        
    private void TOnScroll(InputAction.CallbackContext context)
    {
        var v = context.ReadValue<float>();
        Debug.Log("vo " + v);
        scrollLazy = UniTask.Lazy(async () => {
            var s = context.ReadValue<float>();
            await keyLazy.Task;
            Debug.Log("v "+s);
            return s;
        });
        scroll = context.ReadValue<float>();
        Debug.Log("Scroll ");
    }
    private void OnMouseButtonPress(InputAction.CallbackContext context)
    {
        float m=context.ReadValue<float>();
        mouseBtnLazy = UniTask.Lazy(async () => {
            var m = context.ReadValue<float>();
            await scrollLazy.Task;
            return m;
        });
        mouse = context.ReadValue<float>();
        Debug.Log("Mouse ");
        r.material.color = m > 0 ? Color.blue : Color.cyan;
    }
    private void OnEnable()
    {
        playerInput.PlayerBattleInput.BattleOptionsScroll.Enable();
        playerInput.PlayerBattleInput.BattleOptionsScroll.performed += TOnScroll;       
        playerInput.PlayerBattleInput.SelectItem.Enable();
        playerInput.PlayerBattleInput.SelectItem.started += OnKeyPress;
        playerInput.PlayerBattleInput.SelectItem.canceled += OnKeyPress;
        playerInput.PlayerBattleInput.SelectItem.performed += OnKeyPress;
        playerInput.PlayerBattleInput.TargetPosition.Enable();
        playerInput.PlayerBattleInput.TargetPosition.performed += OnMouseMove;
        playerInput.PlayerBattleInput.YesOrNot.Enable();
        playerInput.PlayerBattleInput.YesOrNot.performed += OnMouseButtonPress;
    }
    private void OnDisable()
    {
        playerInput.PlayerBattleInput.BattleOptionsScroll.Disable();
        playerInput.PlayerBattleInput.BattleOptionsScroll.performed -= TOnScroll;
        playerInput.PlayerBattleInput.SelectItem.Disable();
        playerInput.PlayerBattleInput.SelectItem.started -= OnKeyPress;
        playerInput.PlayerBattleInput.SelectItem.canceled -= OnKeyPress;
        playerInput.PlayerBattleInput.SelectItem.performed -= OnKeyPress;
        playerInput.PlayerBattleInput.TargetPosition.Disable();
        playerInput.PlayerBattleInput.TargetPosition.performed -= OnMouseMove;
        playerInput.PlayerBattleInput.YesOrNot.Disable();
        playerInput.PlayerBattleInput.YesOrNot.performed -= OnMouseButtonPress;
    }

 
}




