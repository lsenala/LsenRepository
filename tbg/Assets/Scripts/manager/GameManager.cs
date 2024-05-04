using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine;
using System;


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
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    public async Task SomeThing()
    {
        DemoUi demoUi = gameObject.AddComponent<DemoUi>();
        await Task.Run(() => demoUi.ChangBatteleScene());
        Debug.Log("123");      
        foreach (int unitID in UnitsID)
        {
            Debug.Log(unitID);
            dataBaseSO.UnitSpawn(unitID);
        }
        await Task.Yield();
        Debug.Log("456");
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
   
}
