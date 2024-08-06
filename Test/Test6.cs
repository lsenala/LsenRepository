using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;


public  class Test6: MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        
    }
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;  // 获取鼠标在屏幕上的位置
        Ray ray = cam.ScreenPointToRay(mousePosition);  // 将屏幕点转换为射线
        
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.black);
    }


}
