using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionPassed : MonoBehaviour
{
    public GameObject missionObject;
    public string missionPassed;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void MissionPass(string text)
    {
        StartCoroutine(MissionPassedDelay(text));
    }
    IEnumerator MissionPassedDelay(string missionText)
    {
        missionObject.SetActive(true);
        missionObject.GetComponentInChildren<Text>().color = Color.green; 
        // yield return new WaitForSeconds(1f);
        missionObject.GetComponentInChildren<Text>().text = missionText;
        yield return new WaitForSeconds(2f);
        missionObject.SetActive(false);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        MissionPass(missionPassed);
    }
}
