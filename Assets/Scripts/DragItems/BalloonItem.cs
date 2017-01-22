// Andrew
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonItem : DragItem
{
	protected override void PerformDropAction()
	{
		GameObject hoveringOver = InputGuy.instance.GetHoveringOver();

		if (hoveringOver.GetComponent<NPCskeleton>())
			print("YAS");

		//GameObject 
	}

}
