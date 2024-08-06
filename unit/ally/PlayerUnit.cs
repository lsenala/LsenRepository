using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[CreateAssetMenu(fileName = "PlayerUnit", menuName = "Units/PlayerUnit")]
public class PlayerUnit : Unit 
{
    public void Awake()
    {
        unitType = UnitType.Player;
    }
}
