// Andrew
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
	public static ItemManager instance = null;
	[SerializeField] GameObject DragItem;

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
		SpawnItem();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			SpawnItem();
	}

	public void SpawnItem()    // pass in position
	{
		Instantiate(DragItem, new Vector3(-1.16f, 0.42f, 0), Quaternion.identity);
	}

	public IEnumerator SpawnAfterTime()
	{
		yield return new WaitForSeconds(3);
		SpawnItem();
	}

	void SceneLoaded()
	{

	}
}
