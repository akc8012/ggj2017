// Andrew
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonItem : DragItem
{
	protected override void PerformDropAction()
	{
		GameObject hoveringOver = InputGuy.instance.GetHoveringOver();

		if (hoveringOver && hoveringOver.GetComponent<NPCskeleton>())
		{
			hoveringOver.GetComponent<NPCskeleton>().MakeHappy();
			return;
		}

		GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
		float lowestDistance = 100000;
		int ndx = -1;
		for (int i = 0; i < npcs.Length; i++)
		{
			Vector3 cursor = InputGuy.instance.Position;
			Vector3 currentNpc = Camera.main.WorldToScreenPoint(npcs[i].transform.position);
			
			float dist = Vector3.Distance(cursor, currentNpc);
			if (dist < lowestDistance)
			{
				lowestDistance = dist;
				ndx = i;
			}
		}

		if (ndx >= 0)
			npcs[ndx].GetComponent<NPCskeleton>().MakeHappy();
	}

}
