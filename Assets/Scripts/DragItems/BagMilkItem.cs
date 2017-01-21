// Andrew
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagMilkItem : DragItem
{
	protected override void Init()
	{
		objName = "BagMilkItem";
	}

	protected override void PerformContinuousAction()
	{
		print("I am spraying milk");
	}

}
