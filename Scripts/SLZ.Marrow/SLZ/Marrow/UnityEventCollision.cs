using System;
using UnityEngine;
using UnityEngine.Events;

namespace SLZ.Marrow
{
	[Serializable]
	public class UnityEventCollision : UnityEvent<Collider, Vector3, Vector3>
	{
		public UnityEventCollision()
		{
			
		}
	}
}
