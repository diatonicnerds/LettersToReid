﻿/*
 * Author(s): Isaiah Mann
 * Description: [to be added]
 * Usage: [no notes]
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : SingletonController<ItemController>
{
	MapTuning mapTuning;
	MemoryController memories;

	protected override void fetchReferences()
	{
		base.fetchReferences();
		this.memories = MemoryController.Instance;
		this.mapTuning = MapTuning.Get;
	}

	public void CollectItem(MapItemBehaviour item)
	{
		if(ItemIsMemory(item))
		{
			CollectMemory(item);
		}
	}

	public void CollectMemory(MapItemBehaviour item)
	{
		Memory mem = memories.GetMemory(item.Descriptor.DelegateStr(mapTuning.IdDelegate));
		memories.CollectMemory(mem);
		Debug.Log(mem.Body);
	}

	public bool ItemIsMemory(MapItemBehaviour item)
	{
		return item.Descriptor.Key.Equals(LTRGlobal.MEMORY_KEY);
	}

}
