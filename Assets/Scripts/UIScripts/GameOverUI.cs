// Andrew
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
	[SerializeField] Button playAgainButt;
	
	void Start()
	{
		playAgainButt.onClick.AddListener(PlayGameAgain);
	}

	void PlayGameAgain()
	{
		// CALL ALL THE RESET FUNCTIONS HERE

		SceneManager.LoadScene("TristanScene (Duplicate)", LoadSceneMode.Single);
	}
}
