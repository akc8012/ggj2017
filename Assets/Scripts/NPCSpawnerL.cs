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
		float zDist = Camera.main.transform.position.z - transform.position.z;

		Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, zDist));
		transform.position = new Vector3(worldPos.x, transform.position.y, transform.position.z);

        tempMan = new GameObject();
        tempMan = (GameObject)Instantiate(testMan, transform.position, transform.rotation);

        tempMan.GetComponent<MoveGuy>().Direction = 1;
        tempMan.GetComponent<MoveGuy>().speedX = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
		//Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
		//transform.position = new Vector3(worldPos.x, transform.position.y, transform.position.z);



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
