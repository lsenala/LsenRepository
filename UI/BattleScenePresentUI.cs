
using System;
using UnityEngine;

public class BattleScenePresentUI : MonoBehaviour
{
    [SerializeField] DataBaseSO dataBaseSO;
    RectTransform sequenceofactionrect;
    ATBaseBattle atbaseBattle;
    Unit[] units;

    //人物ui控件的排序 需要异步 UI间隔40
    //获取列表，相对于锚框的上边的距离，进行等差插入排序
    private async Awaitable Awake()
    {
        await Awaitable.WaitForSecondsAsync(1);
        atbaseBattle = gameObject.GetComponentInParent<ATBaseBattle>();
        units = atbaseBattle.units.ToArray();
        RectTransform[] sequenceofactionrects = gameObject.GetComponentsInChildren<RectTransform>();
        Array.ForEach<RectTransform>(sequenceofactionrects, x => { if (x.name == "SequenceOfAction") { sequenceofactionrect = x; } });
        for (int i = 0; i < units.Length; i++) {
            UnityEngine.GameObject go = Instantiate(units[i].UnitUIprefab, sequenceofactionrect);
            go.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -43f * i);  //可能要改成-2*anchorposition
        }
    }
    //UnitUI的生成及插入,要插到SequenceOfAction上
    private void UnitQueue() 
    {
        //Debug.Log("本地位置为"+unitUIPrefab.transform.localPosition);
              
        Array.ForEach(units, unit => Debug.Log("相对于父物体的位置为" + unit.UnitUIprefab.GetComponent<RectTransform>().localPosition));       
        Array.ForEach(units, unit => Debug.Log("相对于锚框的位置为" + unit.UnitUIprefab.GetComponent<RectTransform>().anchoredPosition));       
    } 
    
    private void Update()
    {
          
    }
}
