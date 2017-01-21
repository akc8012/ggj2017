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

    // Use this for initialization
    void Start()
    {
        parentButton = this.GetComponent<Button>();
        isBought = false;

        parentButton.onClick.AddListener(IsPaidFor);
    }

    // Update is called once per frame
    void Update()
    {
        if(isBought)
        {
            parentButton.interactable = false;
        }
    }

    public void IsPaidFor()
    {
        //Check to make sure the player has the money.
        //If so, buy the upgrade and change isBought to true
        if (ScoreManager.instance.Score >= price)
        {
            isBought = true;
            ScoreManager.instance.AddScore(-price);
        }
    }

    public void ResetPayment()
    {
        isBought = false;
    }
}
