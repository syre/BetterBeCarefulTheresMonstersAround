using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Transform lineStart, groundedEnd;

    public float jumpingSpeed = 6f;

    public float movementSpeed = 2.5f;

    public float sprintSpeed = 4.5f;
    public float sprintPoolMax = 60f;
    public float sprintPoolMin = 15f;
    public float sprintLoss = 0.3f;
    public float sprintGain = 0.1f;
    public float sprintPoolCurrent = 0;
    public float sprintExhaustionPenalty = 10;

    public bool isExhausted = false;
    public bool isSprinting = false;

    private Rigidbody2D rigid;
    private Animator animator;
    private float scaleX;
    private Transform player;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprintPoolCurrent = sprintPoolMax;
        animator = GetComponent<Animator>();
        player = GetComponent<Transform>();
        scaleX = player.localScale.x;
        sprintPoolCurrent = sprintPoolMax;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, groundedEnd.position);

        if (Input.GetButton("Horizontal"))
        {
            //quick fix for now possible staying
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                player.localScale = new Vector3(Input.GetAxisRaw("Horizontal") * scaleX, player.localScale.y, player.localScale.z);
                if (Input.GetButton("Sprint"))
                {
                    if (isExhausted)
                    {
                        if (sprintPoolCurrent > sprintPoolMin)
                        {
                            isExhausted = false;
                        }
                    }
                    // start/continue sprinting --- && (isGrounded || isSprinting) == cannot start sprinting if not already sprinting, and in the air
                    if (sprintPoolCurrent > 0 && !isExhausted)//  && (isGrounded || isSprinting)) // not working ... ?
                    {
                        isSprinting = true;
                        rigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * sprintSpeed, rigid.velocity.y);
                        animator.SetBool("isSprinting", true);
                        animator.SetBool("isWalking", false);
                        sprintPoolCurrent -= sprintLoss;
                    }
                    // stop sprinting
                    else
                    {
                        isSprinting = false;
                        // penalize user for spending all sprint
                        if (!isExhausted && sprintPoolCurrent <= 0)
                        {
                            sprintPoolCurrent -= sprintExhaustionPenalty;
                        }
                        isExhausted = true;
                        rigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, rigid.velocity.y);
                        animator.SetBool("isSprinting", false);
                        animator.SetBool("isWalking", true);
                    }
                }
                else
                {
                    rigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, rigid.velocity.y);
                    animator.SetBool("isSprinting", false);
                    animator.SetBool("isWalking", true);
                }
            }
            else
            {
                animator.SetBool("isSprinting", false);
                animator.SetBool("isWalking", false);
            }

        }
        else
        {
            animator.SetBool("isSprinting", false);
            animator.SetBool("isWalking", false);
        }
        if (Input.GetButton("Jump"))
        {
            var isGrounded = Physics2D.Linecast(transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground"));
            if (isGrounded)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpingSpeed);
                animator.SetBool("isJumping", true);
            }
        }

        if (sprintPoolCurrent >= sprintPoolMax)
        {
            sprintPoolCurrent = sprintPoolMax;
        }
        else
        {
            sprintPoolCurrent += sprintGain;
        }
    }
}
