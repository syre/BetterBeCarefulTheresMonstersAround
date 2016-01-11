using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class onHoverGUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    private Inventory inventory;
    private GameObject inventoryPanel;
    private GameObject hoverOverText;
	// Use this for initialization
	void Start () 
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
        inventoryPanel = GameObject.Find("InventoryPanel");
	}

    public void OnPointerEnter(PointerEventData data)
    {
		Debug.Log ("OnPointerEnter called");
        hoverOverText = Instantiate(Resources.Load("UIElements/HoverOverText"), Vector2.one, Quaternion.identity) as GameObject;
        hoverOverText.transform.SetParent(inventoryPanel.transform, false);
        hoverOverText.transform.position = transform.position + new Vector3(2f,0f,0f);
        switch(name)
        {
            case "HeadpieceButton":
                hoverOverText.GetComponentInChildren<Text>().text = inventory.headPiece.name;
                break;
            case "WeaponButton":
                hoverOverText.GetComponentInChildren<Text>().text = inventory.weapon.name;
                break;
            case "ChestpieceButton":
                hoverOverText.GetComponentInChildren<Text>().text = inventory.chestPiece.name;
                break;
            case "LegpieceButton":
                hoverOverText.GetComponentInChildren<Text>().text = inventory.legPiece.name;
                break;
            case "BootsButton":
                hoverOverText.GetComponentInChildren<Text>().text = inventory.boots.name;
                break;
            default:
                break;
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
			Debug.Log("OnPointerExit called");
            Destroy(hoverOverText);
    }

	// Update is called once per frame
	void Update () {
	}
}
