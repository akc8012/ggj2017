//Roger

using UnityEngine;
using System.Collections;

public class NPCSpawner : MonoBehaviour
{
    public GameObject testMan;

    float spawnTime = 5.0f;

    // Use this for initialization
    void Start ()
    {
        Instantiate(testMan, transform.position, transform.rotation);
    }
	
	// Update is called once per frame
	void Update ()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime < 0)
        {
            Instantiate(testMan, transform.position, transform.rotation);
            spawnTime = 5.0f;
        }
    }
}
