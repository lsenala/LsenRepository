using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New EnemyDatabase", menuName = "Assets/Databases/Enemy Database")]
public class DataBaseSO : ScriptableObject
{
   
    public List<MagicDataBase> MagicBook;
    public List<UnitsSlot> UnitsContainer = new List<UnitsSlot>();
    //[SerializeField] PlayerUnit playerUnit;
    //UnitsSlot unitsSlot=new UnitsSlot ();
    public void UnitSpawn(int unitID)
    {
        foreach (UnitsSlot unitsSlot in UnitsContainer)
        {
            if (unitsSlot.units.unitID == unitID&&unitID>0)
            {
                unitsSlot.unitSpawnWay.unitspawn(unitsSlot.units.unitprefab,unitID);
            }
            else if (unitsSlot.units.unitID<0&&unitID >0)
            {
                unitsSlot.unitSpawnWay.unitspawn(unitsSlot.units.unitprefab,unitsSlot.units.unitID);
            }
        }
    }   
    public class MagicDataBase
    {       
        public string incantationName;
        public int MPCost;
        public int MagicDamage;
        public Sprite Magicsprite;
        public int IncantationRcvy;//多余
        public int MagicRcvy;
    }
}
[System.Serializable]
public class UnitsSlot
{
    public Units units;
    public UnitSpawnWay unitSpawnWay;
    public GameObject UnitUiObject;
    public string 特殊遇敌生成方式;
}
