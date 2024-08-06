using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LineSpawnWay", menuName = "Unit/LineSpawnWay")]
public class LineSpawnWay : UnitSpawnWay 
{
    public override void unitspawn(UnityEngine.GameObject unitprefab,int ID)//可能需要参数,需要队伍人员数的参数做限制，可能这里或者UnitSlot需要接口的继承者的参数？
    {                                                             //可能能通过层级关系解决此问题
        Instantiate(unitprefab, new Vector3(ID, 0, 0), Quaternion.identity);
    }
}
