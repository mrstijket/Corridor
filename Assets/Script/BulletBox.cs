using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBox : MonoBehaviour
{
    string[] Gun =
           {
           "Gun1",
           "Gun2",
           "Gun3",
           "Gun4"
            };
    int[] bulletCount =
    {
            20,
            25,
            30,
            35
        };
    string gunType;//sialh çeþidi
    public string producedGun;//oluþan mermi sayýsý
    public int producedBullet; //oluþan mermi sayýsý

    void Start()
    {
        producedGun = Gun[Random.Range(0,Gun.Length-1)];
        producedBullet = bulletCount[Random.Range(0, bulletCount.Length - 1)];

        producedGun ="Gun1";
        producedBullet = 30;


    }

    // Update is called once per frame
    void Update()
    {

    }

    
}
