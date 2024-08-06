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
        Vector3 mousePosition = Input.mousePosition;  // ��ȡ�������Ļ�ϵ�λ��
        Ray ray = cam.ScreenPointToRay(mousePosition);  // ����Ļ��ת��Ϊ����
        
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.black);
    }


}
