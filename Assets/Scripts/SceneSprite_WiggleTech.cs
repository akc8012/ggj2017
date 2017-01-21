using UnityEngine;
using System.Collections;

public class SceneSprite_WiggleTech : MonoBehaviour 
{
	bool 
		isWiggle = true,
		wiggleLeft = false;

	int	
		wiggleCounter = 0;

	void Start () 
	{
	
	}

	void Update () 
	{
		if (isWiggle) {
			if (wiggleLeft) {
				wiggleCounter++;
				Quaternion tempRotation = transform.rotation;
				tempRotation = Quaternion.Euler (new Vector3 (0, 0, wiggleCounter));
				transform.rotation = tempRotation;
				if (wiggleCounter > 13) {
					wiggleLeft = false;
					wiggleCounter = 0;
				}
			} else {
				wiggleCounter++;
				Quaternion tempRotation = transform.rotation;
				tempRotation = Quaternion.Euler (new Vector3 (0, 0, -wiggleCounter));
				transform.rotation = tempRotation;
				if (wiggleCounter > 13) {
					wiggleLeft = true;
					wiggleCounter = 0;
				}
			}
		}
	}
}
