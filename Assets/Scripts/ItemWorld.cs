using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    //public static ItemWorld SpawnItemWorld(Vector3 position, Items items)
    //{
    //    Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

    //    ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
    //    Debug.Log("ItemWorld punya items : " + items    );
    //    itemWorld.SetItem(items);

    //    return itemWorld;
    //}

    //private Items items;
    //private SpriteRenderer spriteRenderer;

    //private void Awake()
    //{
    //    spriteRenderer = GetComponent<SpriteRenderer>();
    //}

    //public void SetItem(Items items)
    //{
    //    this.items = items;
    //    Debug.Log(items.itemType + " : this is items" + items.itemName + " : this is itemName");
    //    spriteRenderer.sprite = items.GetSprite();
    //}

    //public Items GetItem()
    //{
    //    return items;
    //}

    //public void DestroySelf()
    //{
    //    Destroy(gameObject);
    //}
}
