using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AmmoCount : MonoBehaviour
{
    GunShooter gunShooter;
    public GameObject mp5;
    [SerializeField] GameObject reloadicon;
    public GameObject shotgun;

    void Start()
    {
        //gunShooter = mp5.GetComponent<GunShooter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gunShooter = mp5.GetComponent<GunShooter>();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gunShooter = shotgun.GetComponent<GunShooter>();
        }

        //if (Input.GetKeyDown("e"))
        //{
        //    TakeAmmo(MaxCapacity);
        //}
        //else if (Input.GetKeyDown("r"))
        //{
        //    Reload();
        //}
        //else if (Input.GetKeyDown("s"))
        //{
        //    DecreaseAmmo();
        //}
    }

    public void TakeAmmo(int bullet)
    {
        gunShooter.capacity += bullet;
        gunShooter.capacityText.text = gunShooter.capacity.ToString();
    }
    //public void DecreaseAmmo()
    //{
    //    gunShooter.remainingBullet--;
    //    if (Input.GetKey(KeyCode.Mouse0) && gunShooter.remainingBullet <= 0)
    //    {
    //        gunShooter.remainingBullet = 0;
    //      //  gunShooter.Anime();
    //        Reload();
    //    }
    //    gunShooter.remainingBulletText.text = gunShooter.remainingBullet.ToString();
    //}
    public void Reload()
    {
        if (gunShooter.capacity <= 0)
        {
            gunShooter.capacity = 0;
            return; 
        } 
        if(gunShooter.remainingBullet == gunShooter.magazineCapasity) { return; }
        StartCoroutine(ReloadDelay());
        reloadicon.SetActive(true);
    }
    IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(2f);
        reloadicon.SetActive(false);
        int spent = gunShooter.magazineCapasity - gunShooter.remainingBullet;
        gunShooter.capacity -= spent;
        if (gunShooter.capacity <= 0) { gunShooter.capacity = 0; }
        if (gunShooter.capacity + gunShooter.remainingBullet < gunShooter.magazineCapasity)
        { 
            gunShooter.remainingBullet = gunShooter.remainingBullet + gunShooter.capacity;
        }
        else
        {
            gunShooter.remainingBullet = gunShooter.magazineCapasity;
        }
        //gunShooter.capacityText.text = gunShooter.capacity.ToString();
        //gunShooter.remainingBulletText.text = gunShooter.remainingBullet.ToString();
    }
}