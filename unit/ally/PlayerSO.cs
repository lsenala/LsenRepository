using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player", menuName = "Unit/Player")]
public class PlayerSO : ScriptableObject 
{
    public string PlayerName;
    public int PlayerID;
    public int PlayerSpeed;
    [SerializeField] int AtkRcvy,CraftRcvy,SCraftRcvy;
    [SerializeField] int HP,MP,CP,SBoost,InitAT, Delay, CurAT;
    [SerializeField] DataBaseSO dataBaseSO;
    void Start()
    {
         //�����ʼAT ս����ʼʱ��ҷ���ս���¼���GM����AT����
         InitAT = 1000 / PlayerSpeed;
        //������
    }
    //��ͨ�����ж�����CP��ã�����Ӳֱ��
    void Attack()
    {
        int AttackDamage = 20;
        CP += 15;
        Delay = 100 * AtkRcvy / PlayerSpeed;
    }
    //����������0��ħ��SBoost��ã�Ҫ���CP����
    void BasicMagic()
    {
        int BasicMagicDamage = 30;
        SBoost += 20;
    }
    //SBoost��buffЧ��������0ӽ����ս����S��Ӳֱ����ظ�����
    void SBoostBuff()
    {
        
    }
    //ս��������Ҫ����λAT������ս�� ����urahayaku  S�����
    //ħ����ӽ�� ʩ����
    void Magic(string MagicName)
    {
        

    }
    void Update()
    {
        CurAT = InitAT + Delay;
    }
}
