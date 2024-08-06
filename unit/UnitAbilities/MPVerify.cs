using System;
//普攻认证（）
//战技认证（是否异常，是否够CP，是否在范围内）生效播放动画
//魔法认证（是否异常，是否够MP，是否在范围内，吟唱是否被打断，吟唱时角色是否死亡）
//是否确认，
//特技认证（是否有token，）
public struct MPVerify : IAbilityVerify
{
    public event Action<int,int> StatusOnChange;
    public event Action<int> Invalid;
    public event Action<int> Valid;
    public int test;
    public MPVerify(int t):this() { test = t; }
    public void Verify(Unit unit, UnitAbility unitAbility)
    {
        if (unitAbility.abilityType == AbilityType.Spell && unit.MaxMP >= unitAbility.Cost) 
            Valid.Invoke(unitAbility.AbilityID);
        else if(unitAbility.abilityType == AbilityType.Spell && unit.MaxMP < unitAbility.Cost) 
            Invalid.Invoke(unitAbility.AbilityID);
    }
}
public struct CPVerify : IAbilityVerify
{
    public event Action<int, int> StatusOnChange;
    public event Action<int> Invalid;
    public event Action<int> Valid;

    public void Verify(Unit unit, UnitAbility unitAbility)
    {
        if (unitAbility.abilityType == AbilityType.Craft && unit.MaxCP >= unitAbility.Cost) 
            Valid.Invoke(unitAbility.AbilityID);
        else if (unitAbility.abilityType == AbilityType.Craft && unit.MaxCP < unitAbility.Cost) 
            Invalid.Invoke(unitAbility.AbilityID);
    }
}
public struct TokenVerify : IAbilityVerify
{
    public event Action<int, int> StatusOnChange;
    public event Action<int> Invalid;
    public event Action<int> Valid;

    public void Verify(Unit unit, UnitAbility unitAbility)
    {
        //if (unitAbility.abilityType == AbilityType.SpeciaSkill && unitAbility.Cost > 0 && unit.UnitAbilities.Contains(unitAbility)) 
        //    Valid.Invoke(unitAbility.AbilityID);
        //else if (unitAbility.abilityType == AbilityType.SpeciaSkill && unitAbility.Cost < 0 && unit.UnitAbilities.Contains(unitAbility)) 
        //    Invalid.Invoke(unitAbility.AbilityID);         
    }
}
public struct HasTargetVerify : IAbilityVerify
{
    public event Action<int, int> StatusOnChange;
    public event Action<int> Invalid;
    public event Action<int> Valid;

    public void Verify(Unit unit, UnitAbility unitAbility)
    {
        //if (unitAbility.castType == CastType.Damage && unitAbility.IndicatorGO.UnitsList.Exists(u => !u.unitType.Equals(unit.unitType)))
        //    Valid.Invoke(unitAbility.AbilityID);
        //else if (unitAbility.castType == CastType.Idle && unitAbility.IndicatorGO.UnitsList.Count == 0)
        //    Valid.Invoke(unitAbility.AbilityID);
        //else if (unitAbility.castType == CastType.Buff && unitAbility.IndicatorGO.UnitsList.Exists(u => u.unitType.Equals(unit.unitType)))
        //    Valid.Invoke(unitAbility.AbilityID);
        //else if(unitAbility.castType==CastType.Target)//Need to append
        //    Valid.Invoke(unitAbility.AbilityID);
        //else
        //    Invalid.Invoke(unitAbility.AbilityID);
    }
}