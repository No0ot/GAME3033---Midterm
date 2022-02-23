using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour
{
    [SerializeField]
    float timeBeforeFall;
    [SerializeField]
    float platformLife;

    Rigidbody rigidbody;

    bool isTouching;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        platformLife = timeBeforeFall;
    }

    // Update is called once per frame
    void Update()
    {
        if(platformLife <= 0)
        {
            rigidbody.useGravity = true;
            rigidbody.isKinematic = false;
        }
        
        if(isTouching)
        {
            platformLife -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isTouching = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouching = false;
        }
    }
}
