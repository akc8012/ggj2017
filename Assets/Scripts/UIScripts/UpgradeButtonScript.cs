//Mike

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeButtonScript : MonoBehaviour
{
    [SerializeField]
    bool isBought = false;

    Button parentButton;
    [SerializeField]
    int price;
    [SerializeField]
    string upgradeName;

    Text upgradePrice;

    StoreUIScript store;

    // Use this for initialization
    void Start()
    {
        parentButton = this.GetComponent<Button>();
        isBought = false;

        upgradePrice = gameObject.transform.FindChild("Price").GetComponent<Text>();
        store = GameObject.Find("StoreInventoryCanvas").GetComponent<StoreUIScript>();

        parentButton.onClick.AddListener(IsPaidFor);
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreManager.instance.Score < price)
        {
            parentButton.interactable = false;
        }
        else if (ScoreManager.instance.Score >= price && !isBought)
        {
            parentButton.interactable = true;
        }

        if(isBought)
        {
            parentButton.interactable = false;
        }

        if(upgradeName == "Wave")
        {
            parentButton.interactable = false;
        }

        upgradePrice.text = "$" + price.ToString();
    }

    public void IsPaidFor()
    {
        //Check to make sure the player has the money.
        //If so, buy the upgrade and change isBought to true
        if (ScoreManager.instance.Score >= price)
        {
            isBought = true;
            ScoreManager.instance.AddScore(-price);
            PlayerDataManager.Instance.IncreasePowerLevel();
            store.DisplayFeedback(upgradeName);
        }
    }

    public void ResetPayment()
    {
        isBought = false;
    }
}
