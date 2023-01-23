using UnityEngine;
using UnityEngine.AI;

public class ZombieHealth : MonoBehaviour
{
    public float health = 100;
    public float currenthealth;
    ZombiePlay zombiePlay;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        currenthealth = health;
        zombiePlay = GetComponent<ZombiePlay>();
    }
    void Update()
    {
        if (currenthealth <= 0)     
        {
            gameObject.GetComponent<Animator>().enabled = false;
            Destroy(gameObject.GetComponent<NavMeshAgent>());
            Destroy(gameObject.GetComponent<Rigidbody>());
            Destroy(gameObject.GetComponent<CapsuleCollider>());
            Destroy(gameObject,4f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("balta"))
        {
            currenthealth -= 20;
            
            if (currenthealth <= 0)
            {
                anim.enabled = false;
                zombiePlay.NavmeshPassive();
            }
        }
    }

    public void CanAzaltma(int azalmamiktari)
    {
        currenthealth -= azalmamiktari;
        Debug.Log(currenthealth);

        if (currenthealth <= 0)
        {
            anim.enabled=false;
            zombiePlay.NavmeshPassive();
        }
    }
}
