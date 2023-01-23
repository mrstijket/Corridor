using UnityEngine;

public class CanavarCan : MonoBehaviour
{
    float totalhealth = 100;
    float currenthealth;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = totalhealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "balta")
        {
            currenthealth -= 5;
        }
    }

    public void CanAzaltma(int azalmamiktari)
    {
        currenthealth -= azalmamiktari;
    }
}
