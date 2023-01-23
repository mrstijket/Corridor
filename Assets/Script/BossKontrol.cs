using UnityEngine;
using UnityEngine.AI;

public class BossKontrol : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Animator animator;
    [SerializeField] GameObject _player;
    private float dist;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        dist = Vector3.Distance(transform.position, _player.transform.position);
        transform.LookAt(new Vector3(_player.transform.position.x,
            transform.position.y, _player.transform.position.z));

        if (dist <= 2.5f)
        {
            animator.SetBool("enemyATACK", true);
        }
        else if (dist > 2.5f)
        {
            agent.destination = _player.transform.position;
            animator.SetBool("enemyRUN", true);
            animator.SetBool("enemyATACK", false);
        }
    }
}
