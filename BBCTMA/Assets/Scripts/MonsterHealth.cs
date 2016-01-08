using UnityEngine;
using System.Collections;

public class MonsterHealth : MonoBehaviour {

    public int health = 100;
	// Use this for initialization
	void Start () 
    {
	
	}

    void Update () 
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }
}
