using System.Runtime.CompilerServices;
using UnityEngine;

namespace SLZ.Marrow.VoidLogic
{
	[AddComponentMenu("VoidLogic/Sources/VoidLogic Power")]
	[Support(SupportFlags.Supported, null)]
	[HelpURL("https://github.com/StressLevelZero/MarrowSDK/wiki/VoidLogic/PowerSource")]
	public class PowerSource : MonoBehaviour, IVoidLogicSource, IVoidLogicNode
	{
		[Tooltip("Amount of power supplied by this source")]
		[SerializeField]
		private float _value;

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

		public float OutputValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

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

		private void SLZ_002EMarrow_002EVoidLogic_002EIVoidLogicSource_002ECalculate(ref NodeState nodeState)
		{
		}

        public void Calculate(ref NodeState nodeState)
        {
            throw new System.NotImplementedException();
        }
    }
}
