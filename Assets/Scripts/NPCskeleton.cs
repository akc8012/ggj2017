// Roger

using UnityEngine;
using System.Collections;

public class NPCskeleton : MonoBehaviour
{
    int happiness; // canadians happiness level - will instantiate appropriate head!
    public int Happiness { get { return happiness; } }

    MoveGuy moveguy;

    GameObject waveTimer;

    bool addScoreBool = false;

    public GameObject particle;

    public GameObject plaidman;

    //Color color;  // color of Body randomized

    //int hMod;     // canadian's happiness modifier (difficulty modifier)


    // Use this for initialization
    void Start ()
    {
        happiness = (Random.Range(0, 4));
    
        moveguy = GetComponent<MoveGuy>();

        waveTimer = GameObject.Find("WaveTimerObject");

		particle.SetActive (false);

    }
	
	// Update is called once per frame
	void Update ()
    {
		if (happiness > 3 && happiness < 50)
        {
            moveguy.Stop();
            addScoreBool = true;
            Destroy(gameObject, 0.7f);
        }

        if (addScoreBool)
        {
			happiness = 100;
            ScoreManager.instance.AddScore(5);
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
            //Debug.Log("happiness = " + happiness);
        }
    }

    public void MakeHappy()
    {
        happiness = 4;      // needs to be set to 4 to work with Tristan face changing
		particle.SetActive(true);
	}
}
