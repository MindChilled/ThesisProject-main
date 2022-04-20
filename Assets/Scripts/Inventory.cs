using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory 
{

    public event EventHandler OnItemListChanged;

    private List<Items> itemList;

    public Inventory()
    {
        itemList = new List<Items>();

        AddItem(new Items { itemType = Items.ItemType.Bottles, amount = 1 });
        AddItem(new Items { itemType = Items.ItemType.Cans, amount = 1 });
        AddItem(new Items { itemType = Items.ItemType.Plastic, amount = 1 });

        Debug.Log(itemList.Count );
    }

    public void AddItem(Items items)
    {
        itemList.Add(items);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Items> GetItemList()
    {
        return itemList;
    }

}
