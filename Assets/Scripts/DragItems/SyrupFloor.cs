// Andrew -- visual syrup for syrup bomb
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyrupFloor : MonoBehaviour
{
	float yOffset = 0.25f;

	void Start()
	{
		Vector3 floor = transform.position;
		floor.y = GameObject.FindWithTag("Floor").transform.position.y;
		floor.y += yOffset;
		transform.position = floor;
	}

	void Update()
	{
		
	}
}
