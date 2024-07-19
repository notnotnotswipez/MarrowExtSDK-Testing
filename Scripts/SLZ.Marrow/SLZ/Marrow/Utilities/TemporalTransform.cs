using UnityEngine;

namespace SLZ.Marrow.Utilities
{
	public readonly struct TemporalTransform
	{
		public readonly SimpleTransform transform;

		public readonly Vector3 velocity;

		public readonly Vector3 angularVelocity;

		public readonly double time;

	}
}
