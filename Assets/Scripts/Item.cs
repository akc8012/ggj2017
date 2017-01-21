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
		if (InputGuy.instance.IsPressed)
		{
			Vector3 screenToWorld = InputGuy.instance.WorldPosition;
			transform.position = screenToWorld;
		}
	}
}
