// Roger

using UnityEngine;
using System.Collections;

public class NPCskeleton : MonoBehaviour
{
    //int cScore = 0;       // canada score (temp, this value might be somewhere else eventually)
    //int cValue;      // Canadians canada score value
    //int cLoss;      // Loss of points when canadians leave

    int happiness; // canadians happiness level - will instantiate appropriate head!

    //Color color;  // color of Body randomized

   // int hMod;     // canadian's happiness modifier (difficulty modifier)



	// Use this for initialization
	void Start ()
    {
        //cLoss = 5;
        //cValue = 10;

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
    }

    void OnMouseDown()
    {
        if (Input.GetKey("mouse 0"))
        {
            happiness += 1;
            Debug.Log("happiness = " + happiness);
        }
    }
}
