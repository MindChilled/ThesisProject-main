using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(int damageTaken)
    {
        health = health - damageTaken;
        Debug.Log("Damaging " + this.gameObject + " for " + damageTaken + " damage");
        if(health <= 0)
        {
            //Destroy(this.gameObject);
        }
    }
}
