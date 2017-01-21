//Mike's UI Script

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public CanvasGroup storeGroup;
    public CanvasGroup upgradeGroup;
    public CanvasGroup itemGroup;


    // Use this for initialization
    void Start()
    {
        storeGroup = GameObject.Find("StorePanel").gameObject.GetComponent<CanvasGroup>();
        upgradeGroup = GameObject.Find("UpgradePanel").gameObject.GetComponent<CanvasGroup>();
        itemGroup = GameObject.Find("ItemPanel").gameObject.GetComponent<CanvasGroup>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
