// Andrew
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyrupItem : DragItem
{
	protected override void Init()
	{
		objName = "SyrupItem";
	}

	protected override void PerformDropAction()
	{
		print("syrup bomb!");
	}

}
