using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer),typeof(MeshCollider))]
public class IndicatorCollider: MonoBehaviour
{
    
    
    Func<Vector2, Vector2, Vector2> func;
    Indicator[] indicators;
    Mesh finalMesh;
    MeshFilter[] filters;
    List<Func<float,Mesh>> meshesList;
    List<Unit> units;
    ChangeMeshType changeMeshType;
    public List<Unit> UnitsList { get { return units; }private set { units = value; } }
   
    void Start()
    {
        CombineMesh();
    }
    private void CombineMesh()
    {
        filters = GetComponentsInChildren<MeshFilter>();
        finalMesh = new Mesh();
        GetComponent<MeshCollider>().sharedMesh = null;
        CombineInstance[] combiners = new CombineInstance[filters.Length];
        for (int i = 0; i < filters.Length; i++) {
            combiners[i].subMeshIndex = 0;
            combiners[i].mesh = filters[i].mesh;
            combiners[i].transform = filters[i].transform.localToWorldMatrix;
        }
        finalMesh.CombineMeshes(combiners);
        GetComponent<MeshFilter>().mesh = finalMesh;

        GetComponent<MeshCollider>().sharedMesh = finalMesh;
        indicators = GetComponentsInChildren<Indicator>();
        func = GetComponentInChildren<Indicator>().LimitTheMaximumRange;
        meshesList = new List<Func<float, Mesh>>();
        Array.ForEach(indicators, indicator => { meshesList.Add(indicator.UpdateMesh); });
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        if (meshesList.Count > 0) {
            Debug.Log("Count " + meshesList.Count);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Player")
            units.Add(other.GetComponent<PlayerUnitController>().PlayerUnit);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Player")
            units.Remove(other.GetComponent<PlayerUnitController>().PlayerUnit);
    }
    async UniTask UpdateMesh(Vector2 targetPosition, Vector2 casterPosition)
    {
        CombineInstance[] combiners = new CombineInstance[meshesList.Count];
        for (int i = 0; i < meshesList.Count; i++) {
            combiners[i].subMeshIndex = 0;
            combiners[i].mesh = meshesList[i]?.Invoke(func(targetPosition, casterPosition).magnitude);
            combiners[i].transform = filters[i].transform.localToWorldMatrix;
        }
        finalMesh.CombineMeshes(combiners);
        
        GetComponent<MeshFilter>().mesh = finalMesh;
        await UniTask.Yield();
    }
    public async UniTask ChangeTheRange(Vector2 targetPosition, Vector2 casterPosition,ChangeMeshType changeMeshType)
    {
        switch (changeMeshType) {
            case ChangeMeshType.Scalable:
                await UpdateMesh(targetPosition,casterPosition);
                break;
            case ChangeMeshType.Mobile:
                transform.position = indicators[0].LimitTheMaximumRange(targetPosition,casterPosition);
                break;
            case ChangeMeshType.Immutable:
                break;
        }
    }
}
public enum ChangeMeshType
{
    Scalable,
    Mobile,
    Immutable
}
//Quaternion OldRot = transform.rotation;
//Vector3 OldPos = transform.position;
//transform.rotation = Quaternion.identity;
//transform.position = Vector3.zero;
//if (filters[i].transform == transform)
//    continue;
//transform.rotation = OldRot;
//transform.position = OldPos;
//GetComponent<MeshCollider>().sharedMesh = finalMesh; 
