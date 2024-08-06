//using NPBehave;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class ATBaseBattle : MonoBehaviour
{
    //[SerializeField] DataBaseSO dataBaseSO;
    List<UnitCollider> unitCollideList;
    public List<Unit> units;
    //private Root behaviorTree;
    //private Blackboard sharedBlackboard;
    //private Blackboard ownblackboard;
    ////负责AT奖励的生成 必定异常 行动+1 要有可拓展性
    ////负责战斗的事件播放，以及给输出UI需要的数据给数据容器
    private async Awaitable Awake()
    {
        await Awaitable.WaitForSecondsAsync(1);
        unitCollideList = new List<UnitCollider>();
        units = new List<Unit>();
        unitCollideList.AddRange(FindObjectsByType<UnitCollider>(FindObjectsSortMode.None));  //加入所有的UnitProperties
        foreach (UnitCollider unitcollider in unitCollideList) {
            units.Add(unitcollider.unit);
        }
        Debug.Log(units.Count);
        units = units.OrderBy(s => s.MaxSpeed).Reverse().ToList(); //需要将结果分配到原来的引用上才能生效。
        //sharedBlackboard = UnityContext.GetSharedBlackboard("ATB-AI");
        //ownblackboard = new Blackboard(sharedBlackboard, UnityContext.GetClock());
        //behaviorTree = CreateBehaviorTree();
        //behaviorTree.Start();
    }
    //行为树只负责决策和对列表操作
    //private Root CreateBehaviorTree()
    //{
    //    return new Root(ownblackboard,
    //            new Service(1f, UpdateBlackBoard,
    //                new Sequence(
    //                    //new Action(() => Debug.Log(ownblackboard["FirstUnit"])),
    //                    new Selector(
    //                       new BlackboardCondition("IsStartPhase", Operator.IS_EQUAL, true, Stops.SELF,
    //                            new Sequence(
    //                                new Action(() => Debug.Log("准备阶段")),
    //                                new Action(CameraFollow),
    //                                new WaitUntilStopped())),
    //                         new BlackboardCondition("IsPredictPhase", Operator.IS_EQUAL, true, Stops.SELF,
    //                             new Sequence(
    //                                new Action(() => Debug.Log("预测阶段")),
    //                                new WaitUntilStopped())),
    //                         new BlackboardCondition("IsEndPhase", Operator.IS_EQUAL, true, Stops.SELF,
    //                             new Sequence(
    //                                new Action(() => Debug.Log("结束阶段")),
    //                                new WaitUntilStopped()))
    //                     ))));
    //}
    //private void UpdateBlackBoard()
    //{
    //    ownblackboard["ATUnitList"] = units;
    //    ownblackboard["FirstUnit"] = units[0];
    //}
    //private void Spell()
    //{

    //}
}

//伤害计算（是否追击，是否暴击，产生硬直，传递伤害，范围计算，buff相关，target状态相关是否破防）
//行动顺序排序（换位相关，硬直相关，AT奖励相关）
//IEnumerable<T> Fillter<T>(IEnumerable<T> items ,Action <T>f)
//{
//    foreach (var item in items )
//    {
//        f(item); 
//        yield return  item;         
//    }
//}
//if (unitcollider.unit.unitType==UnitType.Enemy) {
//    Units enemyUnit = unitcollider.unit;
//    units.Add(enemyUnit);
//}
//else if (unitcollider.unit.unitType==UnitType.Player) {
//    Units playerUnit = unitcollider.unit;
//    units.Add(playerUnit);
//}
