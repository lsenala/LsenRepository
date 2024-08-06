
using System;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{  
    [SerializeField] DataBaseSO dataBaseSO;
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        UnityEngine.GameObject.DontDestroyOnLoad(this.gameObject);
    }
    public void SomeThing()
    {
        UnitsID.ForEach(id => Debug.Log(id));
        foreach (int unitID in UnitsID)
        {
            dataBaseSO.UnitSpawn(unitID);
        }      
    }
    public List<int> UnitsID = new List<int>();/////    
    public void AddID(int UnitID)
    {
        UnitsID.Add(UnitID);
    }
    public void RemoveID(int UnitID)
    {
        UnitsID.Remove (UnitID);
    }
    public List<int> MemberID = new List<int>();
    public void ChangeTeamMember(int PlayerID)
    {
        if (!MemberID.Contains(PlayerID)) {
            MemberID.Add(PlayerID);
        }

    }
   
}
