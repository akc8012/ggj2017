// TRISTAN

using UnityEngine;
using System.Collections;

// Placement:  Place on the prefabs for ManSprite, WomanSprite and ChildSprite

// Function:  Changes the "Face" child of the NPC that gets spawned based on NPCSkeleton happiness

public class NPC_ChangeFaceBasedOnHappiness : MonoBehaviour {

	// vars
	NPCskeleton skeletonScript;

	public GameObject face;

	public Sprite[] spriteList;

	void Start () {
		skeletonScript = GetComponent<NPCskeleton>();
	}

	void Update () {
		switch(skeletonScript.Happiness){
		case 0:
			face.GetComponent<SpriteRenderer> ().sprite = spriteList [0];
			break;
		case 1:
			face.GetComponent<SpriteRenderer> ().sprite = spriteList [1];
			break;
		case 2:
			face.GetComponent<SpriteRenderer> ().sprite = spriteList [2];
			break;
		case 3:
			face.GetComponent<SpriteRenderer> ().sprite = spriteList [3];
			break;
		case 4:
			face.GetComponent<SpriteRenderer> ().sprite = spriteList [4];
			break;
		}
	}
}
