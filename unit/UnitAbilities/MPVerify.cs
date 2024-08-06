using System;
//�չ���֤����
//ս����֤���Ƿ��쳣���Ƿ�CP���Ƿ��ڷ�Χ�ڣ���Ч���Ŷ���
//ħ����֤���Ƿ��쳣���Ƿ�MP���Ƿ��ڷ�Χ�ڣ������Ƿ񱻴�ϣ�����ʱ��ɫ�Ƿ�������
//�Ƿ�ȷ�ϣ�
//�ؼ���֤���Ƿ���token����
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