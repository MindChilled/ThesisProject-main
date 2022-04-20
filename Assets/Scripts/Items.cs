using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items 
{
    public enum ItemType
    {
        Plastic,
        Cans,
        Bottles
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Plastic:  return ItemAssets.Instance.plasticSprite;
            case ItemType.Cans:     return ItemAssets.Instance.canSprite;
            case ItemType.Bottles:  return ItemAssets.Instance.bottleSprite;
        }
    }

}
