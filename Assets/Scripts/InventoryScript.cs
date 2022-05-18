using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InventoryScript : ItemContainer
{
    [SerializeField] List<Item> items;
    [SerializeField] Transform itemsParent;
    //[SerializeField] ItemSlot[] itemSlots;
    //[SerializeField] protected Item[] startingItems;
    [SerializeField] Canvas InventoryCanvas;

    public event Action<Item> OnItemRightClickEvent;
    private void Awake()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnRightClickEvent += OnItemRightClickEvent;
        }
        InventoryCanvas.enabled = false;
    }
    // Start is called before the first frame update
    private void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();

        RefreshUI();

    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            EnableDisableInventory();
        }
    }

    public void EnableDisableInventory()
    {
        if (InventoryCanvas.enabled == true)
            InventoryCanvas.enabled = false;
        else if (InventoryCanvas.enabled == false)
            InventoryCanvas.enabled = true;
    }

    private void SetStartingItems()
    {
        //foreach (Item item in startingItems)
        //{
        //    AddItem(item.GetCopy());
        //}
    }

    private void RefreshUI()
    {
        int i = 0;
        for (; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];
        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }
    }

    public virtual bool CanAddItem(Item item, int amount = 1)
    {
        int freeSpaces = 0;

        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (itemSlot.Item == null || itemSlot.Item.ID == item.ID)
            {
                freeSpaces += item.MaximumStack - itemSlot.Amount;
            }
        }
        return freeSpaces >= amount;
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null || (itemSlots[i].Item.ID == item.ID && itemSlots[i].Amount < item.MaximumStack))
            {
                itemSlots[i].Item = item;
                itemSlots[i].Amount++;
                //items.Add(item);
                return true;
            }
        }
        return false;
    }

    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (items.Remove(item))
            {
                RefreshUI();
                return true;

            }
        }
        return false;
    }

    public bool isFull()
    {
        return items.Count >= itemSlots.Length;
    }

    public bool ContainsItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                return true;
            }
        }
        return false;
    }

    public int itemCount(Item item)
    {
        int number = 0;
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                number++;
            }
        }
        return number;
    }

    public int itemCount(string itemID)
    {
        int number = 0;
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item.ID == itemID)
            {
                number++;
            }
        }
        return number;
    }

    public override  Item RemoveItem(string itemID)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            Item item = itemSlots[i].Item;
            if (item != null && item.ID == itemID)
            {
                itemSlots[i].Amount--;
                if (itemSlots[i].Amount == 0)
                {
                    itemSlots[i].Item = null;
                }
                return item;
            }
        }
        return null;
    }


}
//[SerializeField] protected Item[] startingItems;
//[SerializeField] protected Transform itemsParent;
////[SerializeField] Canvas InventoryCanvas;

////public event Action<Item> OnItemRightClickEvent;


//protected override void OnValidate()
//{
//    if (itemsParent != null)
//        itemsParent.GetComponentsInChildren(includeInactive: true, result: ItemSlots);

//    if (!Application.isPlaying)
//    {
//        SetStartingItems();
//    }
//}

//protected override void Awake()
//{
//    base.Awake();
//    SetStartingItems();
//    InventoryCanvas.enabled = false;

//}

//private void SetStartingItems()
//{
//    Clear();
//    foreach (Item item in startingItems)
//    {
//        Debug.Log(startingItems);
//        AddItem(item.GetCopy());
//    }
//}


//private void Update()
//{
//    if (Input.GetButtonDown("Inventory"))
//    {
//        Debug.Log("Inventory button pressed");
//        if (InventoryCanvas.enabled == true)
//            InventoryCanvas.enabled = false;
//        else if (InventoryCanvas.enabled == false)
//            InventoryCanvas.enabled = true;
//    }
//}
