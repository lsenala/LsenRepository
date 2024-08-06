using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CircleSpawnWay", menuName = "Unit/CircleSpawnWay")]
public class CircleSpawnWay : UnitSpawnWay
{
    public override void unitspawn(UnityEngine.GameObject unitprefab,int ID)//������Ҫ����
    {
      for (int i = 0; i< 10; i++)
      {                                       //Բ�ܽ�=2��
          Vector3 pos = new Vector3(Mathf.Cos(i * (2 * Mathf.PI) / 10), 0, Mathf.Sin(i * (2 * Mathf.PI) / 10)+3);
          pos *= 5;       // Բ���뾶��5
          Instantiate(unitprefab, pos, Quaternion.identity);
      }     
    }
}

