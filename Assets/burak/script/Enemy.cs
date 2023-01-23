using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    bool activeTarget=false;
    GameObject target_;
    int targetsIndex;
    float dist;
    SivilScript sivilSc;

    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (activeTarget == false)
        {
            GoTargets();
        }

        if (target_ != null)
        {
            agent.destination = target_.transform.position;
            transform.gameObject.GetComponent<Animator>().SetBool("enemyRUN", true);
        }

        if (target_ != null)
        {
            dist=Vector3.Distance(transform.position, target_.transform.position);
        }
        if (dist <= 1)
        {
            Attack();
        }
    }

    public void GoTargets()
    {
        sivilSc = GameManager.instance.targets[targetsIndex].GetComponent<SivilScript>();
        if (sivilSc.saldiriAltinda == false)
        {
            activeTarget = true;
            target_ = GameManager.instance.targets[targetsIndex];
            sivilSc.saldiriAltinda = true;
            targetsIndex++;
            if (targetsIndex >= GameManager.instance.targets.Length)
            {
                targetsIndex = 0;
            }
        }
        else {
            activeTarget = false;
            targetsIndex++;
            if(targetsIndex>= GameManager.instance.targets.Length)
            {
                targetsIndex = 0;
            }
        }
    }

    void Attack()
    {
        if (sivilSc.oldu==true)
        {
            activeTarget=false;
        }
    }
}
