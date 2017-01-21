//Mike

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryBarScript : MonoBehaviour
{
    #region Start and End Positions
    Vector2 startPos;
    [SerializeField]
    Vector2 endPos;
    #endregion

    #region Extending
    [SerializeField]
    float speed;
    Button extendButton;
    bool extended = false;
    #endregion

    [SerializeField]
    Button[] inventorySlots;
    string[] invItems;
    public bool invFull = false;

    public Sprite[] itemSprites;


    // Use this for initialization
    void Start()
    {
        //Set the start position to be the starting position
        startPos = this.transform.position;

        //Set the end position
        endPos = new Vector2(482, this.transform.position.y);

        //Find the button to extend and minimize the inventory
        extendButton = GameObject.Find("ExtendButton").GetComponent<Button>();

        //Listen for a click
        extendButton.onClick.AddListener(ExtendInventory);

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
    void ExtendInventory()
    {
        if (!extended)
            StartCoroutine(Extend());
        else
            StartCoroutine(Detract());
    }

    IEnumerator Extend()
    {
        extendButton.interactable = false;
        while (Vector2.Distance(transform.position, endPos) > 0.1f)
        {
            transform.position = Vector2.Lerp(transform.position, endPos, speed * Time.deltaTime);
            yield return null;
        }
        extended = !extended;
        extendButton.interactable = true;
    }

    IEnumerator Detract()
    {
        extendButton.interactable = false;
        while (Vector2.Distance(transform.position, startPos) > 0.1f)
        {
            transform.position = Vector2.Lerp(transform.position, startPos, speed * Time.deltaTime);
            yield return null;
        }
        extended = !extended;
        extendButton.interactable = true;
    }
    #endregion

}