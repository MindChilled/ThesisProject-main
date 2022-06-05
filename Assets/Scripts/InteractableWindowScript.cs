using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWindowScript : MonoBehaviour
{
    public GameObject interactablePanel;
    public bool isPlayerNear;
    [SerializeField] SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isPlayerNear)
        {
            if (interactablePanel.activeInHierarchy)
            {
                interactablePanel.gameObject.SetActive(false);
            }
            else
            {
                interactablePanel.gameObject.SetActive(true);
            }
        }

        if (isPlayerNear == false)
        {
            interactablePanel.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            isPlayerNear = true;
            spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left range");
            isPlayerNear = false;
            spriteRenderer.enabled = false;

        }
    }
}
