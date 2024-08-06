using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[CreateAssetMenu(fileName = "UnitSpawnWay", menuName = "Unit/UnitSpawnWay")]
public abstract class UnitSpawnWay : ScriptableObject 
{
    public abstract void unitspawn(UnityEngine.GameObject unitprefab,int ID);//可能需要参数
    
       //for (int i = 0; i < 10; i++)
       //{
       //   Vector3 pos = new Vector3(Mathf.Cos(i * (2 * Mathf.PI) / 10), 0, Mathf.Sin(i * (2 * Mathf.PI) / 10));
       //   pos *= 5;       // 圆环半径是5
       //   Instantiate(unitprefab, pos, Quaternion.identity);
       //}
    
}
