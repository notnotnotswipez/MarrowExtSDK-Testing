using System;
using UnityEngine;

namespace SLZ.Marrow.Interaction
{
	[Serializable]
	public struct SpringContactDrive
	{
		[SerializeField]
		public float positionSpring;

		[SerializeField]
		public float positionDamper;

		[SerializeField]
		public float maximumForce;

	}
}
