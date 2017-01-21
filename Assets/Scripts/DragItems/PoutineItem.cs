// Andrew
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoutineItem : DragItem
{
	protected override void Init()
	{
		objName = "PoutineItem";
	}

	protected override void PerformDropAction()
	{
		print("give player food thing, make waving anim twice as long");
	}

}
