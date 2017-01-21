//Roger 

using UnityEngine;
using System.Collections;

public class Moose : MonoBehaviour
{
    int happiness = 0;

    int waveTimer = 0;

    MoveGuy moveguy;

    // Use this for initialization
    void Start ()
    {
        moveguy = GetComponent<MoveGuy>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (happiness > 19)
        {
            moveguy.Stop();
            Destroy(gameObject, 0.7f);
            ScoreManager.instance.AddScore(20);
        }

        if (InputGuy.instance.IsPressedDuringFrame && InputGuy.instance.IsHoveringOver(gameObject))
        {
            if (PlayerDataManager.Instance.CanClick)
                OnPeoplePress();

            PlayerDataManager.Instance.CanClick = false;
        }

        if (PlayerDataManager.Instance.CanClick == false)
            waveTimer += 1;

        if (waveTimer >= PlayerDataManager.Instance.ClickDelay)
        {
            PlayerDataManager.Instance.CanClick = true;
            waveTimer = 0;
        }
    }

    void OnPeoplePress()
    {
        if (Input.GetKey("mouse 0"))
        {
            happiness += PlayerDataManager.Instance.ClickPower;
            Debug.Log("Moose = " + happiness);
        }
    }
}
