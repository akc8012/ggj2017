// Andrew
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoutineItem : DragItem
{
	protected override void PerformDropAction()
	{
		ItemManager.instance.StartCoroutine(ItemManager.instance.DoPoutineTimer());
	}

}
