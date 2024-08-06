using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionElement : MonoBehaviour
{
    [Multiline][SerializeField] private string text;
    [SerializeField] private UnityEngine.UI.Selectable selectable;
    [SerializeField] RectTransform atkrt;
    private PointerEventData eventData;
    Vector3 initRay;
    public string Text { set { text = value; }get { return text; } }
    public UnityEngine.UI.Selectable Selectable { set { selectable = value; } get { return selectable; } }
    private void Awake()
    {
        //initRay = atkrt.position;
        eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(initRay.x, initRay.y);
    }
    protected virtual void Update()
    {
        if (OptionName.HoverData == this) {
            if (selectable != null) {
                OptionName.HoverShow = selectable.enabled == true && selectable.interactable == true;
            }
        }
    }
}
