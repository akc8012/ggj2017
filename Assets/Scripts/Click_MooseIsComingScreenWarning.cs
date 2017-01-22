// TRISTAN

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Click_MooseIsComingScreenWarning : MonoBehaviour {

	int textSizeCounter = 1;

	bool startBool = false;

	void Start () {
	
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && !startBool) {
			startBool = true;
		}

		if (startBool) {
			if (textSizeCounter < 144) {
				GameObject temp = GameObject.Find ("Canvas/Text");	
				temp.GetComponent<Text> ().fontSize = textSizeCounter;
				textSizeCounter += 4;
			} else
				startBool = false;
		}
	}
}
