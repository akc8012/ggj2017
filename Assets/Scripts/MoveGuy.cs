//Roger!

using UnityEngine;
using System.Collections;

public class MoveGuy : MonoBehaviour
{
    public float speedX; // canadian horizontal speed    
    public float speedY; // canadian vertical speed

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(speedX, speedY, 0);
    }
}
