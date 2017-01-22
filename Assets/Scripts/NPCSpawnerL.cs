//Roger

using UnityEngine;
using System.Collections;

public class NPCSpawnerL : MonoBehaviour
{
    public GameObject[] testMan;
    GameObject tempMan;

    public float spawnTimeL = 5.0f; // spawn timer
    float spawnTimeLMax = 5.0f;

    // Use this for initialization
    void Start()
    {
		float zDist = Camera.main.transform.position.z - transform.position.z;

		Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, zDist));
		transform.position = new Vector3(worldPos.x, transform.position.y, transform.position.z);

		int rand = Random.Range (0, 3);
		Vector3 randColor = new Vector3 (Random.Range (0, 100),Random.Range (0, 100),Random.Range (0, 100));

		tempMan = (GameObject)Instantiate(testMan[rand], transform.position, transform.rotation);
		//tempMan.GetComponent<SpriteRenderer> ().color = new Color (randColor.x,randColor.y, randColor.z, 1.0f);
		tempMan.GetComponent<SpriteRenderer> ().color = new Color (randColor.x/100,randColor.y/100, randColor.z/100, 1.0f);

        tempMan.GetComponent<MoveGuy>().Direction = 1;
        tempMan.GetComponent<MoveGuy>().speedX = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
		spawnTimeL -= Time.deltaTime;

        if (LevelManager.instance.ManSpawn == true)
        {
            if (spawnTimeL < 0)
            {
                int rand = Random.Range(0, 3);
                Vector3 randColor = new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100));

                tempMan = (GameObject)Instantiate(testMan[rand], transform.position, transform.rotation);
                tempMan.GetComponent<MoveGuy>().Direction = 1;
                tempMan.GetComponent<SpriteRenderer>().color = new Color(randColor.x / 100, randColor.y / 100, randColor.z / 100, 1.0f);

                tempMan.GetComponent<MoveGuy>().speedX = 5.0f;
                spawnTimeL = spawnTimeLMax;
            }
        }

        if (LevelManager.instance.LevelTimer <= 0)
        {
            FasterSpawn();
        }
    }

    void FasterSpawn()
    {
        spawnTimeLMax -= 1;
    }
}
