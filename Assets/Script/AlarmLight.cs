using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    Light alarmLight = null;
    private Vector3 rotation;
    [SerializeField] int Yspeed;
    void Start()
    {
        alarmLight = GetComponent<Light>();
        rotation = new Vector3(5, 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rotation.y += Yspeed * Time.deltaTime;
        alarmLight.transform.eulerAngles = rotation;
    }
}
