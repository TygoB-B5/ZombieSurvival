using UnityEngine;
using System;

public class PlayerInventory : MonoBehaviour
{
    public event Action OnUpdateInventory = delegate { };

    public Slot[] slots = new Slot[9];

    public void Add(string name, int count)
    {
        //////////////////////////////
        // INVENTORY SYSTEM NOT USED//
        //////////////////////////////
        
        //selects next open slot
        //for (int i = 0; i < 1; i++)
        //{
        //if (slots[i].hasItem == false)
        //{
        int i = 0;
        slots[i].hasItem = true;
        AddItemToSlot(name, i);
        //}
        //}

        OnUpdateInventory();
    }

    private void AddItemToSlot(string name, int id)
    {
        if (name == "Medkit")
        {
            int count = slots[id].item.count;
            slots[id].item = new Item("Medkit");
            slots[id].item.count = count + 1;
        }
    }
}

[System.Serializable]
public class Slot
{
    public Item item;
    public bool hasItem;
}

[System.Serializable]
public class Item
{
    public Item(string name)
    {
        this.name = name;
    }
    public string name;
    public int count;
}


