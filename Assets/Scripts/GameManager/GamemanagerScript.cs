using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemanagerScript : MonoBehaviour
{
    [SerializeField] EnergyScript energyScript;
    [SerializeField] AudioManagerScript audioManagerScript;
    public static GamemanagerScript instance { get; private set; }

    public void PickupObject()
    {
        //Debug.Log("GameManager pickupObject");
        energyScript.ReduceEnergy(10);
        audioManagerScript.PlayPickupSFX();
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
