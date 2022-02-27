using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupColorType
{
    BLUE,
    RED,
    GREEN,
    YELLOW
}

public class ObjectivePickup : MonoBehaviour
{
    public PickupColorType type;
    bool canPickup;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canPickup = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickup = false;
        }
    }
}
