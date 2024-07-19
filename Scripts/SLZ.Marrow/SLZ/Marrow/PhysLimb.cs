using SLZ.Marrow.Utilities;
using SLZ.VRMK;
using UnityEngine;

namespace SLZ.Marrow
{
	public class PhysLimb : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody _endRb;

		[SerializeField]
		private Rigidbody _upperRb;

		[SerializeField]
		private Rigidbody _lowerRb;

		[SerializeField]
		private Servo _endBaseServo;

		[SerializeField]
		private Servo _upperServo;

		[SerializeField]
		private Servo _lowerServo;

		[SerializeField]
		private Servo _endServo;

		public MeshCollider cUpper;

		public MeshCollider cLower;

		public BoxCollider endCol;

		public bool shutdown;

		public float forceMultiplier;

		[SerializeField]
		private float _limbInternalMult;

		[SerializeField]
		private PhysicMaterial _naturalFriction;

		[SerializeField]
		private PhysicMaterial _lowFriction;

		private int _playerLayer;

		private int _noCollideLayer;

		private bool _isKinematic;

		private SimpleTransform _lastUpper;

		private SimpleTransform _lastLower;

		private SimpleTransform _lastEnd;

		private float _lastForceMult;

		public Rigidbody rbEnd => null;

		public Rigidbody rbUpper => null;

		public Rigidbody rbLower => null;

		public Servo endBaseServo => null;

		public Servo upperServo => null;

		public Servo lowerServo => null;

		public Servo endServo => null;

		public float limbInternalMult
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void Reset()
		{
		}

		private void Awake()
		{
		}

		public void IgnorePhysLimb(PhysLimb physLimb, bool ignore = true)
		{
		}

		public void IgnoreWholeLimbColliders(Collider col, bool ignore = true)
		{
		}

		public void IgnoreWholeLimbColliders(Collider[] col, bool ignore = true)
		{
		}

		public void CalibrateLimbColliders(SLZ.VRMK.Avatar avatar, bool isLeg = false, bool isRight = false)
		{
		}

		public void CalibrateLimbJoints(SLZ.VRMK.Avatar avatar, bool isRight = false)
		{
		}

		public void EarlyUpdateLimb()
		{
		}

		public void UpdateLimbTargets(Transform root, Transform upper, Transform lower, Transform end, float deltaTime)
		{
		}

		public void UpdateLimbDrives(float slerpForceMult, float slerpSpringMult, float slerpDampMult)
		{
		}

		public void UpdateLimbSupportDrives(float slerpForceMult, float slerpSpringMult, float slerpDampMult)
		{
		}

		public void SetLimbMass(float mass)
		{
		}

		public void SetKinematic()
		{
		}

		public void SetPhysical(Vector3 rootVelocity)
		{
		}

		public void ShutdownLimb()
		{
		}

		public void CacheLimbTransforms()
		{
		}

		public void SetFrictionNatural()
		{
		}

		public void SetFrictionLow()
		{
		}
	}
}
