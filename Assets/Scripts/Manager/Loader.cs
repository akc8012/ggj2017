// Andrew
// loads all the managers
using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{
	[SerializeField] GameObject scoreManager;
	[SerializeField] GameObject itemManager;
	[SerializeField] GameObject inputGuy;
	[SerializeField] GameObject soundManager;
	[SerializeField] GameObject levelManager;

    void Awake()
	{
		if (ScoreManager.instance == null)
			Instantiate(scoreManager);

		if (ItemManager.instance == null)
			Instantiate(itemManager);

		if (InputGuy.instance == null)
			Instantiate(inputGuy);

		if (SoundManager.instance == null)
			Instantiate(soundManager);

        if (LevelManager.instance == null)
            Instantiate(levelManager);
    }
}
