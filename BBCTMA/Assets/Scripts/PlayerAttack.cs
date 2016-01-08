using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    public float attackTimer = 0f;
    public float attackWaitTime = 1.5f;
	public GameObject projectile;
	private Animator playerAnimator;

	// Use this for initialization
	void Start () {

        playerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        attackTimer += Time.deltaTime;

        if (Input.GetButton ("Attack"))
        {
            if (attackTimer > attackWaitTime)
            {
                attackTimer = 0f;
                performAttack();
                playerAnimator.SetBool ("isAttacking", true);
            }

        }
        else 
        {
            playerAnimator.SetBool ("isAttacking", false);
        }

    }
   
    void performAttack()
   {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        var mouseDirection = (mousePos - transform.position).normalized;
        var projectileCopy = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;

        var flightScript = projectileCopy.GetComponent<ProjectileFlight>();
        flightScript.velocity = 10f;
        flightScript.direction = mouseDirection;
        Destroy(projectileCopy, 10);
   }
     
}
