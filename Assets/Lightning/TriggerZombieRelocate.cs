using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZombieRelocate : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Zombiler yerlerine gönderildi.");
            Destroy(gameObject);
        }
    }
}
