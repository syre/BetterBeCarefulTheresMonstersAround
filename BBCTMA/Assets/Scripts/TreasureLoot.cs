using UnityEngine;
using System.Collections;

public class TreasureLoot : MonoBehaviour {
    private GameObject LootView;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Loot for player!");
            if (!LootView)
            {
                Vector3 viewPos = transform.position + new Vector3(0f, 100f, 0f);
                LootView = Instantiate(Resources.Load("UIElements/LootView"), viewPos, Quaternion.identity) as GameObject;
                var canvas = UnityEngine.Object.FindObjectOfType<Canvas>();
                LootView.transform.SetParent(canvas.transform, false);
            }
            else
                LootView.SetActive(true);
                
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            LootView.SetActive(false);
        }
    }
}
