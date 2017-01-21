// Roger

using UnityEngine;
using System.Collections;

public class NPCskeleton : MonoBehaviour
{
    int happiness; // canadians happiness level - will instantiate appropriate head!

    MoveGuy moveguy;


    //Color color;  // color of Body randomized

    //int hMod;     // canadian's happiness modifier (difficulty modifier)


    // Use this for initialization
    void Start ()
    {
        happiness = (Random.Range(0, 5));

        moveguy = GetComponent<MoveGuy>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (happiness == 5)
        {
            moveguy.Stop();
            Destroy(gameObject, 0.7f);
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
