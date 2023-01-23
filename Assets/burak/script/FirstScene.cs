using UnityEngine;
using UnityEngine.AI;

public class FirstScene : MonoBehaviour
{
    public GameObject[] civilian_W;
    public GameObject[] civilian;
    public Transform[] runPoints_W;
    public Transform[] runPoints_W2;
    public Transform[] runPoints;
    public GameObject[] die_Civilian;
    NavMeshAgent agent, agent1, enemy_agent;


    public GameObject[] enemy;
    public GameObject enemyRunner;
    public Transform pointForEnemyRunner;

    public GameObject fpsController;
    public GameObject canbari;
    public GameObject forGameControl;

    public GameObject kov_enemy;
    public GameObject[] civil_Sit;
    public bool girisEkranı = true;

    private void FirstPoint(int index)
    {
        if (girisEkranı)
        {
            for (int i = 0; i < index; i++)
            {
                agent = civilian_W[i].gameObject.GetComponent<NavMeshAgent>();
                agent.destination = runPoints_W[i].position;
            } //ilk 6 hareket etti.
        }
        
            
    }
    
    private void Idle(int index)
    {
        if (girisEkranı)
        {
            for (int i = 0; i < index; i++)
            {
                agent = civilian_W[i].gameObject.GetComponent<NavMeshAgent>();
                agent.speed = 3.5f;
                civilian_W[i].gameObject.GetComponent<Animator>().SetBool("forIdle", true);
            }
        }//ilk 6 gitti ve idle a girdi. 
    }

    private void Run1(int index)
    {
        if (girisEkranı)
        {
            for (int i = 0; i < index; i++)
            {
                agent1 = civilian[i].gameObject.GetComponent<NavMeshAgent>();
                agent1.destination = runPoints[i].position;
                civilian[i].gameObject.GetComponent<Animator>().SetBool("runWalker", true);

            }
        }
    }//diğer 21  hedefe hareket run;

    private void Run2(int index2)
    {
        if (girisEkranı)
        {
            for (int i = 0; i < index2; i++)
            {

                agent = civilian_W[i].gameObject.GetComponent<NavMeshAgent>();
                agent.destination = runPoints_W2[i].position;
                civilian_W[i].gameObject.GetComponent<Animator>().SetBool("runWalker", true);

            }

        }
        
    }//ilk 6 ikinci noktaya run

    private void Enemy1(int index)
    {
        if (girisEkranı)
        {
            for (int i = 0; i < index; i++)
            {
                enemy_agent = enemy[i].gameObject.GetComponent<NavMeshAgent>();
                enemy_agent.destination = civilian[i].transform.position;

            }
        }
        
    } // 6 zombie, ilk 6 sivile gidecek.

    private void Enemy2(int index)
    {
        if (girisEkranı)
        {
            for (int i = 0; i < index; i++)
            {
                enemy_agent = enemy[i].gameObject.GetComponent<NavMeshAgent>();
                enemy_agent.destination = civilian_W[i].transform.position;
            }
        }
    }

    private void LastEnemy()
    {
        enemyRunner.gameObject.SetActive(true);
        enemyRunner.gameObject.GetComponent<Animator>().SetBool("enemyRUN", true);
        enemyRunner.gameObject.GetComponent<NavMeshAgent>().destination = pointForEnemyRunner.position;
    }

    private void EnableFPS()
    {
        fpsController.SetActive(true);
        canbari.SetActive(true);
    }

    private void DestroyedZombie()
    {
        girisEkranı = false;
        GameObject[] forEnemyDestroy = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < forEnemyDestroy.Length; i++)
        {
            Destroy(forEnemyDestroy[i]);
        }

        for (int i = 0; i < civilian_W.Length; i++)
        {
            civilian_W[i].gameObject.GetComponent<Animator>().Play("idle");
            civilian_W[i].gameObject.GetComponent<Animator>().enabled = false;
            civilian_W[i].gameObject.GetComponent<NavMeshAgent>().enabled = false;

        }

        for (int i = 0; i < civilian.Length; i++)
        {
            civilian[i].gameObject.GetComponent<Animator>().Play("idle");
            civilian[i].gameObject.GetComponent<Animator>().enabled = false;
            civilian[i].gameObject.GetComponent<NavMeshAgent>().enabled = false;
        }

        for (int i = 0; i < die_Civilian.Length; i++)
        {
            die_Civilian[i].gameObject.GetComponent<Animator>().enabled = false;
        }
        //GameObject[] civil_Sit = GameObject.FindGameObjectsWithTag("Civilian");

        for (int i = 0; i < civil_Sit.Length; i++)
        {
            Destroy(civil_Sit[i]);
        }
    }

    private void GamePlay()
    {
        forGameControl.SetActive(true);
        GorevYonetici.instance.GorevBir();
    }
    
    private void KovEnemy()
    {
        kov_enemy.gameObject.SetActive(true);
        kov_enemy.gameObject.GetComponent<Animator>().SetBool("enemyRUN", true);
        kov_enemy.gameObject.GetComponent<NavMeshAgent>().destination = fpsController.transform.position;
        Destroy(gameObject);
    }
}
