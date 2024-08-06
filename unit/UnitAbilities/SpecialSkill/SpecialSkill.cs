using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecialSkill : UnitAbility
{
    private void Awake()
    {
        abilityType = AbilityType.SpecialSkill;
    }
}
