using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryGUI : MonoBehaviour {

    public GameObject headPieceButton;
    public GameObject weaponButton;
    public GameObject chestPieceButton;
    public GameObject legPieceButton;
    public GameObject bootsButton;

    private Inventory inventory;
    private GameObject inventoryPanel;

	// Use this for initialization
	void Start() 
    {
        inventory = GetComponent<Inventory>();
		inventoryPanel = GameObject.Find("InventoryPanel");
        inventoryPanel.SetActive(false);
        weaponButton.GetComponent<Image>().sprite = inventory.weapon.sprite;
        headPieceButton.GetComponent<Image>().sprite = inventory.headPiece.sprite;
        chestPieceButton.GetComponent<Image>().sprite = inventory.chestPiece.sprite;
        legPieceButton.GetComponent<Image>().sprite = inventory.legPiece.sprite;
        bootsButton.GetComponent<Image>().sprite = inventory.boots.sprite;
    }
	
	// Update is called once per frame
	void Update() 
    {
		if (Input.GetButtonDown("Inventory")) 
		{
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
		}
	
	}
}
