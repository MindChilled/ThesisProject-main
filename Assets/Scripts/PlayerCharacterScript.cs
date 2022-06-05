using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    [Header("Player Stats")]
    public int playerCoins;

    [Header("Animator")]
    public Animator animator;

    [Header("Inventory")]
    [SerializeField] GameObject inventoryPanel;



    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        EnableDisableInventory();
    }

    public void EnableDisableInventory()
    {
        if (inventoryPanel.gameObject.active)
            inventoryPanel.SetActive(false);
        else
            inventoryPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(animator);

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            animator.SetBool("IsMove", true);
            gameObject.transform.forward = move;
            //Debug.Log("Moving character");
            
        }
        else
        {
            animator.SetBool("IsMove", false);
        }
        //animator.SetTrigger("stopRunning");


        // Changes the height position of the player..
        //if (Input.GetButtonDown("Jump") && groundedPlayer)
        //{
        //    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        //}

        if (Input.GetButtonDown("Inventory"))
        {
            EnableDisableInventory();
        }

        //playerVelocity.y += gravityValue * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);
    }
    // Start is called before the first frame update
}
