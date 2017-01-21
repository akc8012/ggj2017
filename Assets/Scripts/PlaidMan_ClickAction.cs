// TRISTAN

using UnityEngine;
using System.Collections;

// Placement:  Place on "Plaid Man" object in scene

// Function:  Script animates Plaid Man and all children GameObjects on Mouse Click (no tap yet)

public class PlaidMan_ClickAction : MonoBehaviour {

	PlayerDataManager 
		dataMan;

	public GameObject[] 
		children;

	public AudioClip[] 
		audioClips;	// cheering, hardClap, threeClaps

	int 
		counter = 0,
		clickDelay = 60;

	bool 
		startCounting = false;

	public AudioSource[] 
		audioSource;

	void Start () {
		dataMan = PlayerDataManager.Instance;
		dataMan.CanClick = false;
	}

	void Update () {
		if (startCounting)
			counter++;
		if (counter > clickDelay) {
			dataMan.CanClick = false;
			startCounting = false;
			counter = 0;
		}
		if (counter == 10) {
			audioSource[1].volume = 0.4f;
			audioSource[1].PlayOneShot(audioClips[1]);
		}
		if (counter == 5) {
			audioSource[0].volume = 0.1f;
			audioSource[0].PlayOneShot(audioClips[0]);
		}
		if (Input.GetMouseButtonDown (0) && !dataMan.CanClick) {
			dataMan.CanClick = true;
			startCounting = true;
			GetComponent<Animator> ().SetTrigger("ACTIVE");
			for (int i = 0; i < this.children.Length; i++) {
				children[i].GetComponent<Animator> ().SetTrigger("ACTIVE");
			}
		}
	}
}
