﻿// Roger

using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    AudioSource musicSource;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    float levelTimer = 60.0f;
        public float LevelTimer { get { return levelTimer; } set { levelTimer = value; } }

    int levelNumber = 0;
         public int LevelNumber {  get { return levelNumber; } set { levelNumber = value; } }

    bool manSpawn = false;
   	public bool ManSpawn { get { return manSpawn; } set { manSpawn = value; } }



    void Update()
    {
        if (manSpawn == true)
        { 
            levelTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown("r"))
        {
            ResetLevel();
        }

        //Debug.Log(levelTimer);
    }

    public void resetTimer()
    {
      manSpawn = true;
    }

    public void Stoptimer()
    {
        levelTimer = 60.0f;
        manSpawn = false;
    }

    public void NextLevel()
    {
        levelNumber += 1;
        resetTimer();
    }

    public void ResetLevel()
    {
        levelTimer = 60.0f;
        manSpawn = true;
        levelNumber = 0;
    }
}
