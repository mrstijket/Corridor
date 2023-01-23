using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Canbari : MonoBehaviour
{
    public static Canbari instance;
    public float health;
    [SerializeField] float maxHealth = 100;
    public Image canBari;
    public GameObject kalp;
    public Image deadScene;
    public Image bloodeffect;
    public Animator deathAnim;
    MenuManagerInGame gameInGame;
    public FirstPersonController fpsController;
    public GameObject[] guns;
    public bool isPlayerDead = false;

    void Start()
    {
        instance = this;
        health = maxHealth;
        gameInGame = FindObjectOfType<MenuManagerInGame>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DecreaseHealth(10);
        }
        canBari.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            kalp.GetComponent<Image>().color = Color.red;
            health = 0;
            DeathPlayer();
            fpsController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    IEnumerator HeartChange()
    {
        bloodeffect.gameObject.SetActive(true);
        kalp.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        bloodeffect.gameObject.SetActive(false);
        if (health > 0)
            kalp.GetComponent<Image>().color = Color.white;
    }
    public void DecreaseHealth(int value)
    {   
        if (health > 0)
        {
            health -= value;
            StartCoroutine(HeartChange());
        }
    }
    void DeathPlayer()
    {
        isPlayerDead = true;
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].gameObject.SetActive(false);
        }
        deadScene.gameObject.SetActive(true);
        deathAnim.Play("death");
        gameInGame.isPause = true;
      
    }
}