// TRISTAN

using UnityEngine;
using System.Collections;

// Placement:  Place on the prefabs for ManSprite, WomanSprite and ChildSprite

// Function:  Changes the "Face" child of the NPC that gets spawned based on NPCSkeleton happiness

public class NPC_ChangeFaceBasedOnHappiness : MonoBehaviour {

	// vars
	NPCskeleton skeletonScript;

	public GameObject face;

	public GameObject particle;

	public Material[] changingMat;

	public Sprite[] spriteList;

	public bool IsMoose = false;

	void Start () {
		skeletonScript = GetComponent<NPCskeleton>();
	}

	void Update () {
		if (!IsMoose) {
			switch (skeletonScript.Happiness) {
			case 0:
				face.GetComponent<SpriteRenderer> ().sprite = spriteList [0];
				particle.GetComponent<ParticleSystemRenderer> ().material = changingMat [0];
				break;
			case 1:
				face.GetComponent<SpriteRenderer> ().sprite = spriteList [1];
				particle.GetComponent<ParticleSystemRenderer> ().material = changingMat [1];
				break;
			case 2:
				face.GetComponent<SpriteRenderer> ().sprite = spriteList [2];
				particle.GetComponent<ParticleSystemRenderer> ().material = changingMat [2];
				break;
			case 3:
				face.GetComponent<SpriteRenderer> ().sprite = spriteList [3];
				particle.GetComponent<ParticleSystemRenderer> ().material = changingMat [3];
				break;
			case 4:
				face.GetComponent<SpriteRenderer> ().sprite = spriteList [4];
				particle.GetComponent<ParticleSystemRenderer> ().material = changingMat [4];
				break;
			}
		} else {
			switch (skeletonScript.Happiness) {
			case 0:
				face.GetComponent<SpriteRenderer> ().sprite = spriteList [0];
				particle.GetComponent<ParticleSystemRenderer> ().material = changingMat [0];
				break;
			case 3:
				face.GetComponent<SpriteRenderer> ().sprite = spriteList [1];
				particle.GetComponent<ParticleSystemRenderer> ().material = changingMat [1];
				break;
			case 5:
				face.GetComponent<SpriteRenderer> ().sprite = spriteList [2];
				particle.GetComponent<ParticleSystemRenderer> ().material = changingMat [2];
				break;
			case 7:
				face.GetComponent<SpriteRenderer> ().sprite = spriteList [3];
				particle.GetComponent<ParticleSystemRenderer> ().material = changingMat [3];
				break;
			case 10:
				face.GetComponent<SpriteRenderer> ().sprite = spriteList [4];
				particle.GetComponent<ParticleSystemRenderer> ().material = changingMat [4];
				break;
			}
		}
	}
}
