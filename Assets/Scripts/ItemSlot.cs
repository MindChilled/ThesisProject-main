using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    //public event Action<BaseItemSlot> OnBeginDragEvent;
    //public event Action<BaseItemSlot> OnEndDragEvent;
    //public event Action<BaseItemSlot> OnDragEvent;
    //public event Action<BaseItemSlot> OnDropEvent;


    private bool isDragging;
    //private Color dragColor = new Color(1, 1, 1, 0.5f);

    //public override bool CanAddStack(Item item, int amount = 1)
    //{
    //    return base.CanAddStack(item, amount) && Amount + amount <= item.MaximumStack;
    //}

    //public override bool CanReceiveItem(Item item)
    //{
    //    return true;
    //}

    //protected override void OnDisable()
    //{
    //    base.OnDisable();

    //    if (isDragging)
    //    {
    //        OnEndDrag(null);
    //    }
    //}

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("On dragging start");

        isDragging = true;

        if (Item != null)
            //image.color = dragColor;

        if (OnBeginDragEvent != null)
            OnBeginDragEvent(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging stop");

        isDragging = false;

        if (Item != null)
            //image.color = normalColor;

        if (OnEndDragEvent != null)
            OnEndDragEvent(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging start");
        if (OnDragEvent != null)
            OnDragEvent(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop start");

        if (OnDropEvent != null)
            OnDropEvent(this);
    }

    [SerializeField] Image Image;
    //[SerializeField] TMP_Text amountText;
    [SerializeField] Text amountText;

    public event Action<ItemSlot> OnPointerEnterEvent;
    public event Action<ItemSlot> OnPointerExitEvent;
    public event Action<Item> OnRightClickEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;
    protected Item _item;
    public Item Item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item == null)
            {
                Image.enabled = false;
            }
            else
            {
                Image.sprite = _item.ItemIcon;
                Image.enabled = true;
            }
        }
    }

    private int _amount;
    public int Amount
    {
        get { return _amount; }
        set
        {
            _amount = value;
            if (_amount < 0) _amount = 0;
            if (_amount == 0 && Item != null) Item = null;
            //Debug.Log(amountText);

            if (amountText != null)
            {
                amountText.enabled = _item != null && _amount > 1;
                if (amountText.enabled)
                {
                    amountText.text = _amount.ToString();
                }
            }
        }
    }

    public  bool CanAddStack(Item item, int amount = 1)
    {
        return Item != null && Item.ID == item.ID && Amount + amount <= item.MaximumStack;
        
    }

    public void Update()
    {
        if (_item != null && _amount > 1)
        {
            amountText.text = _amount.ToString();
        }
    }

    public void AddItemToStash()
    {
        InventoryManager.instance.AddItemToStash(Item);
        //Debug.Log("Item is : " + Item.ItemName);
    }

    public void AddItemToInven()
    {
        InventoryManager.instance.RemoveItemFromStash(Item);
    }

    public void Start()
    {
        amountText = GetComponentInChildren<Text>();
        amountText.text = "";

    }
    protected virtual void OnValidate()
    {
        if (Image == null)
            Image = GetComponent<Image>();

        if (amountText == null)
            amountText = GetComponentInChildren<Text>();
        //Debug.Log("Acquired amountText : " + amountText);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null)
        {
            if (Item != null)
            {
                //Debug.Log("OnRightClickEvent is supposed to go here");
                OnRightClickEvent(Item);
            }
        }
        //throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
