// Andrew - make the object always face the main camera
using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{
	[SerializeField] float offsetAngle = 0;

	Transform cam;

	void Start()
	{
		cam = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
	}

	void Update()
	{
		transform.LookAt(transform.position + cam.rotation * Vector3.forward, cam.rotation * Vector3.up);
		transform.Rotate(0, offsetAngle, 0);
	}
}