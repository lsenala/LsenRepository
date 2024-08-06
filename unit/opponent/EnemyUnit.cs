using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="EnemyUnit",menuName ="Units/EnemyUnit" ) ]
public class EnemyUnit : Unit 
{
    public void Awake()
    {
        unitType = UnitType.Enemy;
    }
}
