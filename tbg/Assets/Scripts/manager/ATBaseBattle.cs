using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.Progress;


public class ATBaseBattle : MonoBehaviour
{
    [SerializeField] DataBaseSO dataBaseSO;
    List<UnitProperties> unitProperties = new List<UnitProperties>();
    public List<Units> unitsID = new List<Units>();
    ////负责AT奖励的生成 必定异常 行动+1 要有可拓展性
    ////负责战斗的事件播放，以及给输出UI需要的数据给数据容器
    private async void Start()
    {
        await GameManager.Instance.SomeThing();
        unitProperties.AddRange(FindObjectsOfType<UnitProperties>());
        //Debug.Log(unitProperties.Count);     
        foreach (UnitProperties unitProperty in unitProperties)
        {
            if (unitProperty.enemyUnit != null)
            {
                EnemyUnit enemyUnit = (EnemyUnit)unitProperty.enemyUnit;
                unitsID.Add(enemyUnit);
                Debug.Log(enemyUnit.unitName);
            }
            else if (unitProperty.playerUnit != null)
            {
                PlayerUnit playerUnit = (PlayerUnit)unitProperty.playerUnit;
                unitsID.Add(playerUnit);
                Debug.Log(playerUnit.unitName);
            }
        }
        Debug.Log(unitsID.Count);
        //Fillter(unitsID, unitID => unitID.MaxSpeed.CompareTo(unitID.MaxSpeed));
        unitsID=unitsID.OrderBy(s => s.MaxSpeed).ToList(); //需要将结果分配到原来的引用上才能生效。
        unitsID.ForEach(p => Debug.Log(p.unitsprite ));    


        //IEnumerable<Units> units = Fillter<Units>(unitsID, unitID => unitID.MaxSpeed.CompareTo(unitID.MaxSpeed));
        //List<Units> list1 =units.ToList();
        //list1.ForEach(p => Debug.Log(p.MaxSpeed)); 

        //IEnumerable<int> numbers = Enumerable.Range(1, 5);
        //List<int> list2 = numbers.ToList();

        // //怎么样才能让unitsprite排序
        //unitsID .Sort (((Units).MaxSpeed))
        //private void GetIconPosition(int i)
        //{

        //}
        //普攻认证（）
        //战技认证（是否异常，是否够CP，是否在范围内）生效播放动画
        //魔法认证（是否异常，是否够MP，是否在范围内，吟唱是否被打断，吟唱时角色是否死亡）
        //伤害计算（是否追击，是否暴击，产生硬直，传递伤害，范围计算，buff相关，target状态相关是否破防）
        //行动顺序排序（换位相关，硬直相关，AT奖励相关）

    }
    
    IEnumerable<T> Fillter<T>(IEnumerable<T> items ,Action <T>f)
    {
        foreach (var item in items )
        {
            f(item); 
            yield return  item;         
        }
    }
    
}
