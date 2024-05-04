using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAbility : MonoBehaviour
{
    public int AtkDmg, AtkRcvy, CraftDmg, CraftRcvy,ChantRcvy, SCraftDmg, SCraftRcvy,CpRcvy,MpRcvy,MaxSBoost,SBoost;

    public virtual void SBoostBuff()
    {
        ChantRcvy = 0;
        CraftRcvy = CraftRcvy / 2;
        SCraftRcvy = SCraftRcvy / 2;
        //»Ö¸´À¶Á¿
    }
    public virtual void Attack()
    {
        CpRcvy += 10;
        //»Ö¸´CP
        SBoost += 20;
    }
    public abstract void Craft();

    public abstract void Incantation();

    public abstract void SCraft();
}
