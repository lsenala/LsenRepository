using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "Enemy", menuName = "Unit/Enemy")]
public class Enemy :ScriptableObject 
{
    [SerializeField] float HP,MP,EnemySpeed,Damage, EnemyAtkRcvy, SCraftRcvy , EnemyInitAt, EnemyCurAt,State;
    public string enemyName;
    public int EnemyID;
    //杂兵实在没意思，整点机制怪
    //自我生成AT专属奖励（硬直减半？）不可换位，可以和普通AT奖励同时获得
    //移动到特定AT顺序后连续行动,过了几个身位连续行动多少次（硬直累加）
    //删除AT奖励，谜之AT奖励
    //吸附周围三格的AT奖励

}
