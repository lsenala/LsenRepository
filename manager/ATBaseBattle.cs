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
    ////����AT���������� �ض��쳣 �ж�+1 Ҫ�п���չ��
    ////����ս�����¼����ţ��Լ������UI��Ҫ�����ݸ���������
    private async Awaitable Awake()
    {
        await Awaitable.WaitForSecondsAsync(1);
        unitCollideList = new List<UnitCollider>();
        units = new List<Unit>();
        unitCollideList.AddRange(FindObjectsByType<UnitCollider>(FindObjectsSortMode.None));  //�������е�UnitProperties
        foreach (UnitCollider unitcollider in unitCollideList) {
            units.Add(unitcollider.unit);
        }
        Debug.Log(units.Count);
        units = units.OrderBy(s => s.MaxSpeed).Reverse().ToList(); //��Ҫ��������䵽ԭ���������ϲ�����Ч��
        //sharedBlackboard = UnityContext.GetSharedBlackboard("ATB-AI");
        //ownblackboard = new Blackboard(sharedBlackboard, UnityContext.GetClock());
        //behaviorTree = CreateBehaviorTree();
        //behaviorTree.Start();
    }
    //��Ϊ��ֻ������ߺͶ��б����
    //private Root CreateBehaviorTree()
    //{
    //    return new Root(ownblackboard,
    //            new Service(1f, UpdateBlackBoard,
    //                new Sequence(
    //                    //new Action(() => Debug.Log(ownblackboard["FirstUnit"])),
    //                    new Selector(
    //                       new BlackboardCondition("IsStartPhase", Operator.IS_EQUAL, true, Stops.SELF,
    //                            new Sequence(
    //                                new Action(() => Debug.Log("׼���׶�")),
    //                                new Action(CameraFollow),
    //                                new WaitUntilStopped())),
    //                         new BlackboardCondition("IsPredictPhase", Operator.IS_EQUAL, true, Stops.SELF,
    //                             new Sequence(
    //                                new Action(() => Debug.Log("Ԥ��׶�")),
    //                                new WaitUntilStopped())),
    //                         new BlackboardCondition("IsEndPhase", Operator.IS_EQUAL, true, Stops.SELF,
    //                             new Sequence(
    //                                new Action(() => Debug.Log("�����׶�")),
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

//�˺����㣨�Ƿ�׷�����Ƿ񱩻�������Ӳֱ�������˺�����Χ���㣬buff��أ�target״̬����Ƿ��Ʒ���
//�ж�˳�����򣨻�λ��أ�Ӳֱ��أ�AT������أ�
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
