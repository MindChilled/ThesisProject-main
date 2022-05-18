using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyScript : MonoBehaviour
{
    [SerializeField] int energy;
    [SerializeField] int maxEnergy;
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
    }

    public void AddEnergy(int amount)
    {
        energy = energy - amount;
    }

    public void ResetEnergy()
    {
        energy = maxEnergy;
    }
}
