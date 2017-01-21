// Roger

using UnityEngine;
using System.Collections;

public class NPCskeleton : MonoBehaviour
{
    int happiness; // canadians happiness level - will instantiate appropriate head!
    public int Happiness { get { return happiness; } }

    MoveGuy moveguy;

    int waveTimer = 0;

    //Color color;  // color of Body randomized

    //int hMod;     // canadian's happiness modifier (difficulty modifier)


    // Use this for initialization
    void Start ()
    {
        PlayerDataManager.Instance.CanClick = true;

        happiness = (Random.Range(0, 4));
    
        moveguy = GetComponent<MoveGuy>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (happiness > 3)
        {
            moveguy.Stop();
            Destroy(gameObject, 0.7f);
            ScoreManager.instance.AddScore(5);
        }

        if (InputGuy.instance.IsPressedDuringFrame && InputGuy.instance.IsHoveringOver(gameObject))
        {
            if (PlayerDataManager.Instance.CanClick)
                 OnPeoplePress();

            PlayerDataManager.Instance.CanClick = false;
        }

        if(PlayerDataManager.Instance.CanClick == false)
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
            Debug.Log("happiness = " + happiness);
        }
    }

    public void MakeHappy()
    {
        happiness = 7;
    }
}
