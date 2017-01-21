// Roger

using UnityEngine;
using System.Collections;

public class NPCskeleton : MonoBehaviour
{
    //int cLoss;      // Loss of points when canadians leave

    int happiness; // canadians happiness level - will instantiate appropriate head!

    ////despawn stuff
    //public Transform target;
    //Camera cam;

    //Color color;  // color of Body randomized

    //int hMod;     // canadian's happiness modifier (difficulty modifier)


    // Use this for initialization
    void Start ()
    {
        //cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        happiness = (Random.Range(0, 5));
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Vector3 screenPos = cam.WorldToScreenPoint(target.position);

        if (happiness == 5)
        {
            Destroy(gameObject);
            ScoreManager.instance.AddScore(5);
        }

        if (InputGuy.instance.IsPressedDuringFrame && InputGuy.instance.IsHoveringOver(gameObject))
        {

            OnPeoplePress();
        }

        //if (screenPos.x < 0 - 20 || screenPos.x > Screen.width + 20)
        //{
        //    Destroy(gameObject);
        //    ScoreManager.instance.AddScore(-2);
        //    Debug.Log("i'm dead");
        //}
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
