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

    MeshRenderer mesh;

    public Material[] materials;

    
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        platformLife = timeBeforeFall;
        transform.localScale = new Vector3(transform.localScale.x, Random.Range(1.0f, 2.0f), transform.localScale.z);
        mesh = GetComponent<MeshRenderer>();
        mesh.material = materials[Random.Range(0, 4)];
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
