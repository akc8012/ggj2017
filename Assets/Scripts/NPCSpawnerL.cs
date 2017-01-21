//Roger

using UnityEngine;
using System.Collections;

public class NPCSpawnerL : MonoBehaviour
{
    public GameObject testMan;

    public float spawnTimeL = 5.0f; // spawn timer

    float despawnTimer = 10.0f;   // despawn timer

    // Use this for initialization
    void Start()
    {
        GameObject tempMan = new GameObject();
        tempMan = (GameObject)Instantiate(testMan, transform.position, transform.rotation);

        tempMan.GetComponent<MoveGuy>().speedX = 0.1f;

        //speedX = speed;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimeL -= Time.deltaTime;

        if (spawnTimeL < 0)
        {
            GameObject tempMan = new GameObject();
            tempMan = (GameObject)Instantiate(testMan, transform.position, transform.rotation);

            tempMan.GetComponent<MoveGuy>().speedX = 0.1f;
            spawnTimeL = 5.0f;

            //despawnTimer -= Time.deltaTime;

            //if (despawnTimer < 0)
            //{
            //    tempMan
            //}
        }


    }
}
