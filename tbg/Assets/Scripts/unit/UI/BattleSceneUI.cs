using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneUI : MonoBehaviour
{
    [SerializeField] DataBaseSO dataBaseSO;
    ATBaseBattle atbaseBattle;
    private List<Units> unitsID = new List<Units>(); 

    //人物ui控件的排序 需要异步 UI间隔40
    //获取列表，相对于锚框的上边的距离，进行等差插入排序，控制动画的播放时间
    private void Awake()
    {
        atbaseBattle =gameObject.GetComponentInParent<ATBaseBattle>(); 
        
    }
    private void Update()
    {
        
    }
}
