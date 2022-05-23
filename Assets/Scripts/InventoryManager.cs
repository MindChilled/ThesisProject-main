﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] InventoryScript inventory;
    [SerializeField] ItemStash itemStash;

    public static InventoryManager instance { get; private set; }


    private void Awake()
    {
        inventory.OnItemRightClickEvent += AddItemToStash;

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddItemToStash(Item item)
    {
        //Debug.Log("Add item to stash");
        if(inventory.RemoveItem(item.ID))
        {
            itemStash.AddItem(item);
            itemStash.DescribeItems();
        }
    }

    public void RemoveItemFromStash(Item item)
    { 
        if(!inventory.isFull() && itemStash.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
