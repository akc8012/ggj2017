//Mike

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemButtonScript : MonoBehaviour
{

    [SerializeField]
    int price;
    Button parentButton;

    //Get reference to player for what's in the inventory

    // Use this for initialization
    void Start()
    {
        parentButton = this.GetComponent<Button>();

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
            //Add item to the inventory of the player and subtract the price from the player score

            ScoreManager.instance.AddScore(-price);
        }
    }
}
