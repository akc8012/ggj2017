// TRISTAN

using UnityEngine;
using System.Collections;

// Placement:  Place on "Plaid Man" object in scene

// Function:  Script animates Plaid Man and all children GameObjects on Mouse Click (no tap yet)

public class PlaidMan_ClickAction : MonoBehaviour {

	public GameObject[] children;

	void Start () {

	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GetComponent<Animator> ().SetTrigger("ACTIVE");
			for (int i = 0; i < this.children.Length; i++) {
				children[i].GetComponent<Animator> ().SetTrigger("ACTIVE");
			}
		}
	}
}
