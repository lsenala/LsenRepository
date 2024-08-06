
using System;
using UnityEngine;

public class BattleScenePresentUI : MonoBehaviour
{
    [SerializeField] DataBaseSO dataBaseSO;
    RectTransform sequenceofactionrect;
    ATBaseBattle atbaseBattle;
    Unit[] units;

    //����ui�ؼ������� ��Ҫ�첽 UI���40
    //��ȡ�б������ê����ϱߵľ��룬���еȲ��������
    private async Awaitable Awake()
    {
        await Awaitable.WaitForSecondsAsync(1);
        atbaseBattle = gameObject.GetComponentInParent<ATBaseBattle>();
        units = atbaseBattle.units.ToArray();
        RectTransform[] sequenceofactionrects = gameObject.GetComponentsInChildren<RectTransform>();
        Array.ForEach<RectTransform>(sequenceofactionrects, x => { if (x.name == "SequenceOfAction") { sequenceofactionrect = x; } });
        for (int i = 0; i < units.Length; i++) {
            UnityEngine.GameObject go = Instantiate(units[i].UnitUIprefab, sequenceofactionrect);
            go.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -43f * i);  //����Ҫ�ĳ�-2*anchorposition
        }
    }
    //UnitUI�����ɼ�����,Ҫ�嵽SequenceOfAction��
    private void UnitQueue() 
    {
        //Debug.Log("����λ��Ϊ"+unitUIPrefab.transform.localPosition);
              
        Array.ForEach(units, unit => Debug.Log("����ڸ������λ��Ϊ" + unit.UnitUIprefab.GetComponent<RectTransform>().localPosition));       
        Array.ForEach(units, unit => Debug.Log("�����ê���λ��Ϊ" + unit.UnitUIprefab.GetComponent<RectTransform>().anchoredPosition));       
    } 
    
    private void Update()
    {
          
    }
}
