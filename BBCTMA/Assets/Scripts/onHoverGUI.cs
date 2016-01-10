using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class onHoverGUI : MonoBehaviour, IPointerEnterHandler{

	// Use this for initialization
	void Start () {
	
	}

    public void OnPointerEnter(PointerEventData data)
    {
        if (name == "HeadpieceButton")
            Debug.Log("headpiece Enter");
        else if (name == "WeaponButton")
            Debug.Log("weapon Enter");
        else if (name == "ChestpieceButton")
            Debug.Log("chestpiece Enter");
        else if (name == "LegpieceButton")
            Debug.Log("legpiece Enter");
        else if (name == "BootsButton")
            Debug.Log("boots Enter");
    }

	// Update is called once per frame
	void Update () {
	
	}
}
