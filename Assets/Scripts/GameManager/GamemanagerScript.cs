using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemanagerScript : MonoBehaviour
{
    [SerializeField] EnergyScript energyScript;
    [SerializeField] AudioManagerScript audioManagerScript;
    [SerializeField] InGameTimerScript inGameTimerScript;
    [SerializeField] RecyclerScript canRecyclerScript;

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

    public void ChangeDay()
    {
        Debug.Log("Changing day");
        inGameTimerScript.ChangeDay();
        energyScript.ResetEnergy();
        canRecyclerScript.RecycleItem();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
