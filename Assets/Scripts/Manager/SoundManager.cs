// Andrew
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager instance = null;
	[SerializeField] AudioSource musicSource;

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
		
	}
	
}
