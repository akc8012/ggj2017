// TRISTAN

using UnityEngine;
using System.Collections;

// Placement:  No Monobehavior

// Function:  Stores all of the important, global game data that's read from and to other scripts.

public class PlayerDataManager 
{
	#region SINGLETON
	// Singleton
	private static PlayerDataManager instance;

	private PlayerDataManager(){}

	public static PlayerDataManager Instance
	{
		get
		{ 
			if (instance == null) 
			{
				instance = new PlayerDataManager ();
			}

			return instance;
		}
	}

	#endregion

	#region VARIABLES
	// all the variables and setters/getters used by DataManager

	// Should be defaulted to 1:  Max of 5
	int playerPowerLevel = 1;
	public int PlayerPowerLevel {get{ return playerPowerLevel;}set{ playerPowerLevel = value;}}

	int numberOfPowerGauges = 1;
	public int NumberOfPowerGauges{get{ return numberOfPowerGauges;}set{ numberOfPowerGauges = value;}}

	// amount of happiness that gets added with each click
	int clickPower = 1;
	public int ClickPower {get{ return clickPower;}set{ clickPower = value;}}

	bool canClick = false;
	public bool CanClick{get{return canClick; }set{ canClick = value;}}

	#endregion

	#region BEHAVIORS
	// all functionality of DataManager

	// increase power level
	public void IncreasePowerLevel(){
		clickPower += 5;
		if (playerPowerLevel < 5) {
			playerPowerLevel += 1;
		}
	}

	#endregion
}
