using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CraftingWindow : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CraftingRecipeUI recipeUIPrefab;
    [SerializeField] RectTransform recipeUIParent;
    [SerializeField] List<CraftingRecipeUI> craftingRecipeUIs;

    [Header("Public Variables")]
    public ItemContainer ItemContainer;
    public List<CraftingRecipes> CraftingRecipes;

    public event Action<ItemSlot> OnPointerEnterEvent;
    public event Action<ItemSlot> OnPointerExitEvent;

    private void OnValidate()
    {
        Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();

        foreach(CraftingRecipeUI craftingRecipeUI in craftingRecipeUIs)
        {
            craftingRecipeUI.OnPointerEnterEvent += OnPointerEnterEvent;
            craftingRecipeUI.OnPointerExitEvent += OnPointerExitEvent;
             
        }
    }

    private void Init()
    {
        recipeUIParent.GetComponentsInChildren<CraftingRecipeUI>(includeInactive: true, result: craftingRecipeUIs);
        UpdateCraftingRecipes();
    }

    public void UpdateCraftingRecipes()
    {
        for(int i = 0; i < CraftingRecipes.Count; i++)
        {
            if(craftingRecipeUIs.Count == i)
            {
                craftingRecipeUIs.Add(Instantiate(recipeUIPrefab, recipeUIParent, false));
            }
            else if(craftingRecipeUIs[i] == null)
            {
                craftingRecipeUIs[i] = Instantiate(recipeUIPrefab, recipeUIParent, false);
            }

            craftingRecipeUIs[i].ItemContainer = ItemContainer;
            craftingRecipeUIs[i].CraftingRecipe = CraftingRecipes[i];
        }

        for(int i = CraftingRecipes.Count; i < craftingRecipeUIs.Count; i++)
        {
            craftingRecipeUIs[i].CraftingRecipe = null; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
