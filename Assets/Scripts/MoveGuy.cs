//Roger!

using UnityEngine;
using System.Collections;

public class MoveGuy : MonoBehaviour
{
    public float speedX; // canadian horizontal speed    
    public float speedY; // canadian vertical speed

    //despawn stuff
    Camera cam;

    public Vector3 screenPos;

    int direction = 0;

    public int Direction { set { direction = value; } }

    public bool isMoose = false;

    GameObject invBar;
    GameObject store;

    // Use this for initialization
    void Start ()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        invBar = GameObject.Find("InventoryBar");
        store = GameObject.Find("StoreInventoryCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        screenPos = cam.WorldToScreenPoint(transform.position);

        if (direction == 0)
        { 
            if (screenPos.x < -20)
            {
                if (isMoose)
                {
                    Destroy(this.gameObject);
                    ScoreManager.instance.AddScore(-10);
                    store.GetComponent<StoreUIScript>().TurnStoreOn();
                    invBar.GetComponent<InventoryBarScript>().TurnInventoryOn();
                }

                else
                {
                    Destroy(this.gameObject);
                    ScoreManager.instance.AddScore(-2);
                    GameObject.Find("Canvas").GetComponent<NPC_LeftScreenDeath>().StartExplosion("left");
                }
            }
        }

        else
        {
            if (screenPos.x > Screen.width + 20)
            {
                Destroy(this.gameObject);
                ScoreManager.instance.AddScore(-2);
				GameObject.Find ("Canvas").GetComponent<NPC_LeftScreenDeath> ().StartExplosion ("right");
            }
        }

        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
    }

    public void Stop()
    {
        speedX = 0.0f;
        speedY = 0.0f;
    }
}
