using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerMenuScene : MonoBehaviour
{


    public GameObject Loading;
    public GameObject gm1, gm2, gm3, gm4, gm5;
    
    public Slider yuklemeSlider;

    public void SahneYukle(int LevelId)
    {
        StartCoroutine(SahneYuklemeAsamasi(LevelId));
    }

    IEnumerator SahneYuklemeAsamasi(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
        Loading.SetActive(true);
        gm1.SetActive(false);
        gm2.SetActive(false);
        gm3.SetActive(false);
        gm4.SetActive(false);
        gm5.SetActive(false);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            yuklemeSlider.value = progress;
            Debug.Log("progress : " + progress);
            Debug.Log("operation progress : " + operation.progress);
            yield return null;
        }

    }

    //public void LoadGame()
    //{
    //    SceneManager.LoadScene(1);
    //}
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void CreditSceneOpen()
    {
        SceneManager.LoadScene(2);
    }
}
