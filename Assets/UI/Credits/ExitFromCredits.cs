using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFromCredits : MonoBehaviour
{
    [SerializeField] MenuManagerMenuScene menuScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menuScene.LoadMenu();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        StartCoroutine(LoadAutomatically());
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    IEnumerator LoadAutomatically()
    {
        yield return new WaitForSeconds(34.5f);
        menuScene.LoadMenu();
    }
}
