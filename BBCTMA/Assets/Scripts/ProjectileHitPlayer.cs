using UnityEngine;
using System.Collections;

public class ProjectileHitPlayer : MonoBehaviour {

	public float damage;
    private float velocity;
	private Vector3 dir;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity =  dir * velocity;
        //Debug.Log("ARE WE HERE");
	}


	void OnTriggerEnter2D(Collider2D collisionInfo){
		if (collisionInfo.gameObject.tag == "Player") {
			collisionInfo.gameObject.GetComponent<PlayerHealth> ().takeDamage ((int)damage);
			Debug.Log ("Colided with player");
			Destroy (gameObject);
			collisionInfo.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(GetComponent<Rigidbody2D>().velocity.x*5, GetComponent<Rigidbody2D>().velocity.y*5), ForceMode2D.Force);
		} else if (collisionInfo.gameObject.tag == "Monster") {

		}
		else{
			Destroy (gameObject);
			Debug.Log ("Collided with something else");
		}
	}

    public void setVelocity(float velocity, Vector3 dir){
        this.velocity = velocity;
		this.dir = dir;
		Debug.Log ("SAT THAT VELOCITY");
    }
}
