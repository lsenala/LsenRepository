using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IIndicatorCreator
{
    abstract IIndicator Create();
}
public interface IIndicator
{
    IndicatorCollider Operation(Vector3 unitPos, GameObject indicatorGO);
}
struct SpawnInPlace : IIndicator
{
    public IndicatorCollider Operation(Vector3 unitPos, GameObject indicatorGO)
    {      
        Vector3 initPos = new Vector3(unitPos.x, 0.1f, unitPos.z);
        GameObject indicator=Object.Instantiate(indicatorGO, initPos, Quaternion.AngleAxis(-90, Vector3.up));
        return indicator.GetComponent<IndicatorCollider>();
    }
}



