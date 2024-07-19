using System;
using UnityEngine;

namespace SLZ.Marrow.Interaction
{
	[Serializable]
	public struct DampenContactDrive
	{
		[SerializeField]
		public float positionDamper;

		[SerializeField]
		public float maximumForce;

	}
}
