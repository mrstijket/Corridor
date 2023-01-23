using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject enemy;
    public Transform[] enemy_SpawnPoint;
    
    float dist;
    public GameObject[] targets;
    int targetsIndex;
    public GameObject availableTarget;

    void Start()
    {
        instance = this;
        int i = 0;
        if (i<28)
        {
            StartCoroutine(enemySPAWN(i));
            i++;
        }

        
    }

    IEnumerator enemySPAWN(int index)
    {
        yield return new WaitForSeconds(8f);
        for (int i = 0; i < 20; i++)
        {
            Instantiate(enemy, enemy_SpawnPoint[UnityEngine.Random.Range(0, 2)].position, Quaternion.identity);
            

            yield return new WaitForSeconds(.5f);
            
        }
    }

   





    /*public GameObject[] civilianFemale;
    public Transform[] runPoints;
    public GameObject[] enemy;
    [SerializeField] GameObject itsMe;
    GameObject doorObj;

    float targetDist;

    bool run;
    bool outDoor_Bol;


    void Start()
    {
        Invoke("delayGO", 3.6f);
        doorObj = GameObject.FindGameObjectWithTag("outDoor");
    }
    void Update()
    {
        outDoor_Bol = doorObj.gameObject.GetComponent<forOutDoor>().outDoor_Boolean;

        int i = 0;
        while (i <= (civilianFemale.Length - 1) && !outDoor_Bol)
        {  
            Move(i);
            i++;
        }

        if (outDoor_Bol)
        {
            outDoor();
        }
    }
    void Move(int index)
    {
        if (run)
        {
            civilianFemale[index].gameObject.GetComponent<Animator>().SetBool("run", true);
            
            Vector3 vek = Vector3.MoveTowards(civilianFemale[index].transform.position, runPoints[index].position, Time.deltaTime * 6f);
            civilianFemale[index].gameObject.GetComponent<Rigidbody>().MovePosition(vek);   
            civilianFemale[index].transform.LookAt(runPoints[index].transform);
        }

        enemy[index].gameObject.GetComponent<Animator>().SetBool("zomb_Run", true);
        Vector3 vekE = Vector3.MoveTowards(enemy[index].transform.position, civilianFemale[index].transform.position, Time.deltaTime * 6.5f);
        enemy[index].gameObject.GetComponent<Rigidbody>().MovePosition(vekE);
        float dist = Vector3.Distance(enemy[index].transform.position, civilianFemale[index].transform.position);

        if (dist <= 1.9f)
        {
            enemy[index].gameObject.GetComponent<Animator>().SetBool("attack", true);
        }
        if (dist <= 1.5f)
        {
            civilianFemale[index].gameObject.GetComponent<Animator>().enabled = false;
        }

        if (dist >= .7f)
        {
            enemy[index].transform.LookAt(civilianFemale[index].transform);
        }
    }
    void delayGO()
    {
        run = true;
    }
    */
    /*void outDoor()
    {
        for (int j = 0; j < enemy.Length; j++)
        {
            enemy[j].gameObject.GetComponent<NavMeshAgent>().enabled = true;
            enemy[j].gameObject.GetComponent<CapsuleCollider>().enabled = true;
            enemy[j].gameObject.GetComponent<Animator>().SetBool("attack", false);

            for (int i = 2; i < enemy.Length; i++)
            {
                enemy[i].gameObject.SetActive(false);
            }

            for (int k = 0; k < 2; k++)
            {
                targetDist = Vector3.Distance(enemy[k].gameObject.transform.position, itsMe.transform.position);


                if (targetDist <= 10)
                {
                    enemy[k].gameObject.GetComponent<Animator>().SetBool("zomb_Run", true);
                    Vector3 moveTo = Vector3.MoveTowards(enemy[k].transform.position, itsMe.transform.position, Time.deltaTime * 100f);
                    enemy[k].gameObject.GetComponent<NavMeshAgent>().destination = moveTo;
                }
            }   
        }
    }*/
}
