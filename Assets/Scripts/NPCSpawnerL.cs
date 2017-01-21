//Roger

using UnityEngine;
using System.Collections;

public class NPCSpawnerL : MonoBehaviour
{
    public GameObject testMan;
    GameObject tempMan;

    public float spawnTimeL = 5.0f; // spawn timer

    // Use this for initialization
    void Start()
    {
        Camera cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(10, 0, 0));
        Debug.Log(p);
        transform.position = new Vector3(p.x, transform.position.y, transform.position.z);

        tempMan = new GameObject();
        tempMan = (GameObject)Instantiate(testMan, transform.position, transform.rotation);

        tempMan.GetComponent<MoveGuy>().Direction = 1;
        tempMan.GetComponent<MoveGuy>().speedX = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimeL -= Time.deltaTime;

        if (spawnTimeL < 0)
        {
            tempMan = new GameObject();
            tempMan = (GameObject)Instantiate(testMan, transform.position, transform.rotation);
            tempMan.GetComponent<MoveGuy>().Direction = 1;

            tempMan.GetComponent<MoveGuy>().speedX = 0.1f;
            spawnTimeL = 5.0f;
        }
    }
}
