using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignScript : MonoBehaviour
{
    public Image dialogBox;
    public TMP_Text dialogText;
    public string dialog;
    public bool isPlayerNear;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isPlayerNear)
        {
            if (dialogBox.IsActive())
            {
                dialogBox.gameObject.SetActive(false);
            }
            else
            {
                dialogBox.gameObject.SetActive(true);
                dialogText.text = dialog;
            }
        }

        if (isPlayerNear == false)
        {
            dialogBox.gameObject.SetActive(false);
            dialogText.text = " ";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left range");
            isPlayerNear = false;
        }
    }

    public void InteractWithSign()
    {
        if(isPlayerNear)
        {
            if (dialogBox.IsActive())
            {
                dialogBox.gameObject.SetActive(false);
            }
            else
            {
                dialogBox.gameObject.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }
}
