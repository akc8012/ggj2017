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

    // Use this for initialization
    void Start ()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        screenPos = cam.WorldToScreenPoint(transform.position);

        if (direction == 0)
        { 
            if (screenPos.x < -20)
            {
                Destroy(this.gameObject);
                ScoreManager.instance.AddScore(-2);
                Debug.Log("i'm dead");
            }
        }

        else
        {
            if (screenPos.x > Screen.width + 20)
            {
                Destroy(this.gameObject);
                ScoreManager.instance.AddScore(-2);
                Debug.Log("i'm dead");
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
