using UnityEngine;
using System.Collections;

public class SummonMonster : MonoBehaviour {

	public Transform Player;
	public int maxDistanceFromPlayer;
	public int minDistanceFromPlayer;
	public float movementSpeed;
	public int agroRange;
	//lower attackspeed is better!
	public float attackSpeed;
	public int damage;
	public int maxHealth;
	private int health;
	public GameObject target;
	public int attackDistance;
	private float nextAttack;
	private bool movingBack;
	public Material laserMaterial;
	public float graphicLaserFallTime;
	private bool shouldShowLaser;
	private float showLaserTime;
	private LineRenderer lineRender;
	// Use this for initialization
	void Start () {
		health = maxHealth;
		lineRender = GetComponent<LineRenderer> ();
		lineRender.enabled = true;
		lineRender.useWorldSpace = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			Debug.Log ("Target is null");
		} else {
			Debug.Log ("Target is not Null");
		}
		if (target == null && !movingBack) {
			GameObject[] monsters = GameObject.FindGameObjectsWithTag ("Monster");
			for (int i = 0; i < monsters.Length; i++) {
				if (Vector2.Distance (monsters [i].transform.position, GetComponent<Transform> ().position) < agroRange) {
					target = monsters [i];
					break;
				}
			}
		} else if(!movingBack){
			if (Vector2.Distance (target.transform.position, GetComponent<Transform> ().position) > attackDistance) {
				Vector2.MoveTowards (GetComponent<Transform> ().position, target.transform.position, movementSpeed);
			} else {
				if (nextAttack < Time.time) {
					nextAttack = Time.time + attackSpeed;
					target.GetComponent<MonsterHealth> ().takeDamage (damage);
					showLaserTime = Time.time + graphicLaserFallTime;
					lineRender.SetPosition (0, GetComponent<Transform> ().position);
					lineRender.SetPosition (1, target.transform.position);
					Debug.Log ("attacked player");
				}
			}
		}
		if (target == null && !movingBack) {
			GetComponent<Transform>().position = Vector2.MoveTowards (new Vector2(GetComponent<Transform> ().position.x, GetComponent<Transform> ().position.y), new Vector2(Player.position.x, Player.position.y), movementSpeed*Time.deltaTime);
		}
		if (Vector2.Distance (Player.position, GetComponent<Transform>().position) > maxDistanceFromPlayer) {
			movingBack = true;
		}
		if (movingBack) {
			if (Vector2.Distance (Player.position, GetComponent<Transform> ().position) < minDistanceFromPlayer) {
				movingBack = false;
				target = null;
			} else {
				GetComponent<Transform>().position = Vector2.MoveTowards (new Vector2(GetComponent<Transform> ().position.x, GetComponent<Transform> ().position.y), new Vector2(Player.position.x, Player.position.y), movementSpeed*Time.deltaTime);
				Debug.Log ("Moved towards player");
			}
		}
		if (health < 0) {
			Destroy (this.gameObject);
		}

		if (Time.time < showLaserTime) {
			if (target != null) {
				lineRender.enabled = true;
			}
		} else {
			lineRender.enabled = false;
		}
		Debug.Log("Distance between player and drone: "+(Vector2.Distance (Player.position, GetComponent<Transform>().position)));
	}
}
