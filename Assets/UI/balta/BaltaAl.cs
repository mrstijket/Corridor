using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaltaAl : MonoBehaviour
{
    public GameObject balta;
    public GameObject FText;
    bool baltaAl�nabilir = false;
    bool isInHand=false;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (baltaAl�nabilir)
            {
                balta.SetActive(true);
                isInHand = true;
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag== "baltaal")
        {
            FText.SetActive(true);
            baltaAl�nabilir = true;
            if (isInHand)
            {
                FText.SetActive(false);
                Destroy(other.gameObject);
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        FText.SetActive(false);
        baltaAl�nabilir = false;
    }
}
