//Roger

using UnityEngine;
using System.Collections;

public class NPCSpawnerR : MonoBehaviour
{
    public GameObject[] testMan;
    GameObject tempMan;

    public GameObject moose;
    GameObject tempMoose;

    public float spawnTimeR = 5.0f;
    public float spawnTimeRMax = 5.0f;

    GameObject redText;
    GameObject whiteText;

    // Use this for initialization
    void Start()
    {
		float zDist = Camera.main.transform.position.z - transform.position.z;

		Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, zDist));
		transform.position = new Vector3(worldPos.x, transform.position.y, transform.position.z);

		int rand = Random.Range (0, 3);
		Vector3 randColor = new Vector3 (Random.Range (0, 100),Random.Range (0, 100),Random.Range (0, 100));
		tempMan = (GameObject)Instantiate(testMan[rand], transform.position, transform.rotation);
		tempMan.GetComponent<SpriteRenderer> ().color = new Color (randColor.x/100,randColor.y/100, randColor.z/100, 1.0f);

        tempMan.GetComponent<MoveGuy>().Direction = 0;
        tempMan.GetComponent<MoveGuy>().speedX = -5.0f;

        redText = GameObject.Find("Canvas/Text RED");
        whiteText = GameObject.Find("Canvas/Text WHITE");
    }


    // Update is called once per frame
    void Update()
    {
        spawnTimeR -= Time.deltaTime;

        if (LevelManager.instance.ManSpawn == true)
        {
            if (spawnTimeR < 0)
            {
                int rand = Random.Range(0, 3);
                Vector3 randColor = new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100));
                tempMan = (GameObject)Instantiate(testMan[rand], transform.position, transform.rotation);
                tempMan.GetComponent<MoveGuy>().Direction = 0;
                tempMan.GetComponent<SpriteRenderer>().color = new Color(randColor.x / 100, randColor.y / 100, randColor.z / 100, 1.0f);

                tempMan.GetComponent<MoveGuy>().speedX = -5.0f;
                spawnTimeR = spawnTimeRMax;
            }
        }

        if(LevelManager.instance.LevelTimer <= 0)
        {
            redText.GetComponent<Click_MooseIsComingScreenWarning>().CallText(false);
            whiteText.GetComponent<Click_MooseIsComingScreenWarning>().CallText(true);
            FasterSpawn();

            LevelManager.instance.Stoptimer();
        }
    }

    public void spawnMoose()
    {
        tempMoose = (GameObject)Instantiate(moose, transform.position, transform.rotation);

        tempMoose.GetComponent<MoveGuy>().Direction = 0;
        tempMoose.GetComponent<MoveGuy>().speedX = -2.5f;
    }

    void FasterSpawn()
    {
        spawnTimeRMax -= 1;

        if (spawnTimeRMax == 0)
        {
            spawnTimeRMax = 1;
        }
    }
}
