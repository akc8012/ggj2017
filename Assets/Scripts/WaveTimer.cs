//Roger

using UnityEngine;
using System.Collections;

public class WaveTimer : MonoBehaviour
{
    int waveTimer = 0;

	public int WaveTimerGet {get{return waveTimer;}}

    public bool isCounting = false;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isCounting)
            startCount();
    }

    public void startCount()
    {
        if (PlayerDataManager.Instance.CanClick == false)
        {
            waveTimer += 1;
            //Debug.Log(waveTimer);
        }

        if (waveTimer >= PlayerDataManager.Instance.ClickDelay)
        {
            PlayerDataManager.Instance.CanClick = true;
            isCounting = false;
            waveTimer = 0;
        }
    }
}
