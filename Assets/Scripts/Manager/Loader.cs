// Andrew
// loads all the managers
using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{
	[SerializeField] GameObject scoreManager;
	[SerializeField] GameObject itemManager;

	void Awake()
	{
		if (ScoreManager.instance == null)
			Instantiate(scoreManager);

		if (ItemManager.instance == null)
			Instantiate(itemManager);
	}
}
