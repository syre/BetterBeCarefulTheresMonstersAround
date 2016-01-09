using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

    public GameObject[] itemSlots = new GameObject[4];
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    public bool addItem(GameObject item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i] == null)
            {
                itemSlots[i] = item;
                return true;
            }
        }

        return false;
    }

    public void dropItem(GameObject item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i] == item)
            {
                Debug.Log("item dropped");
                itemSlots[i] = null;
            }
            
        }
        Debug.Log("could not find item to drop");
    }
    public void dropItem(int index)
    {
        if (itemSlots[index] != null)
            itemSlots[index] = null;
        else
            Debug.Log("no item in slot "+index);
    }
}
