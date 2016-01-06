using UnityEngine;
using System.Collections;

public class RangedAttackBehaviour : MonoBehaviour {


	public float agroRange = 100;
	public GameObject attack;
	public float projectileSpeed = 10;
	private bool isAttacking;
	private Transform player;
    private Animator animator;
    public float timeBetweenAttack = 1f;
    private float nextFire;
	private float scaleX;
	public float yUp;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player").transform;
        animator = GetComponent<Animator>();
		scaleX = GetComponent<Transform> ().localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x + player.transform.localScale.x < GetComponent<Transform> ().position.x) {
			GetComponent<Transform> ().localScale = new Vector3 (-scaleX, GetComponent<Transform> ().localScale.y, GetComponent<Transform> ().localScale.z);
		} else {
			GetComponent<Transform> ().localScale = new Vector3 (scaleX, GetComponent<Transform> ().localScale.y, GetComponent<Transform> ().localScale.z);
		}
		if (Vector3.Distance(GetComponent<Transform>().position, player.position) < agroRange) {
			Debug.Log ("Distance is: " + Vector3.Distance(GetComponent<Transform>().position, player.position));
			isAttacking = true;
		} else {
			isAttacking = false;
			Debug.Log ("Distance is: " + Vector3.Distance(GetComponent<Transform>().position, player.position));
		}
        if (isAttacking)
        {
            animator.SetBool("isAttacking", true);
            if (nextFire < Time.time)
            {
                if (player.transform.position.x + player.transform.localScale.x < GetComponent<Transform>().position.x)
                {
					Vector3 dir = player.position - GetComponent<Transform> ().position;
					//Quaternion look = Quaternion.LookRotation (dir); 
					//, new Vector3(GetComponent<Transform>().position.x - GetComponent<Transform>().localScale.x, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z), GetComponent<Transform>().rotation
					GameObject fireBall = Instantiate(attack, new Vector3 (GetComponent<Transform> ().position.x - scaleX, GetComponent<Transform> ().position.y + yUp, GetComponent<Transform> ().position.z), Quaternion.identity) as GameObject;
					//fireBall.transform.position = new Vector3 (GetComponent<Transform> ().position.x - scaleX, GetComponent<Transform> ().position.y + yUp, GetComponent<Transform> ().position.z);
					fireBall.GetComponent<ProjectileHitPlayer> ().setVelocity (projectileSpeed,dir);//new Vector2(-projectileSpeed, 0f));
                }
                else
                {
					Vector3 dir = GetComponent<Transform> ().position - player.position;
					//Quaternion look = Quaternion.LookRotation (dir); 
					//, new Vector3(GetComponent<Transform>().position.x + GetComponent<Transform>().localScale.x, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z), GetComponent<Transform>().rotation
					GameObject fireBall = GameObject.Instantiate(attack, new Vector3 (GetComponent<Transform> ().position.x + scaleX, GetComponent<Transform> ().position.y + yUp, GetComponent<Transform> ().position.z), Quaternion.identity) as GameObject;
					//fireBall.transform.position = new Vector3 (GetComponent<Transform> ().position.x + scaleX, GetComponent<Transform> ().position.y + yUp, GetComponent<Transform> ().position.z);
					fireBall.GetComponent<ProjectileHitPlayer>().setVelocity(projectileSpeed,dir);
                }
                nextFire = Time.time + timeBetweenAttack;
            }
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
	}
}
