using UnityEngine;
using System.Collections;

public class InventoryGUI : MonoBehaviour {

    Inventory inventory;
    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 300, 100), "Equipped Weapons");
        if (GUI.Button(new Rect(40, 40, 50, 50), "1"))
        {
            inventory.dropItem(0);
        }
        else if (GUI.Button(new Rect(100, 40, 50, 50), "2"))
        {
            inventory.dropItem(1);
        }
        else if (GUI.Button(new Rect(160, 40, 50, 50), "3"))
        {
            inventory.dropItem(2);
        }
        else if (GUI.Button(new Rect(220, 40, 50, 50), "4"))
        {
            inventory.dropItem(3);
        }
    }

	// Use this for initialization
	void Start() 
    {
        inventory = GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update() 
    {
	
	}
}
