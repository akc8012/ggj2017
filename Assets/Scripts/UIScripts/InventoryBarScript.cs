﻿//Mike

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryBarScript : MonoBehaviour
{
    #region Start and End Positions
    Vector2 startPos;
    GameObject endPoint;
    #endregion

    #region Extending
    [SerializeField]
    float speed;
    Button extendButton;
    public bool extended = false;
    #endregion

    [SerializeField]
    Button[] inventorySlots;
    string[] invItems;
    public bool invFull = false;

    [SerializeField]
    CanvasGroup inventoryGroup;

    public Sprite[] itemSprites;


    // Use this for initialization
    void Start()
    {
        //Set the start position to be the starting position
		startPos = this.transform.localPosition;

        endPoint = GameObject.Find("InventoryBarEndPoint");

        //Find the button to extend and minimize the inventory
        extendButton = GameObject.Find("ExtendButton").GetComponent<Button>();

        //Listen for a click
        extendButton.onClick.AddListener(ExtendInventory);

        //Get the inventory canvas group
        inventoryGroup = this.GetComponent<CanvasGroup>();

        invItems = new string[8];

        //Make an array of buttons for the inventory and get the slots
        inventorySlots = new Button[8];
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i] = GameObject.Find("InvSlot_" + i.ToString()).GetComponent<Button>();

            invItems[i] = "Empty";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            TurnInventoryOn();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            TurnInventoryOff();
        }

        for(int i = 0; i < inventorySlots.Length; i++)
        {
            if(invItems[i] == "Empty")
            {
                inventorySlots[i].interactable = false;
            }
            else
            {
                inventorySlots[i].interactable = true;
            }
        }
    }

    #region Adding Items
    public void AddItem(string itemName)
    {
        for(int i = 0; i < invItems.Length; i++)
        {
            if(invItems[i] == "Empty")
            {
                invItems[i] = itemName; //Put the item in the inventory
                //Put the image of the item in the inventory bar
                switch (itemName)
                {
                    case "PoutineItem":
                        inventorySlots[i].image.overrideSprite = itemSprites[0];
                        break;
                    case "BalloonItem":
                        inventorySlots[i].image.overrideSprite = itemSprites[1];
                        break;
                    case "SyrupItem":
                        inventorySlots[i].image.overrideSprite = itemSprites[2];
                        break;
                    case "BagMilkItem":
                        inventorySlots[i].image.overrideSprite = itemSprites[3];
                        break;
                    case "ParadeItem":
                        inventorySlots[i].image.overrideSprite = itemSprites[4];
                        break;
                }
                break;
            }
        }    
    }

    //Checks the inventory to see if it's full or not
    public bool FullInventory()
    {
        int counter = 0;
        for(int i = 0; i < invItems.Length; i++)
        {
            if(invItems[i] != "Empty")
            {
                counter++;
            }
        }
        if(counter >= 8)
        {
            return true;
        }
        else if(counter < 8)
        {
            return false;
        }

        return false;
    }

    public void RemoveItem(int index)
    {
        invItems[index] = "Empty";
        inventorySlots[index].image.overrideSprite = null;
    }
    #endregion

    public string GetStringName(int i)
    {
        return invItems[i];
    }

    #region Coroutines and Functions for extending and detracting the inventory bar
    public void ExtendInventory()
    {
        if (!extended)
            StartCoroutine(Extend());
        else
            StartCoroutine(Detract());
    }

    public void DetractOnClick()
    {
        if (extended)
            StartCoroutine(Detract());
    }

    IEnumerator Extend()
    {
        extendButton.interactable = false;
		while (Vector2.Distance(transform.localPosition, endPoint.transform.localPosition) > 0.1f)
        {
			transform.localPosition = Vector2.Lerp(transform.localPosition, endPoint.transform.localPosition, speed * Time.deltaTime);
            yield return null;
        }
        extended = !extended;
        extendButton.interactable = true;
    }

    IEnumerator Detract()
    {
        extendButton.interactable = false;
		while (Vector2.Distance(transform.localPosition, startPos) > 0.1f)
        {
			transform.localPosition = Vector2.Lerp(transform.localPosition, startPos, speed * Time.deltaTime);
            yield return null;
        }
        extended = !extended;
        extendButton.interactable = true;
    }
    #endregion

    #region Turning Inventory On and Off
    public void TurnInventoryOn()
    {
        inventoryGroup.alpha = 1f;
        inventoryGroup.interactable = true;
        inventoryGroup.blocksRaycasts = true;
    }
    public void TurnInventoryOff()
    {
        inventoryGroup.alpha = 0;
        inventoryGroup.interactable = false;
        inventoryGroup.blocksRaycasts = false;
    }
    #endregion


}