using System.Runtime.CompilerServices;
using UnityEngine;

namespace SLZ.Marrow.VoidLogic
{
	[Support(SupportFlags.BetaSupported, null)]
	[AddComponentMenu("VoidLogic/Bonelab/VoidLogic Transform Sensor")]
	public class TransformSensor : MonoBehaviour, IVoidLogicSource, IVoidLogicNode, IVoidLogicSensor
	{
		[SerializeField]
		private Transform _anchor;

		[SerializeField]
		private Transform _connectedTransform;

		[SerializeField]
		private bool _negate;

		private static readonly PortMetadata _portMetadata;

		public VoidLogicSubgraph Subgraph
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public int OutputCount => 0;

		public PortMetadata PortMetadata => default(PortMetadata);

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void SLZ_002EMarrow_002EVoidLogic_002EIVoidLogicSensor_002EReadSensors(ref NodeState nodeState)
		{
		}

		[MethodImpl(256)]
		private float _wrap(float angleDegrees)
		{
			return 0f;
		}

		private void SLZ_002EMarrow_002EVoidLogic_002EIVoidLogicSource_002ECalculate(ref NodeState nodeState)
		{
		}

        public void Calculate(ref NodeState nodeState)
        {
            throw new System.NotImplementedException();
        }

        public void ReadSensors(ref NodeState nodeState)
        {
            throw new System.NotImplementedException();
        }
    }
}
