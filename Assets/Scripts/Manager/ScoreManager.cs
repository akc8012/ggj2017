﻿// Andrew
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager instance = null;

	int score = 1000;
	public int Score { get { return score; } }

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
		SceneManager.sceneLoaded += (scene, loadingMode) => { SceneLoaded(); };
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			AddScore(5);
	}

	void SceneLoaded()
	{
		//if (score != 0)
		//	score = 0;  // THIS IS TOTALLY PLACEHODLER, dont actually use this
	}

	public void AddScore(int amount)
	{
		score += amount;
	}

	public void SetScore(int amount)
	{
		score = amount;
	}
}
