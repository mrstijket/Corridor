using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GorevYonetici : MonoBehaviour
{
    public static GorevYonetici instance;
    [SerializeField] GameObject missionPanel;
    [SerializeField] Text missionText;
   
    string gorev1 = "Pick Up the Axe";
    string gorev2 = "Kill monster that after you";
    string gorev3 = "Find Other Guns, Survive and Find a Way to VR Room";

    // Start is called before the first frame update
    void Start()
    {
        instance= this; 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GorevBir()
    {
        missionPanel.SetActive(true);
        missionText.text = gorev1.ToString();
    }

    public void Gorev2()
    {
        missionPanel.SetActive(true);
        missionText.text = gorev2.ToString();
        StartCoroutine(SetFalse());
    }
    IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(7f);
        missionPanel.SetActive(false);
    }
    //public void Gorev3()
    //{
    //    missionPanel.SetActive(true);
    //    missionText.text = gorev3.ToString();

    //}

}
