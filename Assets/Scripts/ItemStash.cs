using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStash : ItemContainer
{

    // Start is called before the first frame update
    [SerializeField] Transform itemsParent;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] KeyCode openKeyCode = KeyCode.E;
	private bool isOpen;
	private bool isInRange;

	public bool isPlayerNear;
	public GameObject stashCanvas;
	//private Character character;

	protected override void OnValidate()
	{
		if (itemsParent != null)
			itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
		//itemsParent.GetComponentsInChildren(includeInactive: true, result: ItemSlots);

		if (spriteRenderer == null)
			spriteRenderer = GetComponentInChildren<SpriteRenderer>(includeInactive: true);

		//spriteRenderer.enabled = false;
	}

	protected override void Awake()
	{
		base.Awake();
		itemsParent.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (isInRange && Input.GetKeyDown(openKeyCode))
		{
			isOpen = !isOpen;
			itemsParent.gameObject.SetActive(isOpen);

			//if (isOpen)
			//	//character.OpenItemContainer(this);
			//else
				//character.CloseItemContainer(this);
		}
	}

	//private void OnTriggerEnter(Collider other)
	//{
	//	CheckCollision(other.gameObject, true);
	//}

	//private void OnTriggerExit(Collider other)
	//{
	//	CheckCollision(other.gameObject, false);
	//}

	//private void OnTriggerEnter2D(Collider2D collision)
	//{
	//	CheckCollision(collision.gameObject, true);
	//}

	//private void OnTriggerExit2D(Collider2D collision)
	//{
	//	CheckCollision(collision.gameObject, false);
	//}

	//private void CheckCollision(GameObject gameObject, bool state)
	//{
	//	if (gameObject.CompareTag("Player"))
	//	{
	//		isInRange = state;
	//		spriteRenderer.enabled = state;

	//		if (!isInRange && isOpen)
	//		{
	//			isOpen = false;
	//			itemsParent.gameObject.SetActive(false);
	//			//character.CloseItemContainer(this);
	//		}

	//		//if (isInRange)
	//		//	Debug.Log("Hewwo");
	//		//	//character = gameObject.GetComponent<Character>();
	//		//else
	//		//	character = null;
	//	}
	//}

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

	public bool AddItem(Item item)
	{
		//Debug.Log("Adding item " + item + "  to item stash");
		for (int i = 0; i < itemSlots.Length; i++)
		{
			if (itemSlots[i].Item == null || (itemSlots[i].Item.ID == item.ID && itemSlots[i].Amount < item.MaximumStack))
			{
				itemSlots[i].Item = item;
				itemSlots[i].Amount++;
				//items.Add(item);
				Debug.Log("Item " +item+" added to Stash");
				return true;
			}
		}
		return false;
	}

	public void DescribeItems()
    {
		for ( int i = 0; i < itemSlots.Length; i++)
        {
			Debug.Log("Item in " + i + " slot is " + itemSlots[i].Item.name);
        }

    }

	public void InteractWithStash()
    {
		if (isPlayerNear)
		{
			if (stashCanvas.activeInHierarchy)
			{
				stashCanvas.gameObject.SetActive(false);
			}
			else
			{
				stashCanvas.gameObject.SetActive(true);
			}
		}
	}
}
