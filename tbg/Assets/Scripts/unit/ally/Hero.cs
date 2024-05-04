using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//public class Hero :UnitAbility 
//{
//    [SerializeField] GameEvent LoadSceneEvent;
//    [SerializeField] GameEvent OnCollideEvent;
//    [SerializeField] PlayerUnit playerUnit;
//    public void OnTriggerEnter(Collider other)
//    {
//        if (other.tag == "Enemy")
//        {
//            Debug.Log("触发");
//            GameManager.Instance.AddID(gameObject.GetComponent<Hero>().playerUnit.unitID);
//            //other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
//            //Destroy(other.gameObject);
//            LoadSceneEvent.Raise();
//            OnCollideEvent.Raise();            
//        }
//    }
//    public override void Craft()
//    {
//        throw new NotImplementedException();
//    }
//    public override void Incantation()
//    {
//        throw new NotImplementedException();
//    }
//    //主角行动n次硬直累加
//    public override void SCraft()
//    {
//        throw new NotImplementedException();
//    }
//}
