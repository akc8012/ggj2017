// Andrew - draggable item class
using UnityEngine;
using System.Collections;

public class DragItem : MonoBehaviour
{
	int spawnedFrame;				// at what game frame did we spawn?
	const int leniencyFrames = 30;	// how many frames we can go before we let go

	void Start()
	{
		spawnedFrame = Time.frameCount;
	}
	
	void Update()
	{
		if (InputGuy.instance.IsPressed)
		{
			Vector3 screenToWorld = InputGuy.instance.WorldPosition;
			transform.position = screenToWorld;
		}
		else if (!WithinLeniencyFrames())
			DestroyThenMakeNew();   // MAKE SURE YOU PERFORM DROP ACTION

		PerformContinuousAction();
	}

	void DestroyThenMakeNew()	// for testing
	{
		PerformDropAction();
		ItemManager.instance.StartCoroutine(ItemManager.instance.SpawnAfterTime());
		Destroy(gameObject);
	}

	protected virtual void PerformDropAction() { }          // maybe make this abstract?
	protected virtual void PerformContinuousAction() { }	// for bagged milk?

	bool WithinLeniencyFrames() { return Time.frameCount-spawnedFrame < leniencyFrames; }
}
