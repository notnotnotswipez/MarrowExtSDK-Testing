using System;
using SLZ.Marrow.Data;
using UnityEngine;
using UnityEngine.Events;

namespace SLZ.Marrow
{
	[Serializable]
	public class DestructableLootSpawnEvent : UnityEvent<ObjectDestructible, Spawnable, GameObject>
	{
		public DestructableLootSpawnEvent()
		{
			
		}
	}
}
