// Andrew - singleton class to handle input across pc and phone
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class InputGuy : MonoBehaviour
{
	public static InputGuy instance = null;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
		if (GameObject.Find("Debug Canvas/Text")) PrintPlatform();
	}

	void PrintPlatform()
	{
		if (OnWindows)
			GameObject.Find("Debug Canvas/Text").GetComponent<Text>().text = "windows";

		if (OnAndroid)
			GameObject.Find("Debug Canvas/Text").GetComponent<Text>().text = "android";
	}

	void LateUpdate()
	{
		if (IsPressed)
			pressedLastFrame = true;
		else
			pressedLastFrame = false;
	}

	public bool OnAndroid { get { return (Application.platform == RuntimePlatform.Android); } }
	public bool OnWindows { get { return (Application.platform == RuntimePlatform.WindowsEditor 
		|| Application.platform == RuntimePlatform.WindowsPlayer); } }

	// screen-space position
	public Vector2 Position
	{
		get
		{
			if (OnWindows) return Input.mousePosition;
			else return	(Input.touchCount != 0) ? Input.GetTouch(0).position : Vector2.zero;
		}
	}

	// WORLD SPACE coordinates
	public Vector3 WorldPosition
	{ get { return Camera.main.ScreenToWorldPoint(new Vector3(Position.x, Position.y, 10)); } }

	// returns true if the mouse button, or finger, is held down
	public bool IsPressed
	{
		get
		{
			if (OnWindows) return Input.GetMouseButton(0);
			else return Input.touchCount != 0;
		}
	}

	public bool pressedLastFrame = false;
	// returns true if the mouse button, or finger, is held down
	public bool IsPressedDuringFrame
	{
		get
		{
			if (pressedLastFrame) return false;
			else return IsPressed;
		}
	}

	// returns the gameobject currently being hovered over
	public GameObject GetHoveringOver()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Position);

		if (Physics.Raycast(ray, out hit))
		{
			GameObject objectHit = hit.transform.gameObject;
			return objectHit;
		}
		return null;
	}

	// returns true if passed in object IS the one we're hovering over
	public bool IsHoveringOver(GameObject obj)
	{
		return (obj == GetHoveringOver());
	}
}
