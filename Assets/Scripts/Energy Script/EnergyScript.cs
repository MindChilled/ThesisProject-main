using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyScript : MonoBehaviour
{
    [SerializeField] int energy;
    [SerializeField] int maxEnergy;
    [SerializeField] Image energyBar;
    [SerializeField] Image currEnergyBar;


    public bool isEnergyEmpty;
    protected float energyFloat;
    public static EnergyScript Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceEnergy(int amount)
    {
        energy = energy - amount;
        energyFloat = (float)energy / (float)maxEnergy;
        Debug.Log(energyFloat + " : this is energyFloat");
        currEnergyBar.fillAmount = energyFloat;
        if(energy <= 0 )
        {
            isEnergyEmpty = true;
        }
        Debug.Log(energy + " : current Energy");
    }

    public void AddEnergy(int amount)
    {
        energy = energy - amount;
        energyFloat =  energy / maxEnergy;
        Debug.Log(energyFloat + " : this is energyFloat");
        if (energy > 0)
        {
            isEnergyEmpty = false;
        }
        Debug.Log(energy + " : current Energy");
    }

    public void ResetEnergy()
    {
        energy = maxEnergy;
    }
}
