using System;
using UnityEngine;

namespace SLZ.Marrow.Interaction
{
	[Serializable]
	public struct SoftSplineJointLimit
	{
		[SerializeField]
		public float limit;

		[SerializeField]
		public float bounciness;

		[SerializeField]
		public float contactDistance;

	}
}
