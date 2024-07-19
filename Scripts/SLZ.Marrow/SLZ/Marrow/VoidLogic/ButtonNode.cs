using UnityEngine;

namespace SLZ.Marrow.VoidLogic
{
	[Support(SupportFlags.Supported, null)]
	[AddComponentMenu("VoidLogic/Nodes/VoidLogic Button")]
	public class ButtonNode : BaseNode, IVoidLogicSensor, IVoidLogicNode, IVoidLogicActuator
	{
		[SerializeField]
		protected float _lowThreshold;

		[SerializeField]
		protected float _highThreshold;

		[SerializeField]
		protected ConfigurableJoint _joint;

		[SerializeField]
		protected Transform _endTransform;

		[Header("Audio")]
		[SerializeField]
		[Tooltip("Clip(s) to be played on button press")]
		protected AudioClip[] _pressClips;

		[SerializeField]
		[Tooltip("Clip(s) to be played on button unpress")]
		protected AudioClip[] _depressClips;

		[SerializeField]
		[Tooltip("Colliders that the button shaft collider will ignore")]
		protected Collider[] _ignoreColliders;

		[SerializeField]
		protected Collider _buttonShaftCollider;

		protected Rigidbody _rigidBody;

		private Vector3 _initialDisplacement;

		protected bool _isPressed;

		private bool _performedInitialRead;

		private static readonly PortMetadata _portMetadata;

		public override PortMetadata PortMetadata => default(PortMetadata);

		private new void Awake()
		{
		}

		protected override void OnEnable()
		{
		}

		private void SLZ_002EMarrow_002EVoidLogic_002EIVoidLogicSensor_002EReadSensors(ref NodeState nodeState)
		{
		}

		public override void Calculate(ref NodeState nodeState)
		{
		}

		private void SLZ_002EMarrow_002EVoidLogic_002EIVoidLogicActuator_002EActuate(ref NodeState nodeState)
		{
		}

        public void ReadSensors(ref NodeState nodeState)
        {
            throw new System.NotImplementedException();
        }

        public void Actuate(ref NodeState nodeState)
        {
            throw new System.NotImplementedException();
        }
    }
}
