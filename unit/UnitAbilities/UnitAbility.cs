using System;
using UnityEngine;

public abstract class UnitAbility : ScriptableObject, IIndicatorCreator
{
    public AbilityType abilityType;
    public CastType castType;
    [SerializeField] string abilityName;
    [SerializeField] int abilityID;
    [SerializeField] int cost;
    [SerializeField] GameObject indicatorGO;
    public string AbilityName { get { return abilityName; } private set { abilityName = value; } }
    public int AbilityID { get { return abilityID; } private set { abilityID = value; } }
    public int Cost { get { return cost; } private set { cost = value; } }
    public GameObject IndicatorGO { get { return indicatorGO; }private set { indicatorGO = value; } }
    public abstract void Cast(Vector3 uniPos, GameObject indicatorGo, Vector2 targetPos);
    public abstract IIndicator Create();
    //技能类型不一样判定条件不一样。      
}

public enum AbilityType {
    Attack,
    Craft,
    Spell,
    SpecialSkill,
    Item,
    Escape
}
public enum CastType
{
    Idle,
    Buff,
    Damage,
    Target
}

//  Units unit, IAbilityVerify abilityVerify,
    //public virtual void Attack()
    //{
    //    //CpRcvy += 10;
    //    ////恢复CP
    //    //SBoost += 20;
    //}
    //public virtual void SBoostBuff()
    //{
    //    //ChantRcvy = 0;
    //    //CraftRcvy = CraftRcvy / 2;
    //    //SCraftRcvy = SCraftRcvy / 2;
    //    //恢复蓝量
    //}
