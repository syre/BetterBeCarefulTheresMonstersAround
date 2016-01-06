using UnityEngine;
using System.Collections;

public class MonsterWander : MonoBehaviour {
	public float directionChangeInterval = 2f;
	public float movementSpeed = 3f;
	public Transform target;
    private Transform monster;
    private float direction = 1f;
    private Animator animator;
    private MonsterSight sight;
    private bool isIdle = false;
    private Rigidbody2D rigid;

	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody2D>();
		monster = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        sight = monster.root.gameObject.AddComponent<MonsterSight>();
        sight.init(3, monster, target, animator, onFirstTimeSeen);
		StartCoroutine(changeDirection());
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (isIdle)
            return;
        if (sight.isEnemyInSight())
        {
            // chase
            if (monster.position.x > target.position.x)
                direction = -1;
            else
                direction = 1;
        }
        else
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isWandering", true);
        }
        rigid.velocity = new Vector2(direction * movementSpeed, rigid.velocity.y);
		float angle = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg;
		monster.rotation = Quaternion.AngleAxis(angle, Vector3.down);
	}

    void onFirstTimeSeen()
    {
        StartCoroutine(setMonsterIdle(0.5f));
    }

    IEnumerator setMonsterIdle(float _idleLength)
    {
        isIdle = true;

        animator.SetBool("hasSeenEnemy", true);
        animator.SetBool("isWandering", false);
        animator.SetBool("isIdle", false);
        var time = 0f;
        float idleLength = _idleLength;
        direction = 0;
        while (time < idleLength)
        {
            time += Time.deltaTime;
            yield return null;
        }
        direction = 1;
        animator.SetBool("hasSeenEnemy", false);
        animator.SetBool("isWandering", true);
        isIdle = false;
    }

	IEnumerator changeDirection()
	{
		while (true) 
		{
            if (!sight.hasRecentlySeenEnemy())
            {
                newDirectionRoutine();

            }
            yield return new WaitForSeconds(directionChangeInterval);
		}
	}

	void newDirectionRoutine()
	{
		direction = -direction;
	}

}
