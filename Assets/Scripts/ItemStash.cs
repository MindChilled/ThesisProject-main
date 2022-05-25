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


	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Itemstash set to " + this);
			isPlayerNear = true;
			InventoryManager.instance.SetStash(this);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Itemstash has been cleared");
			isPlayerNear = false;
			InventoryManager.instance.SetStash(null);

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

	public virtual int RemoveItemAndCount(int recycleType)
	{
		Debug.Log("RemoveItemAndCount triggered");
		int x = 0;
		for (int i = 0; i < itemSlots.Length; i++)
			{
				if (itemSlots[i].Item != null)
				{
				
					Debug.Log(ItemSlots[i].Item.recycleType + " : this is  item's recycleType");
					Debug.Log("This is recycleType thats given :" + recycleType);
					if (itemSlots[i].Item.recycleType == recycleType)
						{ 
			
								while (itemSlots[i].Amount > 0)
									{
										x = x + itemSlots[i].Item.recycleValue;
										itemSlots[i].Amount--;
									}
								//if (ItemSlots[i].Item == item)
								//{
				
								//	ItemSlots[i].Amount--;
								//	return true;
								//}
						}
					}
				Debug.Log(x + " supposed recycledValue");
				}
		//return false;
		return x;
	}

	//public virtual bool RemoveItem(Item item)
	//{
	//	for (int i = 0; i < itemSlots.Count; i++)
	//	{
	//		if (itemSlots[i].Item == item)
	//		{
	//			itemSlots[i].Amount--;
	//			return true;
	//		}
	//	}
	//	return false;
	//}

}
