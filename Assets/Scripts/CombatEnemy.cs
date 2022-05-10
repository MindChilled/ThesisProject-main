using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemy : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.CompareTag("hitbox"))
        //{
        //    Debug.Log("Destroy object");
        //    //Debug.Log(other.gameObject + " : collided entity name");
        //    Destroy(this.gameObject);
        //}
    }

    public void ReceiveDamage(int damageTaken)
    {
        health = health - damageTaken;
        Debug.Log("Damaging enemy for : " + damageTaken);
        if(health <= 0)
        {
            //Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "hitbox")
        //{
        //    Debug.Log("Destroy object");
        //    Destroy(this.gameObject);
        //}

        //if (collision.gameObject.tag == "Player")
        //{
        //    Debug.Log("Destroy object");
        //    Destroy(this.gameObject);
        //}
    }
}
