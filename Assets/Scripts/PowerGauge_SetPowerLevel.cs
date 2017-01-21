// TRISTAN

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Placement:  Place on Canvas gameobject

// Function:  Read in DataManager's playerPowerLevel to determine the look of Power Gauge

public class PowerGauge_SetPowerLevel : MonoBehaviour 
{
	PlayerDataManager dataMan;

	public GameObject[] powerGaugeSegments;

	public GameObject numberOfGaugesText;

	void Start () 
	{
		dataMan = PlayerDataManager.Instance;
	}

	void Update () 
	{
		int currentPowerLevel = dataMan.PlayerPowerLevel;
		numberOfGaugesText.GetComponent<Text> ().text = "x " + dataMan.NumberOfPowerGauges;

		switch (currentPowerLevel) {
		case 1:
			for (int i = 0; i < 6; i++) {powerGaugeSegments [i].GetComponent<Image> ().enabled = true;}
			for (int i = 2; i < 6; i++) {powerGaugeSegments [i].GetComponent<Image> ().enabled = false;}
			break;
		case 2:
			for (int i = 0; i < 6; i++) {powerGaugeSegments [i].GetComponent<Image> ().enabled = true;}
			for (int i = 3; i < 6; i++) {powerGaugeSegments [i].GetComponent<Image> ().enabled = false;}
			break;
		case 3:
			for (int i = 0; i < 6; i++) {powerGaugeSegments [i].GetComponent<Image> ().enabled = true;}
			for (int i = 4; i < 6; i++) {powerGaugeSegments [i].GetComponent<Image> ().enabled = false;}
			break;
		case 4:
			for (int i = 0; i < 6; i++) {powerGaugeSegments [i].GetComponent<Image> ().enabled = true;}
			for (int i = 5; i < 6; i++) {powerGaugeSegments [i].GetComponent<Image> ().enabled = false;}
			break;
		case 5:
			for (int i = 0; i < 6; i++) {powerGaugeSegments [i].GetComponent<Image> ().enabled = true;}
			break;
		}
	}
}
