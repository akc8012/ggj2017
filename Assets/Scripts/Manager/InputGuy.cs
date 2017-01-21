﻿// Andrew - singleton class to handle input across pc and phone
// Andrew
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

	public bool OnAndroid { get { return (Application.platform == RuntimePlatform.Android); } }
	public bool OnWindows { get { return (Application.platform == RuntimePlatform.WindowsEditor 
		|| Application.platform == RuntimePlatform.WindowsPlayer); } }

	// screen-space position
	public Vector2 Position
	{
		get
		{
			if (OnWindows) return Input.mousePosition;
			else return Input.GetTouch(0).position;
		}
	}

	// WORLD SPACE coordinates
	public Vector3 WorldPosition
	{ get { return Camera.main.ScreenToWorldPoint(new Vector3(Position.x, Position.y, 10)); } }

	public bool IsPressed
	{
		get
		{
			if (OnWindows) return Input.GetMouseButton(0);
			else return Input.touchCount != 0;
		}
	}
}
