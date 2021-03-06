using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemContainer : MonoBehaviour, IItemContainer
{
    //public List<ItemSlot> ItemSlots;
    [SerializeField] public ItemSlot[] itemSlots;

    //public event Action<ItemSlot> OnPointerEnterEvent;
    //public event Action<ItemSlot> OnPointerExitEvent;
    //public event Action<ItemSlot> OnRightClickEvent;
    //public event Action<ItemSlot> OnBeginDragEvent;
    //public event Action<ItemSlot> OnEndDragEvent;
    //public event Action<ItemSlot> OnDragEvent;
    //public event Action<ItemSlot> OnDropEvent;

    //protected virtual void OnValidate()
    //{
    //	GetComponentsInChildren(includeInactive: true, result: ItemSlots);
    //}

    protected virtual void Awake()
    {
        //for (int i = 0; i < ItemSlots.Count; i++)
        //{
        //    ItemSlots[i].OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
        //    ItemSlots[i].OnPointerExitEvent += slot => OnPointerExitEvent(slot);
        //    //ItemSlots[i].OnRightClickEvent += slot => OnRightClickEvent(slot);
        //    ItemSlots[i].OnBeginDragEvent += slot => OnBeginDragEvent(slot);
        //    ItemSlots[i].OnEndDragEvent += slot => OnEndDragEvent(slot);
        //    ItemSlots[i].OnDragEvent += slot => OnDragEvent(slot);
        //    ItemSlots[i].OnDropEvent += slot => OnDropEvent(slot);
        //}
    }

    protected virtual void OnValidate()
    {
        itemSlots = GetComponentsInChildren<ItemSlot>();
    }

    //private void EventHelper(BaseItemSlot itemSlot, Action<BaseItemSlot> action)
    //{
    //	if (action != null)
    //		action(itemSlot);
    //}

    //public virtual bool CanAddItem(Item item, int amount = 1)
    //{
    //	int freeSpaces = 0;

    //	foreach (ItemSlot itemSlot in ItemSlots)
    //	{
    //		if (itemSlot.Item == null || itemSlot.Item.ID == item.ID)
    //		{
    //			freeSpaces += item.MaximumStack - itemSlot.Amount;
    //		}
    //	}
    //	return freeSpaces >= amount;
    //}

    //public virtual bool AddItem(Item item)
    //{
    //	for (int i = 0; i < ItemSlots.Count; i++)
    //	{
    //		if (ItemSlots[i].CanAddStack(item))
    //		{
    //			ItemSlots[i].Item = item;
    //			ItemSlots[i].Amount++;
    //			return true;
    //		}
    //	}

    //	for (int i = 0; i < ItemSlots.Count; i++)
    //	{
    //		if (ItemSlots[i].Item == null)
    //		{
    //			ItemSlots[i].Item = item;
    //			ItemSlots[i].Amount++;
    //			return true;
    //		}
    //	}
    //	return false;
    //}

    public virtual bool RemoveItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                itemSlots[i].Amount--;
                return true;
            }
        }
        return false;
    }

    //public virtual Item RemoveItem(string itemID)
    //{
    //	for (int i = 0; i < ItemSlots.Count; i++)
    //	{
    //		Item item = ItemSlots[i].Item;
    //		if (item != null && item.ID == itemID)
    //		{
    //			ItemSlots[i].Amount--;
    //			return item;
    //		}
    //	}
    //	return null;
    //}

    //public virtual int ItemCount(string itemID)
    //{
    //	int number = 0;

    //	for (int i = 0; i < ItemSlots.Count; i++)
    //	{
    //		Item item = ItemSlots[i].Item;
    //		if (item != null && item.ID == itemID)
    //		{
    //			number += ItemSlots[i].Amount;
    //		}
    //	}
    //	return number;
    //}

    //public void Clear()
    //{
    //	for (int i = 0; i < ItemSlots.Count; i++)
    //	{
    //		if (ItemSlots[i].Item != null && Application.isPlaying)
    //		{
    //			ItemSlots[i].Item.Destroy();
    //		}
    //		ItemSlots[i].Item = null;
    //		ItemSlots[i].Amount = 0;
    //	}
    //}

    //   public int itemCount(string itemID)
    //   {
    //       throw new NotImplementedException();
    //   }

    //   public bool isFull()
    //   {
    //       throw new NotImplementedException();
    //   }

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

    //public bool AddItem(Item item)
    //{
    //    for (int i = 0; i < itemSlots.Length; i++)
    //    {
    //        if (itemSlots[i].Item == null || (itemSlots[i].Item.ID == item.ID && itemSlots[i].Amount < item.MaximumStack))
    //        {
    //            itemSlots[i].Item = item;
    //            itemSlots[i].Amount++;
    //            Debug.Log(itemSlots[i]);
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    public virtual bool AddItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].CanAddStack(item))
            {
                itemSlots[i].Item = item;
                itemSlots[i].Amount++;
                return true;
            }
        }

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                itemSlots[i].Item = item;
                itemSlots[i].Amount++;
                return true;
            }
        }
        return false;
    }

    public virtual bool isFull()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                return false;
            }
        }
        return true;
    }

    public virtual Item RemoveItem(string itemID)
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


    public int ItemCount(string itemID)
    {
        int number = 0;

        for(int i = 0; i < itemSlots.Length; i++)
        {
            Item item = itemSlots[i].Item;
            if(item != null && item.ID == itemID)
            {
                number++;
            }
        }
        return number;
    }

    //public bool RemoveItem(Item item)
    //{
    //    throw new NotImplementedException();
    //}
}
