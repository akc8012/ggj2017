// Andrew
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
	public static ItemManager instance = null;

	List<Item> items = new List<Item>();

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
		SceneManager.sceneLoaded += (scene, loadingMode) => { SceneLoaded(); };
	}

	void Start()
	{
		items.Clear();
	}

	void SceneLoaded()
	{

	}
}
