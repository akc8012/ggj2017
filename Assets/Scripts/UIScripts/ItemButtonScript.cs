//Mike

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemButtonScript : MonoBehaviour
{

    [SerializeField]
    int price;
    [SerializeField]
    string itemName;
    [SerializeField]
    string displayName;

    Button parentButton;
    InventoryBarScript invScript;
    StoreUIScript store;

    Text displayPrice;

    //Get reference to player for what's in the inventory

    // Use this for initialization
    void Start()
    {
        parentButton = this.GetComponent<Button>();
        invScript = GameObject.Find("InventoryBar").GetComponent<InventoryBarScript>();
        store = GameObject.Find("Canvas").GetComponent<StoreUIScript>();

        displayPrice = gameObject.transform.FindChild("Price").GetComponent<Text>();

        parentButton.onClick.AddListener(PayForItem);
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreManager.instance.Score < price)
        {
            parentButton.interactable = false;
        }
        else
        {
            parentButton.interactable = true;
        }

        displayPrice.text = "$" + price.ToString();
    }

    //Check to see if the player has the score to be able to pay for the item.
    public void PayForItem()
    {
        if(ScoreManager.instance.Score >= price)
        {
            switch(invScript.FullInventory())
            {
                case true:
                    break;
                case false:
                    ScoreManager.instance.AddScore(-price);
                    invScript.SendMessage("AddItem", itemName);
                    store.DisplayFeedback(displayName);
                    break;
            }
        }
    }
}
