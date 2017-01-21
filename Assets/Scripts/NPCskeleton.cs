// Roger

using UnityEngine;
using System.Collections;

public class NPCskeleton : MonoBehaviour
{
    //int cLoss;      // Loss of points when canadians leave

    int happiness; // canadians happiness level - will instantiate appropriate head!

    //Color color;  // color of Body randomized

    //int hMod;     // canadian's happiness modifier (difficulty modifier)


    // Use this for initialization
	void Start ()
    {
       // cLoss = 2;

        happiness = (Random.Range(0, 5));
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (happiness == 5)
        {
            Destroy(gameObject);
            ScoreManager.instance.AddScore(5);
        }

        if (InputGuy.instance.IsPressedDuringFrame && InputGuy.instance.IsHoveringOver(gameObject))
        {

            OnPeoplePress();
        }
    }

    void OnPeoplePress()
    {
        if (Input.GetKey("mouse 0"))
        {
            happiness += 1;
            Debug.Log("happiness = " + happiness);
        }
    }
}
