// Roger

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

    public void startTimer()
    {
        levelTimer -= Time.deltaTime;
    }

    public void resetTimer()
    {
        levelTimer = 60.0f;
        startTimer();
    }

    public void NextLevel()
    {

    }
}
