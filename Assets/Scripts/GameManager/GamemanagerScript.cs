using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemanagerScript : MonoBehaviour
{
    [SerializeField] EnergyScript energyScript;
    [SerializeField] AudioManagerScript audioManagerScript;
    [Header("Game Inventories")]
    [SerializeField] InGameTimerScript inGameTimerScript;
    [SerializeField] RecyclerScript canRecyclerScript;
    [SerializeField] SellBoxScript sellBoxScript;
    [SerializeField] InventoryScript inventoryScript;
    [Header("Player Data")]
    [SerializeField] PlayerCharacterScript playerCharacterScript;
    PlayerData playerData = new PlayerData();
    

    public static GamemanagerScript instance { get; private set; }

    public void PickupObject()
    {
        //Debug.Log("GameManager pickupObject");
        if(energyScript.isEnergyEmpty == false)
        {
            energyScript.ReduceEnergy(10);
            audioManagerScript.PlayPickupSFX();
        }
    }

    public void DropObject()
    {
        audioManagerScript.PlayDropSFX();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddCoins(int coins)
    {
        playerCharacterScript.playerCoins = playerCharacterScript.playerCoins + coins;
    }
    public void SaveGame()
    {
        playerData.playerCoins = playerCharacterScript.playerCoins;
        playerData.playerEnergy = energyScript.energy;

        playerData.inventoryItemSlotsItemID = inventoryScript.SaveItemAsID();
        //Debug.Log("Saving game, playerdata inventoryItemSlots = " + playerData.inventoryItemSlots);
        playerData.canRecyclerItemSlots = canRecyclerScript.itemStash.SaveItemAsID();
        //Debug.Log("Saving game, playerdata canRecyclerItemSlots = " + playerData.canRecyclerItemSlots);
        playerData.sellBoxItemSlots = sellBoxScript.itemStash.SaveItemAsID();
        //Debug.Log("Saving game, playerdata sellBoxItemSlots = " + playerData.sellBoxItemSlots);
        SaveSystem.SavePlayer(playerData);
    }

    public void LoadGame()
    {
        playerData = SaveSystem.LoadPlayer();
    }
    #region time
    public void ChangeDay()
    {
        Debug.Log("Changing day");
        inGameTimerScript.ChangeDay();
        energyScript.ResetEnergy();
        canRecyclerScript.RecycleItem();
        sellBoxScript.SellItem();

    }

    public void PauseTimer()
    {
        inGameTimerScript.PauseTimer();
    }

    public void ResumeTimer()
    {
        inGameTimerScript.ResumeTimer();
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
