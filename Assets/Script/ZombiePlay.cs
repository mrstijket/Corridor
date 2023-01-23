using UnityEngine;
using UnityEngine.AI;

public class ZombiePlay : MonoBehaviour
{
    GameObject target;
    NavMeshAgent agent;
    bool navmesactive=true;
    Canbari canbari;
    float dist;
    void Start()
    {
        canbari = FindObjectOfType<Canbari>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update()
    {
        if (navmesactive)
        {

            dist = Vector3.Distance(transform.position, target.transform.position);
            if (dist <= 2.5f)
            {
                if (canbari.isPlayerDead)
                {
                    Debug.Log(canbari.isPlayerDead);
                    gameObject.GetComponent<Animator>().SetBool("enemyATACK", false);
                    gameObject.GetComponent<Animator>().SetBool("enemyRUN", false);
                }
                else
                {
                    gameObject.GetComponent<Animator>().SetBool("enemyATACK", true);
                }
            }
            else if (dist <= 10f)
            {
                agent.destination = target.transform.position;
                gameObject.GetComponent<Animator>().SetBool("enemyRUN", true);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("enemyRUN", false);
                gameObject.GetComponent<Animator>().SetBool("enemyATACK", false);
            }
        }
    }
    public void HasarVer()
    {
        dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist <= 2.5f)
        {
            canbari.DecreaseHealth(5);
        }
    }
    public void NavmeshPassive()
    {
        navmesactive = false;
    }
}
