using UnityEngine;
using System.Collections;

public class ProjectileFlight : MonoBehaviour {

    public int damage = 50;
    public Vector2 direction = new Vector2(1f,1f);
    public float velocity = 1;
    private Rigidbody2D projectileBody;

	// Use this for initialization
	void Start () {
        projectileBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        projectileBody.velocity =  direction * velocity;
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (!other.isTrigger && other.gameObject.tag == "Monster")
        {
            Debug.Log("Collided with Monsters non trigger collider!");
            var healthScript = other.gameObject.GetComponent<MonsterHealth>();
            healthScript.takeDamage(damage);
			Destroy (gameObject);
        }
    }
}
