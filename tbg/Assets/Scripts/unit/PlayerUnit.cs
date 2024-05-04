using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerUnit", menuName = "Units/PlayerUnit")]
public class PlayerUnit : Units 
{
    //do something
    public void Awake()
    {
        type = UnitsType.PlayerUnit;
    }
}
