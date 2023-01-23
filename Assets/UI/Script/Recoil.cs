using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{

    public float minX, maxX, minY, maxY;
    public Transform kamera;
    Vector3 Rot;

    void Start()
    {

    }


    void Update()
    {
        Rot = kamera.transform.localRotation.eulerAngles;
        if (Rot.x != 0 || Rot.y != 0)
        {
            kamera.transform.localRotation = Quaternion.Slerp(kamera.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 3);
        }
            
    }



    private void recoil()
    {
        float recoilX = Random.Range(minX, maxX);
        float recoilY = Random.Range(minY, maxY);
        kamera.transform.localRotation = Quaternion.Euler(Rot.x - recoilY, Rot.y + recoilX, Rot.z);
    }

}
