
//using Lean.Transition;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
[RequireComponent(typeof(RectTransform))]
public class OptionName : MonoBehaviour
{
    [Serializable] public class UnityEventString : UnityEvent<string> { }
    [SerializeField] private float showDelay;
    //[SerializeField] private LeanPlayer showTransitions;
    //[SerializeField] private LeanPlayer hideTransitions;
    [SerializeField] private UnityEventString onShow;
    [SerializeField] private UnityEvent onHide;
    //[NonSerialized] private RectTransform cachedRectTransform;
    //[NonSerialized] private bool cachedRectTransformSet;
    //[NonSerialized] private float currentDelay;
    [NonSerialized] private bool shown;
    [HideInInspector] public BulletElements bulletElements;
    public static BulletElements HoverData;
    public static bool HoverShow;
    public static bool PressShow;
    private static Vector3[] corners = new Vector3[4];
    //public ActivationType Activation { set { activation = value; } get { return activation; } }
    //public LeanPlayer ShowTransitions { get { if (showTransitions == null) showTransitions = new LeanPlayer(); return showTransitions; } }
   // public LeanPlayer HideTransitions { get { if (hideTransitions == null) hideTransitions = new LeanPlayer(); return hideTransitions; } }
    public UnityEventString OnShow { get { if (onShow == null) onShow = new UnityEventString(); return onShow; } }
    public UnityEvent OnHide { get { if (onHide == null) onHide = new UnityEvent(); return onHide; } }
    //public void Show()
    //{
    //    shown = true;
    //    if (showTransitions != null) {
    //        showTransitions.Begin();
    //    }
    //    if (onShow != null){
    //        onShow.Invoke(bulletElements.label);
    //    }
    //}
    //public void Hide()
    //{
    //    if (hideTransitions != null){
    //        hideTransitions.Begin();
    //    }
    //    if (onHide != null){
    //        onHide.Invoke();
    //    }
    //}
} 
