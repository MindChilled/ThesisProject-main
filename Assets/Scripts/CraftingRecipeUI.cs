using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CraftingRecipeUI : MonoBehaviour
{

    [Header("References")]
    [SerializeField] RectTransform arrowParent;
    [SerializeField] ItemSlot[] itemSlots;

    [Header("Public Variables")]
    public ItemContainer ItemContainer;

    private CraftingRecipes craftingRecipe;
    public CraftingRecipes CraftingRecipe
    {
        get { return craftingRecipe; }
        set { SetCraftingRecipe(value); }
    }

    public event Action<ItemSlot> OnPointerEnterEvent;
    public event Action<ItemSlot> OnPointerExitEvent;

    private void OnValidate()
    {
        itemSlots = GetComponentsInChildren<ItemSlot>(includeInactive: true);
    }

    private void Start()
    {
        foreach (ItemSlot itemSlot in itemSlots)
        {
            itemSlot.OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
            itemSlot.OnPointerExitEvent += slot => OnPointerExitEvent(slot);
        }
    }

    public void OnCraftButtonClick()
    {
        if (craftingRecipe != null && ItemContainer != null)
        {
            craftingRecipe.Craft(ItemContainer);
        }
    }

    private void SetCraftingRecipe(CraftingRecipes newCraftingRecipe)
    {
        craftingRecipe = newCraftingRecipe;

        if (craftingRecipe != null)
        {
            int slotIndex = 0;
            slotIndex = SetSlots(craftingRecipe.Materials, slotIndex);
            arrowParent.SetSiblingIndex(slotIndex);
            slotIndex = SetSlots(craftingRecipe.Results, slotIndex);

            for (int i = slotIndex; i < itemSlots.Length; i++)
            {
                itemSlots[i].transform.parent.gameObject.SetActive(false);
            }

            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private int SetSlots(IList<ItemAmount> itemAmountList, int slotIndex)
    {
        for (int i = 0; i < itemAmountList.Count; i++, slotIndex++)
        {
            ItemAmount itemAmount = itemAmountList[i];
            ItemSlot itemSlot = itemSlots[slotIndex];

            itemSlot.Item = itemAmount.item;
            itemSlot.Amount = itemAmount.amount;
            itemSlot.transform.parent.gameObject.SetActive(true);
        }
        return slotIndex;
    }
    //[Header("References")]
    //[SerializeField] RectTransform arrowParent;
    //[SerializeField] ItemSlot[] itemSlots;

    //[Header("Public Variables")]
    //public ItemContainer itemContainer;

    //private CraftingRecipes craftingRecipes;
    //public CraftingRecipes CraftingRecipes
    //{
    //    get { return craftingRecipes; }
    //    set { SetCraftingRecipe(value); }
    //}

    //public event Action<ItemSlot> OnPointerEnterEvent;
    //public event Action<ItemSlot> OnPointerExitEvent;

    //private void OnValidate()
    //{
    //    itemSlots = GetComponentsInChildren<ItemSlot>(includeInactive: true);
    //}

    //// Start is called before the first frame update
    //void Start()
    //{
    //    foreach (ItemSlot itemSlot in itemSlots)
    //    {
    //        itemSlot.OnPointerEnterEvent += OnPointerEnterEvent;
    //        itemSlot.OnPointerExitEvent += OnPointerExitEvent;

    //    }
    //}

    //public void OnCraftButtonClick()
    //{
    //    if(craftingRecipes != null && itemContainer != null)
    //    {
    //        if(craftingRecipes.CanCraft(itemContainer))
    //        {
    //            if(!itemContainer.isFull())
    //            {
    //                craftingRecipes.Craft(itemContainer);
    //            }
    //            else
    //            {
    //                Debug.LogError("Inventory is full");
    //            }
    //        }
    //        else
    //        {
    //            Debug.LogError("You don't have the required materials!");
    //        }
    //    }
    //}

    ////private void SetCraftingRecipe(CraftingRecipes newCraftingRecipe)
    ////{
    ////    craftingRecipes = newCraftingRecipe;
    ////    if(craftingRecipes != null)
    ////    {
    ////        int slotIndex = 0;
    ////        slotIndex = SetSlots(craftingRecipes.Materials, slotIndex);
    ////        arrowParent.SetSiblingIndex(slotIndex);
    ////        slotIndex = SetSlots(craftingRecipes.Results, slotIndex);

    ////        for(int i = slotIndex; i < itemSlots.Length; i++)
    ////        {
    ////            itemSlots[i].transform.parent.gameObject.SetActive(false);
    ////        }

    ////        gameObject.SetActive(true);
    ////    }
    ////    else
    ////    {
    ////        gameObject.SetActive(true);
    ////    }
    ////}

    //private void SetCraftingRecipe(CraftingRecipes newCraftingRecipe)
    //{
    //    craftingRecipes = newCraftingRecipe;

    //    if (craftingRecipes != null)
    //    {
    //        int slotIndex = 0;
    //        slotIndex = SetSlots(craftingRecipes.Materials, slotIndex);
    //        arrowParent.SetSiblingIndex(slotIndex);
    //        slotIndex = SetSlots(craftingRecipes.Results, slotIndex);

    //        for (int i = slotIndex; i < itemSlots.Length; i++)
    //        {
    //            itemSlots[i].transform.parent.gameObject.SetActive(false);
    //        }

    //        gameObject.SetActive(true);
    //    }
    //    else
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}

    //private int SetSlots(IList<ItemAmount> itemAmountsList, int slotIndex)
    //{
    //    for(int i = 0; i < itemAmountsList.Count; i++, slotIndex++)
    //    {
    //        ItemAmount itemAmount = itemAmountsList[i];
    //        ItemSlot itemSlot = itemSlots[slotIndex];

    //        itemSlot.Item = itemAmount.item;
    //        itemSlot.Amount = itemAmount.amount;
    //        itemSlot.transform.parent.gameObject.SetActive(true);
    //    }
    //    return slotIndex;
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
