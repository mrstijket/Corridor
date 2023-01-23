using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaltaSaldırı : MonoBehaviour
{
    [SerializeField] GameObject baltaCollider;
    public Animator baltaAnim;
    [SerializeField] float colliderkapamasüresi;
    [SerializeField] ParticleSystem bloodEffect;
    public AudioSource baltaSes;
    public Camera myCam;
    bool hitOnce = true;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            baltaAnim.SetBool("baltaSaldir", true);
            StartCoroutine(BaltaColliderKapa());
            baltaCollider.SetActive(true);
            RaycastHit hit;
            if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit, 1f) && hitOnce)
            {
                if (hit.transform.gameObject.CompareTag("Enemy") || (hit.transform.gameObject.CompareTag("bossVucut")))
                {
                    StartCoroutine(HitOnceProcess());
                    Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
        }
        else
        {
            baltaAnim.SetBool("baltaSaldir", false);
        }

    }


    IEnumerator BaltaColliderKapa()
    {
        baltaSes.Play();
        yield return new WaitForSecondsRealtime(colliderkapamasüresi);
        baltaCollider.SetActive(false);
    }
    IEnumerator HitOnceProcess()
    {
        hitOnce = false;
        yield return new WaitForSeconds(1f);
        hitOnce = true;
    }
}
