using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData 
{
    
    public int playerCoins;
    public int playerEnergy;
    public string[] inventoryItemSlotsItemID;
    public string[] canRecyclerItemSlots;
    public string[] plasticRecyclerItemSlots;
    public string[] paperRecyclerItemSlots;
    public string[] sellBoxItemSlots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
