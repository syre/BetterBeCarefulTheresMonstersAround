using UnityEngine;
using System.Collections;

public class HpItem : MonoBehaviour {

    public float hpGain = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Healing Player");
            var hpScript = other.gameObject.GetComponent<PlayerHealth>();
            hpScript.addHealthPoints(hpGain);
            Destroy(gameObject);
        }
    }
}
