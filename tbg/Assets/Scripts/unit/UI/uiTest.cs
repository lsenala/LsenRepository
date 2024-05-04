using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class uiTest : MonoBehaviour 
{
 
    public void Update()
    {    
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0, 40f, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(0, -40f, 0);
        }
    }

}
