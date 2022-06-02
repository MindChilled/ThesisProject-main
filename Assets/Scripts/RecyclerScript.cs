 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclerScript : MonoBehaviour
{
    [SerializeField] int typeToRecycle;
    public int recycleValueStored;
    public ItemStash itemStash;
    [SerializeField] Item recycledItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecycleItem()
    {
        recycleValueStored =  itemStash.RemoveItemAndCount(typeToRecycle);
        while (recycleValueStored != 0)
        {
            itemStash.AddItem(recycledItem);
            recycleValueStored--;
        }
    }

}
