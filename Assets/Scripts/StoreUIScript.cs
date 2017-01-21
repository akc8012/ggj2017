//Mike's UI Script

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreUIScript : MonoBehaviour
{
    #region Declaring Canvas Groups
    CanvasGroup storeGroup;
    CanvasGroup upgradeGroup;
    CanvasGroup itemGroup;
    #endregion


    // Use this for initialization
    void Start()
    {
        #region Setting Canvas Groups
        storeGroup = GameObject.Find("StorePanel").gameObject.GetComponent<CanvasGroup>();
        upgradeGroup = GameObject.Find("UpgradePanel").gameObject.GetComponent<CanvasGroup>();
        itemGroup = GameObject.Find("ItemPanel").gameObject.GetComponent<CanvasGroup>();
        #endregion

    }

    // Update is called once per frame
    void Update()
    {

    }
}
