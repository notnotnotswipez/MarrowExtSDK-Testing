using System;
using System.Runtime.CompilerServices;
using SLZ.Algorithms.Unity;
using SLZ.Marrow.Interaction;
using SLZ.Marrow.Utilities;
using SLZ.Marrow.VoidLogic;
using UltEvents;
using UnityEngine;

namespace SLZ.Marrow.Zones
{
	[AddComponentMenu("VoidLogic/Sinks/VoidLogic Zone Entity Trigger")]
	[Support(SupportFlags.Unsupported, "Not (yet?) supported.")]
	public class ZoneEntityTrigger : MonoBehaviour, IVoidLogicSink, IVoidLogicNode, ISerializationCallbackReceiver, IVoidLogicSource
	{
		[SerializeField]
		private Zone _zone;

		public EntityAggregator aggregator;

		[Interface(typeof(IVoidLogicSource), false)]
		[Tooltip("Previous node(s) in the chain")]
		[SerializeField]
		[Obsolete("Replace with `_previousConnections`")]
		private MonoBehaviour[] _previous;

		[NonReorderable]
		[SerializeField]
		[Tooltip("Previous node(s) in the chain")]
	
		public UltEvent<MarrowEntity> OnEntityTriggerEnter;

		public UltEvent<MarrowEntity> OnEntityTriggerExit;

		[SerializeField]
		[ReadOnly(false)]
		private float logicMultiplier;

		protected internal float _cachedValue;

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

		protected bool IsCachedInternal
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public int OutputCount => 0;

		public int InputCount => 0;

		public PortMetadata PortMetadata => default(PortMetadata);

		private void UnityEngine_002EISerializationCallbackReceiver_002EOnBeforeSerialize()
		{
		}

		private void UnityEngine_002EISerializationCallbackReceiver_002EOnAfterDeserialize()
		{
		}

		private void Reset()
		{
		}

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

		private void _OnEntityTriggerEnter(MarrowEntity entity)
		{
		}

		private void _OnEntityTriggerExit(MarrowEntity entity)
		{
		}

		private void SLZ_002EMarrow_002EVoidLogic_002EIVoidLogicSource_002ECalculate(ref NodeState nodeState)
		{
		}

        public bool TryGetInputAtIndex(uint idx, out IVoidLogicSource input)
        {
            throw new NotImplementedException();
        }

        public void OnBeforeSerialize()
        {
            throw new NotImplementedException();
        }

        public void OnAfterDeserialize()
        {
            throw new NotImplementedException();
        }

        public void Calculate(ref NodeState nodeState)
        {
            throw new NotImplementedException();
        }
    }
}
