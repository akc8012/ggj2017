//Roger

using UnityEngine;
using System.Collections;

public class NPCSpawnerR : MonoBehaviour
{
    public GameObject testMan;

    public float spawnTimeR = 5.0f;

    // Use this for initialization
    void Start()
    {
        GameObject tempMan = new GameObject();
        tempMan = (GameObject)Instantiate(testMan, transform.position, transform.rotation);
        tempMan.GetComponent<MoveGuy>().speedX = -0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimeR -= Time.deltaTime;

        if (spawnTimeR < 0)
        {
            GameObject tempMan = new GameObject();
            tempMan = (GameObject)Instantiate(testMan, transform.position, transform.rotation);
            tempMan.GetComponent<MoveGuy>().speedX = -0.1f;

            spawnTimeR = 5.0f;
        }
    }
}
