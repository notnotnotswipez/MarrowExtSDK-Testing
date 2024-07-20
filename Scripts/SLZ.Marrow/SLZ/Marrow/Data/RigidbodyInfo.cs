using System;
using UnityEngine;

namespace SLZ.Marrow.Data
{
	[Serializable]
	public class RigidbodyInfo
	{
		[SerializeField]
		public float mass;

		[SerializeField]
		public float drag;

		[SerializeField]
		public float angularDrag;

		[SerializeField]
		public bool useGravity;

		[SerializeField]
		public bool isKinematic;

		[SerializeField]
		public bool detectCollisions;

		[SerializeField]
		public RigidbodyInterpolation interpolate;

		[SerializeField]
		public CollisionDetectionMode collisionDetection;

		[SerializeField]
		public RigidbodyConstraints constraints;

		[SerializeField]
		public Vector3 centerOfMass;

		[SerializeField]
		public Vector3 inertiaTensor;

		[SerializeField]
		public Quaternion inertiaTensorRotation;

		[SerializeField]
		public Vector3 initalVelocity;

		[SerializeField]
		public Vector3 initialAngularVelocity;

		public void CopyFrom(Rigidbody rb)
		{
			mass = rb.mass;
			drag = rb.drag;
			angularDrag = rb.angularDrag;
			useGravity = rb.useGravity;
			isKinematic = rb.isKinematic;
			detectCollisions = rb.detectCollisions;
			interpolate = rb.interpolation;
			constraints = rb.constraints;
			centerOfMass = rb.centerOfMass;
			inertiaTensor = rb.inertiaTensor;
			inertiaTensorRotation = rb.inertiaTensorRotation;
			initalVelocity = rb.GetRelativePointVelocity(Vector3.zero);
			initialAngularVelocity = rb.angularVelocity;
		}

		public void CopyTo(Rigidbody rb)
		{
		}

		public void Destroy(Rigidbody rb)
		{
		}

		public Rigidbody Create(GameObject go)
		{
			return null;
		}
	}
}
