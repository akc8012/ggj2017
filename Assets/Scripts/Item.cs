// Andrew - draggable item class
using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{

	void Start()
	{
		
	}
	
	void Update()
	{
		if (Input.touchCount != 0)
		{
			Vector3 screenToWorld = InputGuy.instance.WorldPosition;
			transform.position = screenToWorld;
		}
		else if (Input.GetMouseButton(0))
		{
			Vector3 screenToWorld = InputGuy.instance.WorldPosition;
			transform.position = screenToWorld;
			print(screenToWorld);
		}
	}
}
