using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[CreateAssetMenu (fileName ="Doppelganger",menuName= "UnitAbility/ Doppelganger")]
public class Doppelganger : SpecialSkill
{
    //¼¼ÄÜÂß¼­
    public override void Cast(Vector3 uniPos,GameObject indicatorGo,Vector2 targetPos)
    {
        Vector2 casterPos=new Vector2(uniPos.x,uniPos.z);
        Create().Operation(uniPos, indicatorGo).ChangeTheRange(targetPos,casterPos,ChangeMeshType.Scalable).Forget();
    }
    public override IIndicator Create()
    {
        return new SpawnInPlace();
    }
}
