using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="EnemyUnit",menuName ="Units/EnemyUnit" ) ]
public class EnemyUnit : Units 
{
    public void Awake()
    {
        type = UnitsType.EnemyUnit;
    }
}
