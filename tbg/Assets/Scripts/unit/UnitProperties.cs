using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
interface ICollideInterface
{
    void OnTriggerEnter(Collider other);
    void OnTriggerExit(Collider other);
}
public class UnitProperties : MonoBehaviour,ICollideInterface
{
    [SerializeField] GameEvent LoadSceneEvent;
    [SerializeField] GameEvent OnCollideEvent;
    public  PlayerUnit playerUnit;//2选一
    public  EnemyUnit enemyUnit; //2选1
    bool OnlyOne=false;
    //先覆盖，再分开.分到不同位置上，再分别提取。如果和敌人触碰则发送敌人数据到data否则移除敌人的data
    public void OnTriggerEnter(Collider other)
    {      
        if (other.tag == "Enemy"&&gameObject.tag =="Enemy")
        {
            Debug.Log("敌人");
            OnlyOne = true;
            GameManager.Instance.AddID(other.gameObject.GetComponent<UnitProperties>().enemyUnit.unitID);         
        }
        else if (gameObject.tag == "Player"&&other .tag =="Enemy")
        {
            Debug.Log("触发");
            //GameManager.Instance.AddID(gameObject.GetComponent<UnitProperties>().playerUnit.unitID);
            //other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            //Destroy(other.gameObject);
            LoadSceneEvent.Raise();
            OnCollideEvent.Raise();
        }
        else if (other.tag == "Player"&&OnlyOne==false)
        {
            Debug.Log("玩家");
            GameManager.Instance.AddID(gameObject.GetComponent<UnitProperties>().enemyUnit.unitID);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("敌人离开了");
            GameManager.Instance.RemoveID(gameObject.GetComponent<UnitProperties>().enemyUnit.unitID);
        }
    }
}
