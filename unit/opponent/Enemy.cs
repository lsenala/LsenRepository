using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "Enemy", menuName = "Unit/Enemy")]
public class Enemy :ScriptableObject 
{
    [SerializeField] float HP,MP,EnemySpeed,Damage, EnemyAtkRcvy, SCraftRcvy , EnemyInitAt, EnemyCurAt,State;
    public string enemyName;
    public int EnemyID;
    //�ӱ�ʵ��û��˼��������ƹ�
    //��������ATר��������Ӳֱ���룿�����ɻ�λ�����Ժ���ͨAT����ͬʱ���
    //�ƶ����ض�AT˳��������ж�,���˼�����λ�����ж����ٴΣ�Ӳֱ�ۼӣ�
    //ɾ��AT��������֮AT����
    //������Χ�����AT����

}
