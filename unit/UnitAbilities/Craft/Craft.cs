using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Craft : UnitAbility
{
    private void Awake()
    {
        abilityType=AbilityType.Craft;
    }
}
