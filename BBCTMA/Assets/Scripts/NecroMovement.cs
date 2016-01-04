using UnityEngine;
using System.Collections;

public class NecroMovement : MonoBehaviour
{

    public float movementSpeed = 5f;
    public float jumpingSpeed = 10f;
    public float sprintSpeed = 7;
    public float sprintPool = 100f;
    public float sprintLoss = 0.2f;
    public float sprintGain = 0.005f;

    private bool isgrounded;
    private float currentSprintPool;
    private Rigidbody2D rigid;
    private bool isInAir;
    private Animator animator;
    private float scaleX;
    private Transform player;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        currentSprintPool = sprintPool;
        isgrounded = false;
        animator = GetComponent<Animator>();
        player = GetComponent<Transform>();
        scaleX = player.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            player.localScale = new Vector3(Input.GetAxisRaw("Horizontal") * scaleX, player.localScale.y, player.localScale.z);
            if (Input.GetButton("Sprint"))
            {
                if (currentSprintPool >= sprintLoss)
                {
                    rigid.velocity = new Vector2(Input.GetAxis("Horizontal") * sprintSpeed, rigid.velocity.y);
                    animator.SetBool("isSprinting", true);
                    animator.SetBool("isWalking", false);
                    currentSprintPool -= sprintLoss;
                }
                else {
                    rigid.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rigid.velocity.y);
                    animator.SetBool("isSprinting", false);
                    animator.SetBool("isWalking", true);
                }
            }
            else {
                rigid.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rigid.velocity.y);
                animator.SetBool("isSprinting", false);
                animator.SetBool("isWalking", true);
            }
        }
        else {
            animator.SetBool("isSprinting", false);
            animator.SetBool("isWalking", false);
        }
        if (Input.GetButton("Jump"))
        {
           // if (isgrounded)
          //  {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpingSpeed);
                animator.SetBool("isJumping", true);
         //   }
        }

        if (currentSprintPool >= sprintPool)
        {
            currentSprintPool = sprintPool;
        }
        else {
            currentSprintPool += sprintGain;
        }

        if (Input.GetButton("Attack"))
        {
            animator.SetBool("isAttacking", true);
        }
        else {
            animator.SetBool("isAttacking", false);
        }
    }


    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.transform.tag == "Ground")
        {
            isgrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        if (collisionInfo.transform.tag == "Ground")
        {
            isgrounded = false;
        }
    }
}
