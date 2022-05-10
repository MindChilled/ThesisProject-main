using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class Items : ScriptableObject
{
    public enum ItemType
    {
        Plastic,
        Cans,
        Bottles
    }

    public ItemType itemType;
    public string itemName;
    public int amount;
    public int sellPrice;
    public Sprite sprite; 

    public Sprite GetSprite()
    {
        return this.sprite;
    }

    //public Sprite GetSprite()
    //{
    //    switch (itemType)
    //    {
    //        default:
    //        case ItemType.Plastic:  return ItemAssets.Instance.plasticSprite;
    //        case ItemType.Cans:     return ItemAssets.Instance.canSprite;
    //        case ItemType.Bottles:  return ItemAssets.Instance.bottleSprite;
    //    }
    //}

}
