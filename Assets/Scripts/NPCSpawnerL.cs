//Roger

using UnityEngine;
using System.Collections;

public class NPCSpawnerL : MonoBehaviour
{
    public GameObject testMan;

    public float spawnTime = 5.0f;

    //float manSpeed;  // getting speed variable from skeleton script
    public float speed = 0.1f;

    // Use this for initialization
    void Start()
    {
        Instantiate(testMan, transform.position, transform.rotation);

        testMan.GetComponent<NPCskeleton>().speedX = speed;

        //manSpeed = testMan.GetComponent<NPCskeleton>().speedX;


    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime < 0)
        {
            Instantiate(testMan, transform.position, transform.rotation);
            spawnTime = 5.0f;
        }
    }
}
