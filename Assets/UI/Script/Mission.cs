using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    public GameObject missionObject;
    public string missionName;
    
    public void MissionStart()
    {
        StartCoroutine(MissionStartDelay(missionName));
    }
    IEnumerator MissionStartDelay(string missionText)
    {
        missionObject.SetActive(true);
        missionObject.GetComponentInChildren<Text>().text = missionText;
        yield return new WaitForSeconds(3f);
        missionObject.SetActive(false);
        Destroy(gameObject);
    }    


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player" )
        {
            Debug.Log("girdi");
            MissionStart();  
        }
    }
}
