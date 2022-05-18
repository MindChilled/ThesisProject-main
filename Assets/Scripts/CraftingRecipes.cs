using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    public Item item;
    [Range(1,999)]
    public int amount;
}

[CreateAssetMenu]
public class CraftingRecipes : ScriptableObject
{
    public List<ItemAmount> Materials;
    public List<ItemAmount> Results;


    public bool CanCraft(IItemContainer itemContainer)
    {
        foreach(ItemAmount itemAmount in Materials)
        {
            //Debug.Log("Checking for items, "+ itemContainer.ItemCount(itemAmount.item.ID) + " checking itemcount, next is : " + itemAmount.amount);

            if(itemContainer.ItemCount(itemAmount.item.ID) < itemAmount.amount)
            {
                Debug.Log("CanCraft returning false");
                return false;
            }
        }
        return true;
    }

    public bool Craft(IItemContainer itemContainer)
    {
        Debug.Log("Attempting to craft");
        if(CanCraft(itemContainer))
        {
            foreach (ItemAmount itemAmount in Materials)
            {
                for(int i = 0; i < itemAmount.amount; i++)
                {
                    Debug.Log("Crafting, removing old item");
                    Item oldItem = itemContainer.RemoveItem(itemAmount.item.ID);
                    oldItem.Destroy(); 
                    //itemContainer.RemoveItem(itemAmount.item);
                }
            }

            foreach(ItemAmount itemAmount in Results)
            {
                for(int i = 0; i < itemAmount.amount; i++)
                {
                    Debug.Log("Crafting, adding new item");
                    itemContainer.AddItem(itemAmount.item.GetCopy());
                }
            }
        }
        return false;
    }
}