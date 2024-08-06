using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player", menuName = "Unit/Player")]
public class PlayerSO : ScriptableObject 
{
    public string PlayerName;
    public int PlayerID;
    public int PlayerSpeed;
    [SerializeField] int AtkRcvy,CraftRcvy,SCraftRcvy;
    [SerializeField] int HP,MP,CP,SBoost,InitAT, Delay, CurAT;
    [SerializeField] DataBaseSO dataBaseSO;
    void Start()
    {
         //算出初始AT 战斗开始时玩家发送战斗事件，GM计算AT排序
         InitAT = 1000 / PlayerSpeed;
        //传数据
    }
    //普通攻击行动（有CP获得，产生硬直）
    void Attack()
    {
        int AttackDamage = 20;
        CP += 15;
        Delay = 100 * AtkRcvy / PlayerSpeed;
    }
    //基础法术（0耗魔，SBoost获得，要获得CP？）
    void BasicMagic()
    {
        int BasicMagicDamage = 30;
        SBoost += 20;
    }
    //SBoost的buff效果：法术0咏唱，战技和S技硬直减半回复蓝量
    void SBoostBuff()
    {
        
    }
    //战技（）主要做换位AT奖励的战技 还有urahayaku  S技随便
    //魔法（咏唱 施法）
    void Magic(string MagicName)
    {
        

    }
    void Update()
    {
        CurAT = InitAT + Delay;
    }
}
