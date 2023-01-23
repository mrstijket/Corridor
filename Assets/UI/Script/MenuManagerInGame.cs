using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuManagerInGame : MonoBehaviour
{
    public static MenuManagerInGame instance;
    //public GunShooter mp5;
    //GunShooter gunShooter;
    public FirstPersonController fpsController;
    public GamePlayScript gamePlayScript;
    public AudioSource auido;
    public bool isPause = false;
    public GameObject inGameScreen, pauseScreen;
    [SerializeField] GameObject crosshair;
    
    void Start()
    {
        //gunShooter = mp5;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause == false)
            {
                auido.Pause();
                crosshair.SetActive(false);
               // gunShooter.canShoot = false;
                fpsController.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                isPause = true;
                Time.timeScale = 0;
                inGameScreen.SetActive(false);
                pauseScreen.SetActive(true);
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                //gunShooter.canShoot = true;
                transform.gameObject.SetActive(true);
                isPause = false;
                ResumeButton();
            }
        }
    }

    public void ResumeButton()
    {
        auido.UnPause();
        //gunShooter.canShoot = false;
        if (gamePlayScript.crosshairAvaliable)
        {
            crosshair.SetActive(true);
        }
        isPause = false;
        //Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fpsController.enabled = true;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        inGameScreen.SetActive(true);
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GizliODaGit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
}