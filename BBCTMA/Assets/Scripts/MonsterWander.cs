using UnityEngine;
using System.Collections;

public class MonsterWander : MonoBehaviour {
	public float directionChangeInterval = 2f;
	public float movementSpeed = 3f;
	public Transform target;
    private Transform monster;
    private float direction = 1f;
    MonsterSight sight;

    private Rigidbody2D rigid;

	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody2D> ();
		monster = GetComponent<Transform> ();
        sight = new MonsterSight(3, monster, target);
		StartCoroutine(newDirection());
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (sight.isEnemyInSight())
        {
            if (monster.position.x > target.position.x)
                direction = -1;
            else
                direction = 1;
		}
        rigid.velocity = new Vector2(direction * movementSpeed, rigid.velocity.y);
		float angle = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg;
		monster.rotation = Quaternion.AngleAxis(angle, Vector3.down);
	}



	IEnumerator newDirection()
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
