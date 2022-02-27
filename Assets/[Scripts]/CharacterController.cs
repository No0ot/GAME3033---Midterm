using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public PlatformScript currentActivePlatform;

    [SerializeField]
    float walkSpeed = 3;
    [SerializeField]
    float maxSpeed = 6;
    [SerializeField]
    float jumpForce = 2;

    Rigidbody rigidbody;
    Animator animator;
    [SerializeField]
    bool isGrounded;

    Vector2 inputVector = Vector2.zero;
    Vector3 respawnLocation;

    public readonly int movementSpeed = Animator.StringToHash("Speed");
    public readonly int jumpHash = Animator.StringToHash("isJumping");
    public readonly int groundedHash = Animator.StringToHash("isGrounded");
    public readonly int carryingHash = Animator.StringToHash("isCarrying");

    [SerializeField]
    GameObject handSocket;

    ObjectivePickup heldObject;
    GameObject inRangePickup;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        respawnLocation = transform.position;
    }

    private void Update()
    {
         Move();
    }

    public void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (isGrounded)
        {
            isGrounded = false;
            rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            animator.SetBool(groundedHash, false);
            animator.SetBool(jumpHash, true);
        }
    }

    public void OnPickup(InputValue value)
    {
        if(inRangePickup && !heldObject)
        {
            heldObject = inRangePickup.GetComponent<ObjectivePickup>();
            heldObject.transform.parent = handSocket.transform;
            heldObject.transform.position = handSocket.transform.position;
            animator.SetBool(carryingHash, true);
        }
        else if(heldObject)
        {
            if (isGrounded)
            {
                if (currentActivePlatform && currentActivePlatform.platformType == heldObject.type)
                {
                    currentActivePlatform.PlacePickup(heldObject);
                }
                else
                    heldObject.transform.parent = null;

                animator.SetBool(carryingHash, false);
                heldObject = null;
                inRangePickup = null;
            }
        }
    }

    private void Move()
    {
        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);
        moveDirection.Normalize();

        if (rigidbody.velocity.magnitude < maxSpeed)
            rigidbody.AddForce(moveDirection * walkSpeed);

        if(moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720.0f * Time.deltaTime);
        }

        animator.SetFloat(movementSpeed, rigidbody.velocity.magnitude);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            animator.SetBool(groundedHash, true);
            animator.SetBool(jumpHash, false);
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Objective"))
        {
            inRangePickup = other.gameObject;
            //animator.SetBool(carryingHash, true);
            //ObjectivePickup temp = other.GetComponent<ObjectivePickup>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Objective"))
        {
            inRangePickup = null;
            //animator.SetBool(carryingHash, true);
            //ObjectivePickup temp = other.GetComponent<ObjectivePickup>();
        }
    }

    public void Respawn()
    {
        transform.position = respawnLocation;
    }
}
