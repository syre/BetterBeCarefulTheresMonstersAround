using UnityEngine;
using System.Collections;

public class Item : ScriptableObject {

    public itemSlot slot;
    public Sprite sprite;
    public GameObject player;
    public string name;

    public void init(itemSlot _slot, Sprite _sprite, string _name)
    {
        slot = _slot;
        sprite = _sprite;
        name = _name;
        player = GameObject.FindWithTag("Player");
    }
}
