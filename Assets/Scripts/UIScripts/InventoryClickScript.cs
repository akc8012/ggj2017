using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventoryClickScript : MonoBehaviour, IPointerDownHandler
{
    InventoryBarScript inventory;

    [SerializeField]
    int index;

    public void OnPointerDown(PointerEventData eventData)
    {
        ItemManager.instance.SpawnItem(inventory.GetStringName(index));
        inventory.RemoveItem(index);
    }

    // Use this for initialization
    void Start()
    {
        //Find and get the inventoryBarScript
        inventory = GameObject.Find("InventoryBar").GetComponent<InventoryBarScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
