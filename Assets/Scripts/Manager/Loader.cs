// Andrew
// loads all the managers
using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{
	[SerializeField] GameObject scoreManager;
	[SerializeField] GameObject itemManager;
	[SerializeField] GameObject inputGuy;

	void Awake()
	{
		if (ScoreManager.instance == null)
			Instantiate(scoreManager);

		if (InputGuy.instance == null)
			Instantiate(inputGuy);
	}
}
