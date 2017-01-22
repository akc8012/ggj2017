// TRISTAN

using UnityEngine;
using System.Collections;

// Placement:  Place on "Plaid Man" object in scene

// Function:  Script animates Plaid Man and all children GameObjects on Mouse Click (no tap yet)

public class PlaidMan_ClickAction : MonoBehaviour {

	public GameObject[] 
		children;

	public AudioClip[] 
		audioClips;	// cheering, hardClap, threeClaps

	int 
		counter = 0;

	bool 
		startCounting = false;

	public AudioSource[] 
		audioSource;

	void Start () {

		// Set the Player attributes to the right values
		transform.SetParent(Camera.main.transform);
		transform.position = new Vector3 (0, 0, 0);
		transform.rotation = Quaternion.Euler(new Vector3 (0, 0, 0));
		transform.localScale = new Vector3 (1, 1, 1);

		// Start the applause, waving, etc
		startCounting = true;
		GetComponent<Animator> ().SetTrigger("ACTIVE");
		for (int i = 0; i < PlayerDataManager.Instance.PlayerPowerLevel - 1; i++) {
			children[i].GetComponent<Animator> ().SetTrigger("ACTIVE");
		}
		for (int i = 0; i < children.Length; i++) {
			children [i].SetActive (false);
		}
	}

	void Update () {

		for (int i = 0; i < PlayerDataManager.Instance.PlayerPowerLevel; i++) {
			if (!(PlayerDataManager.Instance.PlayerPowerLevel > children.Length)) {
				children [i].SetActive (true);
				children [i].GetComponent<Animator> ().SetTrigger ("ACTIVE");
			} else {
				children [0].SetActive (true);
				children [0].GetComponent<Animator> ().SetTrigger ("ACTIVE");
				children [1].SetActive (true);
				children [1].GetComponent<Animator> ().SetTrigger ("ACTIVE");
				children [2].SetActive (true);
				children [2].GetComponent<Animator> ().SetTrigger ("ACTIVE");
				children [3].SetActive (true);
				children [3].GetComponent<Animator> ().SetTrigger ("ACTIVE");
			}
		}

		if (startCounting)
			counter++;
		if (counter > 100) {
			Destroy (gameObject);
		}
		if (counter == 10) {
			audioSource[1].volume = 0.4f;
			audioSource[1].PlayOneShot(audioClips[1]);
		}
		if (counter == 5) {
			int rand = Random.Range (0, 5);

			if (rand != 0) {
				audioSource [0].volume = 0.1f;
				audioSource [0].PlayOneShot (audioClips [0]);
			} else {
				audioSource [0].volume = 0.6f;
				audioSource [0].PlayOneShot (audioClips [3]);
			}
		}
	}
}
