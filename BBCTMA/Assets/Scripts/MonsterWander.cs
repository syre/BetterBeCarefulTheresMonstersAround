﻿using UnityEngine;
using System.Collections;

public class MonsterWander : MonoBehaviour {
	public float directionChangeInterval = 2f;
	public float movementSpeed = 3f;
	public Transform target;
    public float range;
	private Transform monster;
	private Rigidbody2D rigid;
	private float direction = 1f;
    private bool seenEnemy = false;
	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody2D> ();
		monster = GetComponent<Transform> ();
		StartCoroutine(newDirection());
	}
	
	// Update is called once per frame
	void Update () 
	{
        var hit = Physics2D.Linecast(monster.position, target.position);
        if (hit && hit.distance < range)
		{
            if (!seenEnemy)
            {
                enemyFound();
            }
            Debug.Log("distance to player: "+hit.distance);
            seenEnemy = true;
            if (monster.position.x > target.position.x)
                direction = -1;
            else
                direction = 1;
		}
		else
		{
            seenEnemy = false;
            
		}
        rigid.velocity = new Vector2(direction * movementSpeed, rigid.velocity.y);
		float angle = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg;
		monster.rotation = Quaternion.AngleAxis(angle, Vector3.down);

	}

    void enemyFound()
    {
        Vector3 statusPos = monster.transform.position;
        statusPos.y += 1;
        var status = Instantiate(Resources.Load("StatusIcons/exclamation_mark"), statusPos, Quaternion.identity) as GameObject;
        status.transform.parent = monster;
        Destroy(status, 2);
    }

	IEnumerator newDirection()
	{
		while (true) 
		{
            if (!seenEnemy)
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