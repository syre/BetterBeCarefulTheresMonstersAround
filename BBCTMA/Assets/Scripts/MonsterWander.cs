using UnityEngine;
using System.Collections;

public class MonsterWander : MonoBehaviour {
	public float movementSpeed = 3f;
	public Transform target;
    public Vector2 resetPosition = new Vector2(10f, 10f);
    public Transform[] waypoints;

    private float direction = 1f;
    private Animator animator;
    private MonsterSight sight;
    private Rigidbody2D rigid;
    private float chaseWaitTime = 5f;
    private float chaseTimer = 0f;
    private float patrolTimer = 0f;
    private float patrolWaitTime = 5f;
    private float stoppingDistance = 5f;
    private int waypointIndex = 0;
    private Vector2 destination;

	// Use this for initialization
	void Awake() 
	{
		rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sight = gameObject.AddComponent<MonsterSight>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (sight.seenEnemy && Vector2.Distance(transform.position, target.position) < 2)
        {
            // Attack
        }
        else if (sight.lastSighting != resetPosition)
        {
            chaseEnemy();
        }
        else
        {
            patrol();
        }

        moveTowardsDestination();
	}

    void moveTowardsDestination()
    {
        if (Vector2.Distance(destination, transform.position) < 1)
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isWandering", false);
            return;
        }
        animator.SetBool("isIdle", false);
        animator.SetBool("isWandering", true);
        if (transform.position.x > destination.x)
            direction = -1;
        else
            direction = 1;
        rigid.velocity = new Vector2(direction * movementSpeed, rigid.velocity.y);
        float angle = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.down);
    }

    void chaseEnemy()
    {
        // cast to vector2
        Vector2 currentPosition = transform.position;
        Vector2 sightingDelta = sight.lastSighting - currentPosition;
        if (sightingDelta.sqrMagnitude > 4f)
        {
            Debug.Log("destination now last sighting");
            destination = sight.lastSighting;
        }

        if (Vector2.Distance(transform.position, destination) < stoppingDistance)
        {
            chaseTimer += Time.deltaTime;
            if (chaseTimer > chaseWaitTime)
            {
                sight.lastSighting = resetPosition;
                chaseTimer = 0f;
            }
        }
        else
        {
            chaseTimer = 0f;
        }
    }

    void patrol()
    {
        if (destination == resetPosition || Vector2.Distance(transform.position, destination) < stoppingDistance)
        {
            patrolTimer += Time.deltaTime;
            if (patrolTimer >= patrolWaitTime)
            {
                if (waypointIndex == waypoints.Length - 1)
                    waypointIndex = 0;
                else
                    waypointIndex++;

                patrolTimer = 0f;
            }
                
        }
        else
            patrolTimer = 0f;

        destination = waypoints[waypointIndex].position;

    }

}
