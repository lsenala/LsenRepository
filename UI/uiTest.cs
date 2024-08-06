using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class uiTest : MonoBehaviour 
{
 
    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    transform.Translate(0, 40f, 0);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    transform.Translate(0, -40f, 0);
        //}
        //gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, 0.04f);
        //gameObject.GetComponent<RectTransform>().offsetMax   += new Vector2(0f, 0.04f);
        //gameObject.GetComponent<RectTransform>().offsetMin  += new Vector2(0f, 0.04f);
        gameObject.GetComponent<RectTransform>().localPosition  += new Vector3(0f, 37.8f,0);
        Debug.Log("ÖáÐÄ×ø±ê"+gameObject.GetComponent<RectTransform>().anchoredPosition);
        Debug.Log("offsetMax"+gameObject.GetComponent<RectTransform>().offsetMax);
        Debug.Log("offsetMin" + gameObject.GetComponent<RectTransform>().offsetMin);
        Debug.Log("sizeDelta" + gameObject.GetComponent<RectTransform>().sizeDelta);
        Debug.Log("anchorMax" + gameObject.GetComponent<RectTransform>().anchorMax);
        Debug.Log("anchorMin" + gameObject.GetComponent<RectTransform>().anchorMin);
        Debug.Log("localPosition" + gameObject.GetComponent<RectTransform>().localPosition);
    }
    //9 43.5 86.5 129.5
}
