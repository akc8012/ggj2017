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

    #region Declaring War against the Communist dickheads over in North Korea
    Text currencyText;
    #endregion

    int upgradeIndex;
    bool onUpgrades = true;


    // Use this for initialization
    void Start()
    {
        #region Setting Canvas Groups
        storeGroup = GameObject.Find("StorePanel").gameObject.GetComponent<CanvasGroup>();
        upgradeGroup = GameObject.Find("UpgradePanel").gameObject.GetComponent<CanvasGroup>();
        itemGroup = GameObject.Find("ItemPanel").gameObject.GetComponent<CanvasGroup>();
        #endregion

        currencyText = GameObject.Find("CurrencyText").GetComponent<Text>();

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


        upgradeIndex = upgradeGroup.transform.GetSiblingIndex();

        upgradeButton.onClick.AddListener(SwitchToUpgrades);
        itemButton.onClick.AddListener(SwitchToItems);
        nextLevelButton.onClick.AddListener(GoToNextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            TurnStoreOn();
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            TurnStoreOff();
        }

        //Checks if the store screen is on upgrades or not.  Makes sure the folders flip when needed.
        if(onUpgrades)
        {
            upgradeGroup.transform.SetSiblingIndex(upgradeIndex);
        }
        else
        {
            itemGroup.transform.SetSiblingIndex(upgradeIndex);
        }

        //Update the CanadaCredit
        currencyText.text = ScoreManager.instance.Score.ToString();
    }

    //Switches the Store Panel to Upgrades section
    void SwitchToUpgrades()
    {
        onUpgrades = true;
        upgradeGroup.interactable = true;
        upgradeGroup.blocksRaycasts = true;

        itemGroup.interactable = false;
        itemGroup.blocksRaycasts = false;
    }

    //Switches the store panel to items section
    void SwitchToItems()
    {
        onUpgrades = false;
        upgradeGroup.interactable = false;
        upgradeGroup.blocksRaycasts = false;

        itemGroup.transform.SetSiblingIndex(1);
        itemGroup.interactable = true;
        itemGroup.blocksRaycasts = true;
    }

    //Goes to the next level
    void GoToNextLevel()
    {
        TurnStoreOff();
    }

    public void TurnStoreOn()
    {
        storeGroup.alpha = 1f;
        storeGroup.interactable = true;
        storeGroup.blocksRaycasts = true;
        upgradeGroup.alpha = 1f;
        itemGroup.alpha = 1f;
        SwitchToUpgrades();
    }
    public void TurnStoreOff()
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
