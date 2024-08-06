using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TestBehaviourScript : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction scroll;
    float angle;
   
    private void Awake()
    {
        playerInput = new PlayerInput();
        DOTween.SetTweensCapacity(2000, 2000);
       
    }
    private void OnDisable()
    {
        playerInput.PlayerBattleInput.BattleOptionsScroll.Disable();
        playerInput.PlayerBattleInput.BattleOptionsScroll.performed-= test1;

    }
    private void OnEnable()
    {
        playerInput.PlayerBattleInput.BattleOptionsScroll.Enable();
        playerInput.PlayerBattleInput.BattleOptionsScroll.performed+= test1;
    }
    private void test1(InputAction.CallbackContext context)
    {
        float temp = context.ReadValue<float>();
        if (temp  > 0f) angle = 60;
        if (temp  < 0f) angle = -60;
        Vector3 axis = new Vector3(0, 0, 1);
        Quaternion axisRotation = Quaternion.AngleAxis(angle, axis);
        Quaternion targetRotation = axisRotation * transform.rotation;     
        gameObject.transform.DORotateQuaternion(targetRotation, 0.15f);
    }
    //loop的前提是滚轮有输入
    private void Update()
    {
    }
    public void test3()
    {
        Debug.Log("!!!");
    }


}
//public class Drag : MonoBehaviour {
//    private Vector3 _screenPoint;
//    private Vector3 _offset;
//    private Vector3 _curScreenPoint;
//    private Vector3 _curPosition;
//    private Vector3 _velocity;
//    private bool _underInertia;
//    private float _time = 0.0f;
//    public float SmoothTime;

//    void Update()
//    {
//        if (_underInertia && _time <= SmoothTime) {
//            transform.position += _velocity;
//            _velocity = Vector3.Lerp(_velocity, Vector3.zero, _time);
//            _time += Time.smoothDeltaTime;
//        }
//        else {
//            _underInertia = false;
//            _time = 0.0f;
//        }
//    }
//    void OnMouseDown()
//    {
//        _screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
//        _offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
//        //Screen.showCursor = false;
//        _underInertia = false;
//    }
//    void OnMouseDrag()
//    {
//        Vector3 _prevPosition = _curPosition;
//        _curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
//        _curPosition = Camera.main.ScreenToWorldPoint(_curScreenPoint) + _offset;
//        _velocity = _curPosition - _prevPosition;
//        transform.position = _curPosition;
//    }
//    void OnMouseUp()
//    {
//        _underInertia = true;
//        //Screen.showCursor = true;
//    }
//}
