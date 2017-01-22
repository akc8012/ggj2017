using UnityEngine;
using System.Collections;

public class NPC_LeftScreenDeath : MonoBehaviour {

	public GameObject leftExplosion;
	public GameObject rightExplosion;

	float enterScreenTimer = 0;

	string specificSide = "right";
	bool startExplosion = false;
	bool rightBool = false;
	bool leftBool = false;

	void Start () {
		rightExplosion.transform.localPosition = new Vector3 (Screen.width/2 + 100, 0, 0);
		leftExplosion.transform.localPosition = new Vector3 (-Screen.width/2 - 100, 0, 0);
	}

	void Update () {
	
		if (startExplosion) {
			if(rightBool){
				rightExplosion.transform.localPosition = new Vector3 (Screen.width / 2 + 100 - enterScreenTimer, 0, 0);
				enterScreenTimer += 2.5f;

				if (enterScreenTimer >= 100) {
					enterScreenTimer = 0;
					rightExplosion.transform.localPosition = new Vector3 (Screen.width / 2 + 100, 0, 0);
					startExplosion = false;
					rightBool = false;
				}
			}
			if (leftBool) {
				leftExplosion.transform.localPosition = new Vector3 (-Screen.width / 2 - 100 + enterScreenTimer, 0, 0);
				enterScreenTimer += 2.5f;

				if (enterScreenTimer >= 100) {
					enterScreenTimer = 0;
					leftExplosion.transform.localPosition = new Vector3 (-Screen.width / 2 - 100, 0, 0);
					startExplosion = false;
					leftBool = false;
				}
			}
		}
	}

	public void StartExplosion(string side){
		if (side == "right")
			rightBool = true;
		if (side == "left")
			leftBool = true;
		startExplosion = true;
	}
}
