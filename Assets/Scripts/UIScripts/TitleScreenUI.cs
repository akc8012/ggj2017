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
	}

	void PlayGame()
	{
		SceneManager.LoadScene("TristanScene (Duplicate)", LoadSceneMode.Single);
	}
}