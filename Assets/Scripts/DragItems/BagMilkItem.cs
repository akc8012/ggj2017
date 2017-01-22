// Andrew
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagMilkItem : DragItem
{
	[SerializeField] GameObject rainParticles;
	float milkSprayingTime = 3;

	protected override void Init()
	{
		rainParticles = (GameObject)Instantiate(rainParticles, transform.position, rainParticles.transform.rotation);
		canBeDropped = false;
		StartCoroutine(WhenToStopSprayingMilk());
	}

	protected override void PerformContinuousAction()
	{
		rainParticles.transform.position = transform.position;
		//print("I am spraying milk");
	}

	IEnumerator WhenToStopSprayingMilk()
	{
		yield return new WaitForSeconds(milkSprayingTime);
		PerformDropAction();
		Destroy(rainParticles);
		Destroy(gameObject);
	}

}
