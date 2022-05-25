using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedScript : MonoBehaviour
{
    //public Image dialogBox;
    //public TMP_Text dialogText;
    public string dialog;
    public bool isPlayerNear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isPlayerNear)
        {
            Debug.Log("Changing day");
            GamemanagerScript.instance.ChangeDay();
        }

        if (isPlayerNear == false)
        {
            //dialogBox.gameObject.SetActive(false);
            //dialogText.text = " ";
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			isPlayerNear = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			isPlayerNear = false;

		}
	}
}
