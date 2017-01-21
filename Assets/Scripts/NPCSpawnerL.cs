//Roger

using UnityEngine;
using System.Collections;

public class NPCSpawnerL : MonoBehaviour
{
    public GameObject testMan;

    public float spawnTimeL = 5.0f; // spawn timer

    // Use this for initialization
    void Start()
    {
        GameObject tempMan = new GameObject();
        tempMan = (GameObject)Instantiate(testMan, transform.position, transform.rotation);

        tempMan.GetComponent<MoveGuy>().speedX = 0.1f;
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
        }

    }
}
