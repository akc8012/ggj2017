// Andrew
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyrupItem : DragItem
{
	[SerializeField] GameObject syrupFloor;

	protected override void PerformDropAction()
	{
		float zWithPeople = GameObject.Find("SpawnerL").transform.position.z;
		float zDist = Camera.main.transform.position.z - (zWithPeople);

		float mouseX = Mathf.Abs(InputGuy.instance.Position.x - Screen.width);
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, 0, zDist));
		Vector3 spawnPos = new Vector3(worldPos.x, worldPos.y, zWithPeople);


		Instantiate(syrupFloor, spawnPos, syrupFloor.transform.rotation);
	}

}
