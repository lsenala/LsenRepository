using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbilityVerify 
{
    event Action<int,int> StatusOnChange;
    event Action<int> Invalid;
    event Action<int> Valid;
    void Verify(Unit unit,UnitAbility unitAbility);    
}
