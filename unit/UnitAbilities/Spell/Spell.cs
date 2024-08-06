using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : UnitAbility
{
    private void Awake()
    {
        abilityType=AbilityType.Spell;
    }
}
