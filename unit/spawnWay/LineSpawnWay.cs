using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LineSpawnWay", menuName = "Unit/LineSpawnWay")]
public class LineSpawnWay : UnitSpawnWay 
{
    public override void unitspawn(UnityEngine.GameObject unitprefab,int ID)//������Ҫ����,��Ҫ������Ա���Ĳ��������ƣ������������UnitSlot��Ҫ�ӿڵļ̳��ߵĲ�����
    {                                                             //������ͨ���㼶��ϵ���������
        Instantiate(unitprefab, new Vector3(ID, 0, 0), Quaternion.identity);
    }
}
