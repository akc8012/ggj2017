// Andrew
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
	public static ItemManager instance = null;
	[SerializeField] GameObject dragItem;	// EMPTY - use this for testing
	[SerializeField] GameObject syrupItem;
	[SerializeField] GameObject bagMilkItem;
	[SerializeField] GameObject balloonItem;
	[SerializeField] GameObject poutineItem;
	[SerializeField] GameObject paradeItem;
	GameObject[] dragItems;
	string[] itemNames;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{
		dragItems = new GameObject[] { dragItem, syrupItem, bagMilkItem, balloonItem, poutineItem, paradeItem };
		itemNames = new string[] { "DragItem", "SyrupItem", "BagMilkItem", "BalloonItem", "PoutineItem", "ParadeItem" };
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
			SpawnItem("BalloonItem");
	}

	public void SpawnItem(string name)
	{
		int ndx = -1;
		for (int i = 0; i < itemNames.Length; i++)
		{
			if (name == itemNames[i])
			{
				ndx = i;
				break;
			}
		}

		GameObject obj = dragItems[ndx];
		// convert pos from screen-space to world space before we continue
		Instantiate(obj, InputGuy.instance.WorldPosition, Quaternion.identity);
	}

	void SceneLoaded()
	{

	}
}
