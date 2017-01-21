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

    Button parentButton;
    InventoryBarScript invScript;

    //Get reference to player for what's in the inventory

    // Use this for initialization
    void Start()
    {
        parentButton = this.GetComponent<Button>();
        invScript = GameObject.Find("InventoryBar").GetComponent<InventoryBarScript>();

        parentButton.onClick.AddListener(PayForItem);
    }

    // Update is called once per frame
    void Update()
    {

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
                    break;
            }
        }
    }
}
