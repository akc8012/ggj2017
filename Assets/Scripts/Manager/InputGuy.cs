// Andrew - singleton class to handle input across pc and phone
// Andrew
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class InputGuy : MonoBehaviour
{
	public static InputGuy instance = null;

	public bool OnAndroid { get { return (Application.platform == RuntimePlatform.Android); } }
	public bool OnWindows { get { return (Application.platform == RuntimePlatform.WindowsEditor 
		|| Application.platform == RuntimePlatform.WindowsPlayer); } }

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
		PrintPlatform();
	}

	void PrintPlatform()
	{
		if (OnWindows)
			GameObject.Find("Debug Canvas/Text").GetComponent<Text>().text = "windows";

		if (OnAndroid)
			GameObject.Find("Debug Canvas/Text").GetComponent<Text>().text = "android";
	}
}
