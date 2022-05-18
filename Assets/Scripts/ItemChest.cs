using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChest : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] InventoryScript inventory;
    [SerializeField] int amount = 1;
    // Start is called before the first frame update

    private bool isInRange;
    private bool isEmpty;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && isInRange == true)
        {
            GamemanagerScript.instance.PickupObject();
            if(!isEmpty)
            {
                Item itemCopy = item.GetCopy();
                if(inventory.AddItem(itemCopy))
                {
                    amount--;
                    if(amount == 0)
                    {
                         isEmpty = true;

                    }

                }
                else
                {
                    itemCopy.Destroy(); 
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
    }
}
