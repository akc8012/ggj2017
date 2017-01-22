// TRISTAN

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Click_MooseIsComingScreenWarning : MonoBehaviour {

	int textSizeCounter = 1;

	bool startBool = false;

    float mooseCounter = 2;

    bool mooseCounterStart = false;

    bool checkyCheck = false;

    public AudioClip mooseComes;
    AudioSource audiosource;


	void Start ()
    {
        audiosource = GetComponent<AudioSource>();
	}

	void Update ()
    {
        if (mooseCounterStart)
        {
            mooseCounter -= Time.deltaTime;
        }

        if(mooseCounter <= 0)
        {
            mooseCounter = 2;
            textSizeCounter = 1;
            this.GetComponent<Text>().fontSize = textSizeCounter;

            if (checkyCheck)
            {
                GameObject.Find("SpawnerR").GetComponent<NPCSpawnerR>().spawnMoose();
            }
            
            mooseCounterStart = false;
        }

		if (startBool) {
            if (textSizeCounter < 144)
            {
                this.GetComponent<Text>().fontSize = textSizeCounter;
                textSizeCounter += 4;
            }
            else
            {
                startBool = false;
                mooseCounterStart = true;
            }
		}
	}

    public void CallText(bool check)
    {
        checkyCheck = check;
        audiosource.PlayOneShot(mooseComes, 0.8f);
        startBool = true;
    }
}
