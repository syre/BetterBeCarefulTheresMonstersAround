using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public float maxhealth = 100f;
    public float health = 100f;

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

    public void addHealthPoints(float hp)
    {
        if (health + hp > maxhealth)
            health = maxhealth;
        else
            health += hp;
    }
}
