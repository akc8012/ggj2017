// Andrew
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagMilkItem : DragItem
{
	[SerializeField] GameObject rainParticles;
	Collider col;
	GameObject[] npcs;
	float milkSprayingTime = 3;
	float yOffset = 0.8f;

	protected override void Init()
	{
		col = GetComponent<Collider>();
		npcs = GameObject.FindGameObjectsWithTag("NPC");
		rainParticles = (GameObject)Instantiate(rainParticles, transform.position, rainParticles.transform.rotation);
		canBeDropped = false;
		StartCoroutine(WhenToStopSprayingMilk());
	}

	protected override void PerformContinuousAction()
	{
		Vector3 rainPos = transform.position;
		rainPos.y -= yOffset;
		rainParticles.transform.position = rainPos;
		
		for (int i = 0; i < npcs.Length; i++)
		{
			if (npcs[i] != null)    // could become null if they die
			{
				Vector3 npcPos = Camera.main.WorldToScreenPoint(npcs[i].transform.position);
				Vector3 min = Camera.main.WorldToScreenPoint(col.bounds.min);
				Vector3 max = Camera.main.WorldToScreenPoint(col.bounds.max);
				if (npcPos.x >= min.x && npcPos.x <= max.x)
				{
					npcs[i].GetComponent<NPCskeleton>().MakeHappy();
				}
			}
		}
	}

	IEnumerator WhenToStopSprayingMilk()
	{
		yield return new WaitForSeconds(milkSprayingTime);
		PerformDropAction();
		Destroy(rainParticles);
		Destroy(gameObject);
	}

}
