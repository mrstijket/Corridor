using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulb_light : MonoBehaviour
{
    public bool yananisik = false;
    public float timeDelay;

    void Update()
    {
        if (yananisik == false)
        {
            StartCoroutine(randomisik());
        }

    }
    IEnumerator randomisik()
    {
        yananisik = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, 0.3f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        yananisik = false;

    }
}
