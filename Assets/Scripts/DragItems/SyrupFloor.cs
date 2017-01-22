// Andrew -- visual syrup for syrup bomb
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyrupFloor : MonoBehaviour
{
	float yOffset = 0.25f;
	float speedMod = 0.4f;

	void Start()
	{
		Vector3 floor = transform.position;
		floor.y = GameObject.FindWithTag("Floor").transform.position.y;
		floor.y += yOffset;
		transform.position = floor;

		//StartCoroutine(TimerThenDie(5));
	}

	IEnumerator TimerThenDie(float time)
	{
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		other.gameObject.GetComponent<MoveGuy>().speedX = other.gameObject.GetComponent<MoveGuy>().speedX *= speedMod;
	}

	void OnTriggerExit(Collider other)
	{
		other.gameObject.GetComponent<MoveGuy>().speedX = other.gameObject.GetComponent<MoveGuy>().speedX /= speedMod;
	}
}
