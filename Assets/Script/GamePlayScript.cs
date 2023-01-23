using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GamePlayScript : MonoBehaviour
{
    #region Kol ve Silahlar
    [SerializeField] GameObject kolBalta;
    [SerializeField] GameObject kolMp5;
    [SerializeField] GameObject mermiGosterge;
    [SerializeField] GameObject kolPompa;
    #endregion

    public GameObject pressF;
    [SerializeField] GameObject crosshair;
    [SerializeField] GameObject kovEnemy;
    public bool crosshairAvaliable;
    GunShooter gunShooter;
    //[SerializeField] GameObject bulletUI;

    public bool mp5envanterde = false;
    public bool baltaenvanterde = false;
    public bool pompaEnvanterde= false;
    string mp5;
    int mp5varmi;
    string pompa;
    int pompavarmi;
    string balta;
    int baltavarmi;

    void Start()
    {
        mermiGosterge.SetActive(false);
        crosshairAvaliable=false;
        mp5varmi = PlayerPrefs.GetInt(mp5);
        pompavarmi = PlayerPrefs.GetInt(pompa);
        baltavarmi=PlayerPrefs.GetInt(balta);
        if (mp5varmi == 1)
        {
            mp5envanterde = true;
        }
        if (pompavarmi == 1)
        {
            pompaEnvanterde = true;
        }
        if (baltavarmi == 1)
        {
            baltaenvanterde = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Alpha2) && kolBalta.activeInHierarchy)
        //{

        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha3) && kolBalta.activeInHierarchy)
        //{

        //}
        gunShooter = FindObjectOfType<GunShooter>();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (baltaenvanterde)
            {
                if(gunShooter.isReloading == false)
                {
                    BaltaActive();
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (mp5envanterde)
            {
                if (kolBalta.activeInHierarchy)
                {
                    Mp5Active();
                }
                if(gunShooter.isReloading == false)
                {
                    Mp5Active();
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (pompaEnvanterde)
            {
                if (kolBalta.activeInHierarchy)
                {
                    PompaliActive();
                }
                if(gunShooter.isReloading == false)
                {
                    PompaliActive();
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag== "baltaal")
        {
            pressF.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                pressF.SetActive(false);
                crosshairAvaliable = true;
                crosshair.SetActive(true);
                Destroy(other.gameObject);
                BaltaActive();
         
                baltaenvanterde = true;
                PlayerPrefs.SetInt(balta, 1);
            }
        }

        else if (other.gameObject.tag == "mp5al")
        {
            pressF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                Mp5Active();
                pressF.SetActive(false);
                //bulletUI.SetActive(true);
                mp5envanterde = true;
                Destroy(other.gameObject);

                PlayerPrefs.SetInt(mp5, 1);
            }
        }

        //else if (other.gameObject.tag == "teleport")
        //{
        //    //TODO zombiler ölmeden açma
        //    pressF.SetActive(true);

        //    if (Input.GetKeyDown(KeyCode.F))
        //    {
        //        this.enabled = false;
        //        transform.position = Vector3.Slerp(transform.position, teleportingPoint.position, 1000 * Time.deltaTime);
        //        //MenuManagerInGame.instance.GizliODaGit();

        //    }

        //}

        else if (other.gameObject.tag == "pompaAl")
        {
            pressF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                PompaliActive();
                pressF.SetActive(false);
                //bulletUI.SetActive(true);
                pompaEnvanterde = true;
                Destroy(other.gameObject);
                PlayerPrefs.SetInt(pompa, 1);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "boss")
        {
            Canbari.instance.DecreaseHealth(10);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pressF.SetActive(false);
    }

    void BaltaActive()
    {
        GorevYonetici.instance.Gorev2();
        kolMp5.SetActive(false);
        kolBalta.SetActive(true);
        mermiGosterge.SetActive(false);
        kolPompa.SetActive(false);
    }

    void Mp5Active()
    {
        GunShooter gunshooter = kolMp5.GetComponent<GunShooter>();
        gunshooter.bulletchange();
        kolBalta.SetActive(false);
        kolPompa.SetActive(false);
        kolMp5.SetActive(true);
        mermiGosterge.SetActive(true);        
    }

    void PompaliActive()
    {
        GunShooter gunshooter = kolPompa.GetComponent<GunShooter>();
        gunshooter.bulletchange();
        kolBalta.SetActive(false);
        kolMp5.SetActive(false);
        kolPompa.SetActive(true);
        mermiGosterge.SetActive(true);
    }
}
