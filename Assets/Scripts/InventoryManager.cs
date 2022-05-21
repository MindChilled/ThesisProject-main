using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] InventoryScript inventory;
    [SerializeField] ItemStash itemStash;

    private void Awake()
    {
        inventory.OnItemRightClickEvent += AddItemToStash;
    }

    public void AddItemToStash(Item item)
    {
        if(inventory.RemoveItem(item))
        {
            itemStash.AddItem(item);
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
