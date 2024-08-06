
using UnityEngine;

public class UnitCamera : MonoBehaviour
{
    //�����������߶�
    float m_Height = 5f;
    //��������������
    float m_Distance = 5f;
    //��������ٶ�
    float m_Speed = 4f;
    //Ŀ��λ��
    Vector3 m_TargetPosition;
    //Ҫ���������
    public Transform follow;  
    // Use this for initialization
    private void Start()
    {   
         AttachToPlayer();
    }
    void AttachToPlayer()
    {
        follow = UnityEngine.GameObject.FindWithTag ("Player").transform;//UnassignReferenceException
    }
    // Update is called once per frame
    //���ƽ���ĸ��������ƶ�
    void Update()
    {
        //�õ����Ŀ��λ��
        m_TargetPosition = follow.position + Vector3.up * m_Height - follow.forward * m_Distance;
        //���λ��
        transform.position = Vector3.Lerp(transform.position, m_TargetPosition, m_Speed * Time.deltaTime);
        //���ʱ�̿�������
        transform.LookAt(follow);
    }
    
}

