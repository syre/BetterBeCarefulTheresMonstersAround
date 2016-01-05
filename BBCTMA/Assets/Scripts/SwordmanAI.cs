using UnityEngine;
using System.Collections;

public class SwordmanAI : MonoBehaviour {

    public bool goingLeft;
    public bool goingRight;
    private Animator animator;
    private Rigidbody2D rigid;
    private float scaleX;
    private Transform player;
    public float movementSpeed = 1f;

    // Use this for initialization
    void Start() {

        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GetComponent<Transform>();
        scaleX = player.localScale.x;

        goingRight = true;
        player.localScale = new Vector3(scaleX, player.localScale.y, player.localScale.z);
        rigid.velocity = new Vector2(1f * movementSpeed, rigid.velocity.y);
    }

    // Update is called once per frame
    void Update() {
        if (goingRight)
        {
            player.localScale = new Vector3(scaleX, player.localScale.y, player.localScale.z);
            rigid.velocity = new Vector2(1f * movementSpeed, rigid.velocity.y);
            animator.SetBool("isWalking", true);
        }
        else if (goingLeft)
        {
            player.localScale = new Vector3(-scaleX, player.localScale.y, player.localScale.z);
            rigid.velocity = new Vector2(-1f * movementSpeed, rigid.velocity.y);
            animator.SetBool("isWalking", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.transform.tag == "Wall")
        {
            if (goingRight)
            {
                goingLeft = true;
                goingRight = false;
            }
            else if (goingLeft)
            {
                goingLeft = false;
                goingRight = true;
            }
        }
    }
}
