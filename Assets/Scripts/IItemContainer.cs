using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemContainer 
{
    int itemCount(string itemID);
    Item RemoveItem(string itemID);
    //bool ContainsItem(Item item);
    //bool RemoveItem(Item item);
    bool AddItem(Item item);
    bool isFull();

    int ItemCount(string itemID);

    //bool CanAddItem(Item item, int amount = 1);
    //bool AddItem(Item item);

    //Item RemoveItem(string itemID);
    //bool RemoveItem(Item item);

    //void Clear();

    //int ItemCount(string itemID);



}
