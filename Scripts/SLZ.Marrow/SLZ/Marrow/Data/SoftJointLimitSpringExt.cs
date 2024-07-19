using System;
using UnityEngine;

namespace SLZ.Marrow.Data
{
	[Serializable]
	public struct SoftJointLimitSpringExt
	{
		public float spring;

		public float damper;


		public SoftJointLimitSpring ToUnitySoftJointLimitSpring()
		{
			return default(SoftJointLimitSpring);
		}
	}
}
