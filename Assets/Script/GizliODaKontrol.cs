using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GizliODaKontrol : MonoBehaviour
{
    [SerializeField ] GamePlayScript gamePlayScript;
    [SerializeField] Animator boss;
    [SerializeField] GameObject missionBG;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.enabled == false)
        {
            StartCoroutine(LoadSceneDelay());
        }
    }
    IEnumerator LoadSceneDelay()
    {
        missionBG.SetActive(true);
        yield return new WaitForSeconds(5);
        missionBG.SetActive(false);
        SceneManager.LoadScene("Credits");
    }
}
