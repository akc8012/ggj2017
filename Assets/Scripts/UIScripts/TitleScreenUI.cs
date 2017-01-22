// Andrew
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenUI : MonoBehaviour
{
	[SerializeField] Button playButt;

	void Start()
	{
		playButt.onClick.AddListener(PlayGame);
		print("jere");
	}

	void PlayGame()
	{
		print("click");
		SceneManager.LoadScene("TristanScene (Duplicate)", LoadSceneMode.Single);
	}
}