// Andrew
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParadeItem : DragItem
{
	protected override void PerformDropAction()
	{
		GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
		for (int i = 0; i < npcs.Length; i++)
		{
			npcs[i].GetComponent<NPCskeleton>().MakeHappy();
		}
	}

}
