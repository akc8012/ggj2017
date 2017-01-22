//Roger 

using UnityEngine;
using System.Collections;

public class Moose : MonoBehaviour
{
    int happiness = 0;
	public int Happiness { get { return happiness; } }

    MoveGuy moveguy;

    public GameObject plaidman;

	public GameObject particle;

    bool addScoreBool = false;

    GameObject waveTimer;

	float storeDelay = 1;
	bool storeDelayBool = false;

    GameObject invBar;
    GameObject store;

    // Use this for initialization
    void Start ()
    {
        moveguy = GetComponent<MoveGuy>();

        waveTimer = GameObject.Find("WaveTimerObject");

        invBar = GameObject.Find("InventoryBar");
        store = GameObject.Find("StoreInventoryCanvas");
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (happiness > 9 && happiness < 50)
        {
            moveguy.Stop();
            addScoreBool = true;
            Destroy(gameObject, 1.1f);
			storeDelayBool = true;
        }

		if (storeDelayBool) {
			storeDelay -= Time.deltaTime;
			if (storeDelay <= 0) {
				storeDelayBool = false;
				storeDelay = 1;
				store.GetComponent<StoreUIScript>().TurnStoreOn();
				invBar.GetComponent<InventoryBarScript>().TurnInventoryOff();
			}
		}

        if (addScoreBool)
        {
			happiness = 100;
            ScoreManager.instance.AddScore(20);
            addScoreBool = false;
        }

        if (InputGuy.instance.IsPressedDuringFrame && InputGuy.instance.IsHoveringOver(gameObject))
        {
            if (PlayerDataManager.Instance.CanClick)
            {
                Instantiate(plaidman, Vector3.zero, Quaternion.identity);
                OnPeoplePress();

				particle.SetActive (true);

                PlayerDataManager.Instance.CanClick = false;
            }
        }

		if (waveTimer.GetComponent<WaveTimer> ().WaveTimerGet > 55) {
			particle.SetActive (false);

		}

        if (PlayerDataManager.Instance.CanClick == false && waveTimer.GetComponent<WaveTimer>().isCounting == false)
            waveTimer.GetComponent<WaveTimer>().isCounting = true;

    }

    void OnPeoplePress()
    {
        if (Input.GetKey("mouse 0"))
        {
            happiness += PlayerDataManager.Instance.ClickPower;
        }
    }
}
