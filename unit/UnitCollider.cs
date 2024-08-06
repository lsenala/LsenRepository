
using UnityEngine;

public class UnitCollider : MonoBehaviour
{
    [SerializeField] GameEvent LoadSceneEvent;
    public Unit unit;
    bool OnlyOne=false;
    //先覆盖，再分开.分到不同位置上，再分别提取。如果和敌人触碰则发送敌人数据到data否则移除敌人的data
    public void OnTriggerEnter(Collider other)
    {      
        if (other.tag == "Enemy"&&gameObject.tag =="Enemy")
        {
            Debug.Log("敌人");
            OnlyOne = true;
            GameManager.Instance.AddID(other.gameObject.GetComponent<UnitCollider>().unit.UnitID);         
        }
        else if (gameObject.tag == "Player"&&other .tag =="Enemy")
        {
            Debug.Log("触发");//没做队伍编排界面只能这样
            GameManager.Instance.ChangeTeamMember(-1);
            GameManager.Instance.ChangeTeamMember(-2);
            GameManager.Instance.UnitsID.AddRange(GameManager.Instance.MemberID);   
            LoadSceneEvent.Raise();
            //OnCollideEvent.Raise();
        }
        else if (other.tag == "Player"&&OnlyOne==false)
        {
            Debug.Log("玩家");
            GameManager.Instance.AddID(gameObject.GetComponent<UnitCollider>().unit.UnitID);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("敌人离开了");
            GameManager.Instance.RemoveID(gameObject.GetComponent<UnitCollider>().unit.UnitID);
        }
    }
}
