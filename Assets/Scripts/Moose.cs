//Roger 

using UnityEngine;
using System.Collections;

public class Moose : MonoBehaviour
{
    int happiness = 0;

    MoveGuy moveguy;

    public GameObject plaidman;

    GameObject waveTimer;

   // bool isDead = false;

    // Use this for initialization
    void Start ()
    {
        moveguy = GetComponent<MoveGuy>();

        waveTimer = GameObject.Find("WaveTimerObject");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (happiness > 9)
        {
            moveguy.Stop();
            Destroy(gameObject, 0.7f);
            ScoreManager.instance.AddScore(20);
           // isDead = true;
        }

        if (InputGuy.instance.IsPressedDuringFrame && InputGuy.instance.IsHoveringOver(gameObject))
        {
            if (PlayerDataManager.Instance.CanClick)
            {
                Instantiate(plaidman, Vector3.zero, Quaternion.identity);
                OnPeoplePress();

                PlayerDataManager.Instance.CanClick = false;
            }
        }

        if (PlayerDataManager.Instance.CanClick == false && waveTimer.GetComponent<WaveTimer>().isCounting == false)
            waveTimer.GetComponent<WaveTimer>().isCounting = true;

    }

    void OnPeoplePress()
    {
        if (Input.GetKey("mouse 0"))
        {
            happiness += PlayerDataManager.Instance.ClickPower;
            //Debug.Log("Moose = " + happiness);
        }
    }
}
