using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GunShooter : MonoBehaviour
{
    public bool shooterBool = true; //ates edebilir mi
    float shooterFrequency;  // ATES SIKLIGI
    public float shooterFrequencyOut; //Disardan deger gir.Ates sikligi
    public float Range;  //Silah menzili
    public Camera myCam;
    public AudioSource[] gunSound;
    public ParticleSystem[] gunEffect;
    public Image Scope;
    public Sprite on;
    public Sprite off;
    public Animator Gun;
    public int capacity;             //toplam kapasite 120
    public int remainingBullet = 30;   //kalan mermi
    public int magazineCapasity = 30;  //sarjörün kapasitesi
    public int silahHasar;

    public Text capacityText; //Toplam mermi text
    public Text remainingBulletText;  //kalan mermi text
    AmmoCount ammoCount;
    Canbari canbari;
    public bool canShoot = true;
    public bool isReloading = false;
    [SerializeField] GameObject reloadIcon;

    void Awake()
    {
        remainingBullet = magazineCapasity;

        ammoCount = FindObjectOfType<AmmoCount>();

        canbari = FindObjectOfType<Canbari>();
    }
    void Start()
    {
        remainingBulletText.text = remainingBullet.ToString();
        capacityText.text = capacity.ToString();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!canShoot)
        {
            Gun.SetBool("isFire", false);
            if (canbari.health != 0)
                Gun.SetBool("isAmmoOut", true);
        }
        else
        {
            Gun.SetBool("isAmmoOut", false);
        }
        if (Input.GetKey(KeyCode.Mouse0) && (remainingBullet <= 0))
        {
            Gun.SetBool("isAmmoOut", false);
            //shooterBool = false;
            Gun.SetBool("isFire", false);
            //StartCoroutine(ReloadGun());
        }
        if (this.gameObject.name=="Pompali" || this.gameObject.name=="Tabanca")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)&& shooterBool && Time.time > shooterFrequency && remainingBullet != 0)
            {
                Scope.GetComponent<Image>().sprite = on;
                Fire();
                shooterFrequency = Time.time + shooterFrequencyOut;
                Gun.SetBool("isFire", true);
            }
        }
        else
        {
            
            if (Input.GetKey(KeyCode.Mouse0) && shooterBool && Time.time > shooterFrequency && remainingBullet != 0) //ateþ
            {
                Scope.GetComponent<Image>().sprite = on;
                Fire();
                shooterFrequency = Time.time + shooterFrequencyOut;
                Gun.SetBool("isFire", true);
            }
        }
     

        if (Input.GetKeyUp(KeyCode.Mouse0)) //Scope
        {
            Scope.GetComponent<Image>().sprite = off;
            Gun.SetBool("isFire", false);
        }


        if (Input.GetKeyDown(KeyCode.R) && remainingBullet < magazineCapasity)
        {
            if (remainingBullet != magazineCapasity)
            {

                if (capacity <= 0)
                {
                    capacity = 0;
                    return;
                }
                //ammoCount.Reload();
                StartCoroutine(ReloadGun());
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            bulletGet();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        Destroy(other.transform.gameObject);
    }

    void Fire()
    {
        if (!canShoot) { return; }   //  4  6  15 11

        remainingBullet--;

        if (remainingBullet <= 0)
        {
            remainingBullet = 0;
            //ammoCount.Reload();
            if (capacity != 0)
                StartCoroutine(ReloadGun());
        }
        remainingBulletText.text = remainingBullet.ToString();
        RaycastHit hit;
        gunSound[0].Play();//Silah atis sesi
        gunEffect[0].Play(); //Silah patlama 



        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit, Range))
        {

            if (hit.transform.gameObject.CompareTag("Enemy") || hit.transform.gameObject.CompareTag("bossVucut"))
            {
                ZombieHealth zombiehealth = hit.transform.gameObject.GetComponent<ZombieHealth>();
                zombiehealth.CanAzaltma(silahHasar);
                Instantiate(gunEffect[2], hit.point, Quaternion.LookRotation(hit.normal));
            }
            else if (hit.transform.gameObject.CompareTag("Object"))
            {
                Rigidbody rg = hit.transform.gameObject.GetComponent<Rigidbody>();
                rg.AddForce(-hit.normal * 50f); //Objeyi mermi ile düsürme
                Instantiate(gunEffect[1], hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }

    IEnumerator ReloadGun()
    {
        isReloading = true;
        reloadIcon.SetActive(true);
        if (remainingBullet == 0)
        {
            if (capacity >= magazineCapasity)
            {
                capacity -= magazineCapasity;
                remainingBullet = magazineCapasity;
            }
            else
            {
                remainingBullet = capacity;
                capacity = 0;
            }
           

        }else if (remainingBullet > 0)
        {
            if(capacity>= magazineCapasity)
            {
                int fark = magazineCapasity - remainingBullet;
                capacity -= fark;
                remainingBullet += fark;
            }

            else
            {
                int fark = magazineCapasity - remainingBullet;

                if (fark > capacity)
                {
                    remainingBullet += capacity;
                    capacity = 0;
                }
                else
                {
                    remainingBullet += fark;
                    capacity -= fark;
                }
            }
        }
        remainingBulletText.text = remainingBullet.ToString();
        capacityText.text = capacity.ToString();

        //int spent = magazineCapasity - remainingBullet;
        ////remainingBullet = magazineCapasity;
        //capacity -= spent;
        //if (capacity <= 0) { capacity = 0; }
        //if (capacity + remainingBullet < magazineCapasity) { remainingBullet = magazineCapasity - (remainingBullet + capacity); }
        gunSound[1].Play();
        canShoot = false;
        //remainingBulletText.text = remainingBullet.ToString();
        capacityText.text = capacity.ToString();
        Gun.SetBool("isAmmoOut", true);
        yield return new WaitForSeconds(2f);
        Gun.SetBool("isAmmoOut", false);
        canShoot = true;
        reloadIcon.SetActive(false);
        isReloading = false;
    }
    void bulletGet()
    {
        RaycastHit hit;
        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit, 4))
        {
            if (hit.transform.gameObject.CompareTag("bullet"))
            {
                ammoCount.TakeAmmo(magazineCapasity);
                //bulletSave(hit.transform.gameObject.GetComponent<BulletBox>().producedGun, hit.transform.gameObject.GetComponent<BulletBox>().producedBullet);
                Destroy(hit.transform.gameObject);
            }
        }

    }
    public void bulletchange()
    {
        remainingBulletText.text = remainingBullet.ToString();
        capacityText.text = capacity.ToString();
        //if(remainingBullet>0)
        // canShoot = true;
    }
}
