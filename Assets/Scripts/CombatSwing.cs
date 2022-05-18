using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSwing : MonoBehaviour
{
    public float timeRemaining = 1;
    public bool timerIsRunning = false;
    public GameObject hitbox;
    // Start is called before the first frame update
    void Start()
    {
        hitbox.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ActivateWeapon();
        }
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                timeRemaining = 1;
                hitbox.gameObject.SetActive(false);
            }
        }
    }

    public void ActivateWeapon()
    {
        hitbox.gameObject.SetActive(true);
        timerIsRunning = true;
        //Debug.Log(timerIsRunning);
    }


    //private void LateUpdate()
    //{
    //    hitbox.gameObject.SetActive(false);
    //}
}
