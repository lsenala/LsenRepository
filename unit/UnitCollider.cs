
using UnityEngine;

public class UnitCollider : MonoBehaviour
{
    [SerializeField] GameEvent LoadSceneEvent;
    public Unit unit;
    bool OnlyOne=false;
    //�ȸ��ǣ��ٷֿ�.�ֵ���ͬλ���ϣ��ٷֱ���ȡ������͵��˴������͵������ݵ�data�����Ƴ����˵�data
    public void OnTriggerEnter(Collider other)
    {      
        if (other.tag == "Enemy"&&gameObject.tag =="Enemy")
        {
            Debug.Log("����");
            OnlyOne = true;
            GameManager.Instance.AddID(other.gameObject.GetComponent<UnitCollider>().unit.UnitID);         
        }
        else if (gameObject.tag == "Player"&&other .tag =="Enemy")
        {
            Debug.Log("����");//û��������Ž���ֻ������
            GameManager.Instance.ChangeTeamMember(-1);
            GameManager.Instance.ChangeTeamMember(-2);
            GameManager.Instance.UnitsID.AddRange(GameManager.Instance.MemberID);   
            LoadSceneEvent.Raise();
            //OnCollideEvent.Raise();
        }
        else if (other.tag == "Player"&&OnlyOne==false)
        {
            Debug.Log("���");
            GameManager.Instance.AddID(gameObject.GetComponent<UnitCollider>().unit.UnitID);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("�����뿪��");
            GameManager.Instance.RemoveID(gameObject.GetComponent<UnitCollider>().unit.UnitID);
        }
    }
}
