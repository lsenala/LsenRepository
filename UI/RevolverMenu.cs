using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class RevolverMenu : MonoBehaviour
{
    [Tooltip("This is the text object that will display the labels of the radial elements when they are being hovered over. If you don't want a label, leave this blank.")]
    public TMP_Text  textMeshPro ;
    [Tooltip("This is the list of radial menu elements. This is order-dependent. The first element in the list will be the first element created, and so on.")]
    public List<BulletElements> elements = new List<BulletElements>();
    [Tooltip("Controls the total angle offset for all elements. For example, if set to 45, all elements will be shifted +45 degrees. Good values are generally 45, 90, or 180")]
    public float globalOffset = 0f;
    [HideInInspector] public bool active = false;
    [HideInInspector] public float currentAngle = 0f; //Our current angle from the center of the radial menu.
    [HideInInspector] public int index = 0; //The current index of the element we're pointing at.
    private int elementCount;
    private float angleOffset;//The base offset. For example, if there are 4 elements, then our offset is 360/4 = 90
    private int previousActiveIndex = 0;
    [SerializeField] RectTransform childelements;
    [SerializeField] RectTransform atkrt;
    [SerializeField] RectTransform BulletUI;
    [SerializeField] RectTransform TargetPosition;
    [SerializeField] RectTransform InitPosition;
    PlayerInput playerInput;
    float tempOffset;
    private Vector3 initRay;
    private Vector3 testRay1;
    private void Awake()
    {
        initRay = atkrt.position;
        testRay1 = atkrt.position;
        playerInput = new PlayerInput();
        DOTween.SetTweensCapacity(2000, 2000);
        elementCount = elements.Count;
        angleOffset = (360f / (float)elementCount);
        //Loop through and set up the elements.
        for (int i = 0; i < elementCount; i++) {
            if (elements[i] == null) {
                Debug.LogError("Radial Menu: element " + i.ToString() + " in the radial menu " + gameObject.name + " is null!");
                continue;
            }
            elements[i].parentRM = this;
            elements[i].setAllAngles((angleOffset * i) + globalOffset, angleOffset);
            elements[i].assignedIndex = i;
        }
       StartCoroutine(SelectButton());
    }
    private void OnDisable()
    {
        playerInput.PlayerBattleInput.BattleOptionsScroll.Disable();
        playerInput.PlayerBattleInput.BattleOptionsScroll.performed -= BattleElementsRotate;
    }
    private void OnEnable()
    {
        playerInput.PlayerBattleInput.BattleOptionsScroll.Enable();
        playerInput.PlayerBattleInput.BattleOptionsScroll.performed += BattleElementsRotate;
    }
    private void BattleElementsRotate(InputAction.CallbackContext context)
    {
        float temp = context.ReadValue<float>();
        //tempOffset= temp>0f? angleOffset:-angleOffset;
        if (temp > 0f) tempOffset = angleOffset;
        if (temp < 0f) tempOffset = -angleOffset;
        Vector3 axis = new Vector3(0, 0, 1);
        Quaternion axisRotation = Quaternion.AngleAxis(tempOffset ,axis);
        Quaternion targetRotation = axisRotation * childelements.rotation;
        childelements.DORotateQuaternion(targetRotation, 0.05f);
        BulletUIEffect();
        StartCoroutine(SelectButton());
    }
    private void BulletUIEffect()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(BulletUI.DOLocalMoveX(TargetPosition.localPosition.x,0.01f));
        UnityEngine.UI.Image image= BulletUI.gameObject.GetComponent<UnityEngine.UI.Image>();
        sequence.Append(image.DOFade(0, 0.02f));
        sequence.Append(BulletUI.DOLocalMoveX(InitPosition.localPosition.x, 0.01f));
        sequence.Append(image.DOFade(255f, 0.01f));
    }
    ////需要跟踪角色ID   
    IEnumerator SelectButton()//Awake时和战斗元素（战斗选项）旋转时，调用该函数
    {
        yield return new WaitForSeconds(0.05f);//跟旋转动画时间持平，所以总是发送最新的战斗选项。
        var eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(initRay.x, initRay.y);
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);//7 being my UILayer
        if (results.Where(r => r.gameObject.layer == 7).Count() > 0) {
            //Debug.Log(results[0].gameObject.name);//The UI Element
            BulletElements bulletElement = results[0].gameObject.GetComponentInParent<BulletElements>(); 
            elements.ForEach(element => { if (element != bulletElement) { element.unHighlightThisElement(eventData); /*Debug.Log(element.name);*/ } }); //Deselect the last one.           
            bulletElement.highlightThisElement(eventData);//Select this one,跟unHighLight()方法换位了，才能显示。
        }     
    }
    private void Update()
    {
        Debug.DrawLine(testRay1, new Vector3(testRay1.x, testRay1.y, testRay1.z + 10000), Color.green);

    }
}
