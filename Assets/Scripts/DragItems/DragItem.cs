// Andrew - draggable item class
using UnityEngine;
using System.Collections;

public class DragItem : MonoBehaviour
{
	int spawnedFrame;				// at what game frame did we spawn?
	const int leniencyFrames = 30;  // how many frames we can go before we let go
	protected bool canBeDropped = true;

	void Start()
	{
		spawnedFrame = Time.frameCount;
		Init();
	}

	protected virtual void Init() { }
	
	void Update()
	{
		if (InputGuy.instance.IsPressed)
		{
			Vector3 screenToWorld = InputGuy.instance.WorldPosition;
			transform.position = screenToWorld;
		}
		else if (!WithinLeniencyFrames() && canBeDropped)
		{
			PerformDropAction();
			Destroy(gameObject);
		}

		PerformContinuousAction();
	}

	protected virtual void PerformDropAction() { }
	protected virtual void PerformContinuousAction() { }

	bool WithinLeniencyFrames() { return Time.frameCount-spawnedFrame < leniencyFrames; }
}
