using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBoxScript : MonoBehaviour
{
    //[SerializeField] int typeToRecycle;
    //public int recycleValueStored;
    public ItemStash itemStash;
    [SerializeField] int totalPriceofItems;
    //[SerializeField] Item recycledItem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SellItem()
    {
        totalPriceofItems = itemStash.RemoveItemAndSell();
        //Debug.Log("Selling item");
        GamemanagerScript.instance.AddCoins(totalPriceofItems);
        //Debug.Log("Added to gameManager");
        totalPriceofItems = 0;
    }
}
