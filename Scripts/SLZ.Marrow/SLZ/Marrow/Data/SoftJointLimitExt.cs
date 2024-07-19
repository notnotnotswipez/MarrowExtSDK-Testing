using System;
using UnityEngine;

namespace SLZ.Marrow.Data
{
	[Serializable]
	public struct SoftJointLimitExt
	{
		public float limit;

		public float bounciness;

		public float contactDistance;


		public SoftJointLimit ToUnitySoftJointLimit()
		{
			return default(SoftJointLimit);
		}
	}
}
