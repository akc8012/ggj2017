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

        //Make an array of buttons for the inventory and get the slots
        inventorySlots = new Button[8];
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i] = GameObject.Find("InvSlot_" + i.ToString()).GetComponent<Button>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Adding Items

    #endregion

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