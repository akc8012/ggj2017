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
			Vector3 touchPos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10);
			Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(touchPos);
			transform.position = screenToWorld;
		}
		else if (Input.GetMouseButton(0))
		{
			Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
			Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(mousePos);
			transform.position = screenToWorld;
			print(screenToWorld);
		}
	}
}
