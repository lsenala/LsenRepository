
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BulletElements : MonoBehaviour
{
    /// <summary>
    /// 选项切换时。按QE键切换选项
    /// </summary>
    public static Action<string> optionChangeEvent;
    [Tooltip("This is the text label that will appear in the center of the radial menu when this option is moused over. Best to keep it short.")]
    public string label;
    [Tooltip("Each radial element needs a button. This is generally a child one level below this primary radial element game object.")]
    public Button button;
    [SerializeField] OptionName optionName;
    // public string Text { set { text = value; } get { return text; } }    
    [HideInInspector] public RevolverMenu parentRM;
    [HideInInspector] public float angleMin, angleMax;
    [HideInInspector] public float angleOffset;
    [HideInInspector] public int assignedIndex = 0;
    [HideInInspector] public bool active = false;
    private void Start()
    {
        EventTrigger t;

        if (button.GetComponent<EventTrigger>() == null) {
            t = button.gameObject.AddComponent<EventTrigger>();
            t.triggers = new System.Collections.Generic.List<EventTrigger.Entry>();
        }
        else
            t = button.GetComponent<EventTrigger>();

        EventTrigger.Entry enter = new EventTrigger.Entry();
        enter.eventID = EventTriggerType.PointerEnter;
        enter.callback.AddListener((eventData) => { setParentMenuLable(label); });

        EventTrigger.Entry exit = new EventTrigger.Entry();
        exit.eventID = EventTriggerType.PointerExit;
        exit.callback.AddListener((eventData) => { setParentMenuLable(""); });

        t.triggers.Add(enter);
        t.triggers.Add(exit);
    }
    public void setAllAngles(float offset, float baseOffset)
    {
        angleOffset = offset;
        angleMin = offset - (baseOffset / 2f);
        angleMax = offset + (baseOffset / 2f);
    }
    public void setParentMenuLable(string l)
    {
        if (parentRM.textMeshPro != null)
            parentRM.textMeshPro.text = l;
    }
    public void highlightThisElement(PointerEventData p)//Awake时和战斗元素（战斗选项）旋转时，调用该函数
    {
        ExecuteEvents.Execute(button.gameObject, p, ExecuteEvents.selectHandler);
        active = true;
        setParentMenuLable(label);
        optionChangeEvent?.Invoke(button.name);
        optionName.bulletElements = this;
        //optionName.Show();
        Debug.Log("ShowItemDetail");
    }
    public void unHighlightThisElement(PointerEventData p)//Awake时和战斗元素（战斗选项）旋转时，调用该函数
    {
        ExecuteEvents.Execute(button.gameObject, p, ExecuteEvents.deselectHandler);
        active = false;
          setParentMenuLable(" ");   
        Debug.Log("Deselect");
    }
   
}
