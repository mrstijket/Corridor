using System.Collections;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;

    void Start()
    {  
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i <= 27; i++)
        {
            Instantiate(enemy, spawnPoints[i].position, Quaternion.identity);

            yield return new WaitForSeconds(3f);

        }
    }
}
