using UnityEngine;
using System.Collections;

public class MonsterWander : MonoBehaviour {
	public float directionChangeInterval = 2f;
	public float movementSpeed = 3f;
	private Transform monster;
	private Rigidbody2D rigid;
	private float direction = 1f;

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
		rigid.velocity = new Vector2(direction * movementSpeed, rigid.velocity.y);
		float angle = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg;
		monster.rotation = Quaternion.AngleAxis(angle, Vector3.down);


	}

	IEnumerator newDirection()
	{
		while (true) 
		{
			newDirectionRoutine();
			yield return new WaitForSeconds(directionChangeInterval);
		}
	}

	void newDirectionRoutine()
	{
		direction = -direction;
	}

}
