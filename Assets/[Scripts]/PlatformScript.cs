using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public PickupColorType platformType;

    [SerializeField]
    GameObject[] pedestals;

    public int numHeldPickups = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterController>().currentActivePlatform = this;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterController>().currentActivePlatform = null;
        }
    }

    public void PlacePickup(ObjectivePickup pickup)
    {
        pickup.transform.parent = null;
        Vector3 temp = new Vector3(pedestals[numHeldPickups].transform.position.x, pedestals[numHeldPickups].transform.position.y + 3.0f, pedestals[numHeldPickups].transform.position.z);

        pickup.transform.position = temp;
        numHeldPickups++;
        GameManager.Instance.score++;
        if(numHeldPickups == 3)
        {
            GameManager.Instance.score += 3;
        }
    }
}
