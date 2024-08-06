using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit:ScriptableObject  
{    
    public UnitType unitType;
    [SerializeField] GameObject unitPrefab;
    [SerializeField] GameObject unitUIprefab;
    [SerializeField] int unitID;
    [SerializeField] int maxHP, maxMP, maxCP, maxSpeed;// AtkDmg,AtkRcvy,CraftDmg,CraftRcvy,SCraftDmg,SCraftRcvy;
    [SerializeField] string unitName;
    [SerializeField] List<Craft> unitCrafts;
    [SerializeField] List<Spell> unitSpells;
    [SerializeField] List<SpecialSkill> unitSpecialSkills;

    public GameObject UnitPrefab { get { return unitPrefab; } private set { unitPrefab = value; } }
    public GameObject UnitUIprefab { get { return unitUIprefab; } private set { unitUIprefab = value; } }
    public int UnitID { get { return unitID; } private set { unitID = value; } }
    public int MaxHP { get { return maxHP; } private set { maxHP = value; } }
    public int MaxMP { get { return maxMP; } private set { maxMP = value; } }
    public int MaxCP { get { return maxCP; } private set { maxCP = value; } }
    public int MaxSpeed { get { return maxSpeed; } private set { maxSpeed = value; } }
    public string UnitName { get { return unitName; } private set { unitName = value; } }
    public List<Craft> UnitCrafts { get { return unitCrafts; } private set { unitCrafts = value; } }
    public List<Spell> UnitSpells { get { return unitSpells; } private set { unitSpells = value; } }
    public List<SpecialSkill> UnitSpecialSkills { get { return unitSpecialSkills; } private set { unitSpecialSkills = value; } }

}
public enum UnitType
{
    Enemy,
    Player,
}
