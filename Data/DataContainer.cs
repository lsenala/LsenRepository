using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
[CreateAssetMenu]
public class DataContainer : ScriptableObject
{
  //  [SerializeField] EnemyDataBase enemyDataBase;
   // public GameEvent gameEvent;
   // EnemyProperties enemyProperty;//?
    [SerializeField] public Enemy enemy;
   ////[SerializeField] public EnemySpawnWay enemySpawnWay;//û�õ�
   //// public GameObject enemyprefab;

   // //ֻ��ͨ���������Ľ���������������������
   // public List<EnemyProperties> enemyDatas = new List<EnemyProperties>();

   // public void GetEnemyData(EnemyProperties enemyProperties)
   // {
   //      enemyProperty = enemyProperties;
   //      enemyDatas.Add(enemyProperties);   
   //      Debug.Log("How many  " + enemyDatas.Count);
   //      LookThroughEnemyDatas((enemyProperties) => Debug.Log("enemyprab " + enemyProperties.enemySpawnWay.enemyprefab));  
   // }
   // public void RemoveEnemyData(EnemyProperties enemyProperties)
   // {
   //     enemyDatas.Remove(enemyProperties);
   //     Debug.Log("How many  " + enemyDatas.Count);
   //     LookThroughEnemyDatas((enemyProperty) => Debug.Log("enemyprab " + enemyProperty.enemySpawnWay.enemyprefab));
   // }
   // public void LookThroughEnemyDatas(Action<EnemyProperties> dowork )
   // {
   //     foreach (EnemyProperties enemyProperties in enemyDatas)//enemyDatas�е�Ԫ�ر�����enemyProperties�����������
   //     {
   //         dowork(enemyProperties);
   //     }
   // }
   // public  IEnumerator loadenmeysouce()
   // {
   //     yield return new WaitForSeconds(2);
   //     gameEvent.Raise();
   //     Debug.Log("something ");
   // }
   // public void EnemyContainnerSpawnEnemy()//�붩���¼�
   // {

   //      LookThroughEnemyDatas ((enemyProperties)=>enemyProperties.enemySpawnWay.enemyspawn());
         
   //     //enemyDatas.ForEach(enemySpawnWay.enemyspawn());      
   // }
   
}
