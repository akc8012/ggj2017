//Mike's UI Script

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreUIScript : MonoBehaviour
{
    #region Declaring Canvas Groups
    [SerializeField]
    CanvasGroup storeGroup;
    [SerializeField]
    CanvasGroup upgradeGroup;
    [SerializeField]
    CanvasGroup itemGroup;
    #endregion

    #region Declaring Buttons
    [SerializeField]
    Button upgradeButton;
    [SerializeField]
    Button itemButton;
    [SerializeField]
    Button nextLevelButton;
    #endregion


    // Use this for initialization
    void Start()
    {
        #region Setting Canvas Groups
        storeGroup = GameObject.Find("StorePanel").gameObject.GetComponent<CanvasGroup>();
        upgradeGroup = GameObject.Find("UpgradePanel").gameObject.GetComponent<CanvasGroup>();
        itemGroup = GameObject.Find("ItemPanel").gameObject.GetComponent<CanvasGroup>();
        #endregion

        upgradeButton = GameObject.Find("UpgradesButton").gameObject.GetComponent<Button>();
        itemButton = GameObject.Find("ItemsButton").gameObject.GetComponent<Button>();
        nextLevelButton = GameObject.Find("NextLevelButton").gameObject.GetComponent<Button>();

        //Sets all canvas groups to be invisible and non-active at the beginning
        storeGroup.alpha = 0;
        storeGroup.interactable = false;
        storeGroup.blocksRaycasts = false;
        itemGroup.alpha = 0;
        itemGroup.interactable = false;
        itemGroup.blocksRaycasts = false;
        upgradeGroup.alpha = 0;
        upgradeGroup.interactable = false;
        upgradeGroup.blocksRaycasts = false;
        //----------------------------------------------------------------------//


        upgradeButton.onClick.AddListener(SwitchToUpgrades);
        itemButton.onClick.AddListener(SwitchToItems);
        nextLevelButton.onClick.AddListener(GoToNextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            storeGroup.alpha = 1;
            storeGroup.interactable = true;
            storeGroup.blocksRaycasts = true;

            upgradeGroup.alpha = 1;
            upgradeGroup.interactable = true;
            upgradeGroup.blocksRaycasts = true;
        }
    }

    //Switches the Store Panel to Upgrades section
    void SwitchToUpgrades()
    {
        upgradeGroup.alpha = 1;
        upgradeGroup.interactable = true;
        upgradeGroup.blocksRaycasts = true;

        itemGroup.alpha = 0;
        itemGroup.interactable = false;
        itemGroup.blocksRaycasts = false;
    }

    //Switches the store panel to items section
    void SwitchToItems()
    {
        upgradeGroup.alpha = 0;
        upgradeGroup.interactable = false;
        upgradeGroup.blocksRaycasts = false;

        itemGroup.alpha = 1;
        itemGroup.interactable = true;
        itemGroup.blocksRaycasts = true;
    }

    //Goes to the next level
    void GoToNextLevel()
    {
        storeGroup.alpha = 0;
        storeGroup.interactable = false;
        storeGroup.blocksRaycasts = false;
        itemGroup.alpha = 0;
        itemGroup.interactable = false;
        itemGroup.blocksRaycasts = false;
        upgradeGroup.alpha = 0;
        upgradeGroup.interactable = false;
        upgradeGroup.blocksRaycasts = false;
    }
}
