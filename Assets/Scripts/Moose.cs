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

    GameObject waveTimer;

    bool isDead = false;

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
        if (happiness > 9)
        {
            moveguy.Stop();
            Destroy(gameObject, 0.7f);
            ScoreManager.instance.AddScore(20);
            store.GetComponent<StoreUIScript>().TurnStoreOn();
            invBar.GetComponent<InventoryBarScript>().TurnInventoryOn();


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
