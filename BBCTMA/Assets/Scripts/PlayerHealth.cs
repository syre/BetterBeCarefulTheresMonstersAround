using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float health = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Debug.Log("You are dead");
        }
	}

    public void takeDamage(int damage){
        health -= damage;
    }
}
