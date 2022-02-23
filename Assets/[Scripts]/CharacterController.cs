using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
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

    public readonly int movementSpeed = Animator.StringToHash("Speed");
    public readonly int jumpHash = Animator.StringToHash("isJumping");
    public readonly int groundedHash = Animator.StringToHash("isGrounded");
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
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

    private void Move()
    {
        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);
        moveDirection *= walkSpeed;
        if (rigidbody.velocity.magnitude < maxSpeed)
            rigidbody.AddForce(moveDirection);

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, 4.0f * Time.deltaTime, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);

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
}
