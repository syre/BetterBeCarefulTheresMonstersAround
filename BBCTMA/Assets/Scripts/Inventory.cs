using UnityEngine;
using System.Collections;
public enum itemSlot 
{
    HEADPIECE,
    WEAPON,
    CHESTPIECE,
    LEGPIECE,
    BOOTS
}
public class Inventory : MonoBehaviour {

    public Item headPiece;
    public Item weapon;
    public Item chestPiece;
    public Item legPiece;
    public Item boots;

	// Use this for initialization
	void Start () {
        headPiece = ScriptableObject.CreateInstance("Item") as Item;
        weapon = ScriptableObject.CreateInstance("Item") as Item;
        chestPiece = ScriptableObject.CreateInstance("Item") as Item;
        legPiece = ScriptableObject.CreateInstance("Item") as Item;
        boots = ScriptableObject.CreateInstance("Item") as Item;

        headPiece.init(itemSlot.HEADPIECE, Resources.Load<Sprite>("ItemImages/basic_hood"), "Basic Headpiece");
        weapon.init(itemSlot.WEAPON, Resources.Load<Sprite>("ItemImages/sword"), "Basic Sword");
        chestPiece.init(itemSlot.CHESTPIECE, Resources.Load<Sprite>("ItemImages/basic_chest"), "Basic Chestpiece");
        legPiece.init(itemSlot.LEGPIECE, Resources.Load<Sprite>("ItemImages/basic_legs"), "Basic Legpiece");
        boots.init(itemSlot.BOOTS, Resources.Load<Sprite>("ItemImages/basic_boots"), "Basic Boots");
	}
	
    public void addItem(Item item, itemSlot slot)
    {
        switch(slot)
        {
            case itemSlot.HEADPIECE:
                headPiece = item;
                break;
            case itemSlot.WEAPON:
                weapon = item;
                break;
            case itemSlot.CHESTPIECE:
                chestPiece = item;
                break;
            case itemSlot.LEGPIECE:
                legPiece = item;
                break;
            case itemSlot.BOOTS:
                boots = item;
                break;
            default:
                break;
        }
    }

    public void dropItem(itemSlot slot)
    {
        switch(slot)
        {
            case itemSlot.HEADPIECE:
                Destroy(headPiece);
                break;
            case itemSlot.WEAPON:
                Destroy(weapon);
                break;
            case itemSlot.CHESTPIECE:
                Destroy(chestPiece);
                break;
            case itemSlot.LEGPIECE:
                Destroy(legPiece);
                break;
            case itemSlot.BOOTS:
                Destroy(boots);
                break;
            default:
                break;
        }
    }


}
