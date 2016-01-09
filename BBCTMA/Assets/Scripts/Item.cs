using UnityEngine;
using System.Collections;

public class Item : ScriptableObject {

    public itemSlot slot;
    public Sprite sprite;
    public GameObject player;

    public void init(itemSlot _slot, Sprite _sprite)
    {
        slot = _slot;
        sprite = _sprite;
        player = GameObject.FindWithTag("Player");
    }
}
