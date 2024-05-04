using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Units:ScriptableObject  
{
    
    public GameObject unitprefab;
    public Sprite unitsprite;
    public UnitsType type;
    public int unitID;
    public int MaxHP, MaxMP, MaxCP, MaxSpeed;// AtkDmg,AtkRcvy,CraftDmg,CraftRcvy,SCraftDmg,SCraftRcvy;
    public string unitName;   
}
public enum UnitsType
{
    EnemyUnit,
    PlayerUnit,
}
