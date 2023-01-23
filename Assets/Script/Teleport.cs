using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform teleportingPoint;
    public FirstPersonController fpsController;
    [SerializeField] GamePlayScript gamePlayScript;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //TODO zombiler ölmeden açma
            gamePlayScript.pressF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                //fpsController.enabled = false;
                //transform.position = Vector3.Slerp(transform.position, teleportingPoint.position, 1000 * Time.deltaTime);
                //fpsController.enabled = true;
                MenuManagerInGame.instance.GizliODaGit();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        gamePlayScript.pressF.SetActive(false);
    }
}
