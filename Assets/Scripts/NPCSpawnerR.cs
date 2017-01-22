//Roger

using UnityEngine;
using System.Collections;

public class NPCSpawnerR : MonoBehaviour
{
    public GameObject testMan;
    GameObject tempMan;

    public GameObject moose;
    GameObject tempMoose;

    public float spawnTimeR = 5.0f;

    // Use this for initialization
    void Start()
    {
		float zDist = Camera.main.transform.position.z - transform.position.z;

		Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, zDist));
		transform.position = new Vector3(worldPos.x, transform.position.y, transform.position.z);

		tempMan = new GameObject();
        tempMan = (GameObject)Instantiate(testMan, transform.position, transform.rotation);

        tempMan.GetComponent<MoveGuy>().Direction = 0;
        tempMan.GetComponent<MoveGuy>().speedX = -5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimeR -= Time.deltaTime;

        if (spawnTimeR < 0)
        {
            tempMan = new GameObject();
            tempMan = (GameObject)Instantiate(testMan, transform.position, transform.rotation);
            tempMan.GetComponent<MoveGuy>().Direction = 0;

            tempMan.GetComponent<MoveGuy>().speedX = -5.0f;
            spawnTimeR = 5.0f;
        }

        if(Input.GetKeyDown("m"))
        {
            spawnMoose();
        }
    }

    void spawnMoose()
    {
        tempMoose = new GameObject();
        tempMoose = (GameObject)Instantiate(moose, transform.position, transform.rotation);

        tempMoose.GetComponent<MoveGuy>().Direction = 0;
        tempMoose.GetComponent<MoveGuy>().speedX = -0.05f;
    }
}
