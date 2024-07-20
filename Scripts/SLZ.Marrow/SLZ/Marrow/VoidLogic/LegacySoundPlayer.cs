using System;
using System.Runtime.CompilerServices;
using SLZ.Algorithms.Unity;
using UnityEngine;

namespace SLZ.Marrow.VoidLogic
{
	[AddComponentMenu("VoidLogic/Sinks/VoidLogic Legacy Sound Player")]
	[Support(SupportFlags.Deprecated, "It's unclear how exactly we want to properly support playing sound. This could break at any time.")]
	public class LegacySoundPlayer : MonoBehaviour, IVoidLogicSink, IVoidLogicNode, ISerializationCallbackReceiver, IVoidLogicActuator
	{
		[Tooltip("Previous node in the chain")]
		[Obsolete("Replace with `_previousConnection`")]
		[SerializeField]
		[Interface(typeof(IVoidLogicSource), false)]
		private MonoBehaviour _previousNode;
		[SerializeField]
		private AnimationCurve _curve;

		private float _priorValue;

		protected bool _wasOn;

		[SerializeField]
		[Header("Audio")]
		private AudioClip _onSound;

		[SerializeField]
		private AudioClip _offSound;

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

		public int InputCount => 0;

		public PortMetadata PortMetadata => default(PortMetadata);

		private void UnityEngine_002EISerializationCallbackReceiver_002EOnBeforeSerialize()
		{
		}

		private void UnityEngine_002EISerializationCallbackReceiver_002EOnAfterDeserialize()
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

		private void SLZ_002EMarrow_002EVoidLogic_002EIVoidLogicActuator_002EActuate(ref NodeState nodeState)
		{
		}

        public bool TryGetInputAtIndex(uint idx, out IVoidLogicSource input)
        {
            throw new NotImplementedException();
        }

        public void OnBeforeSerialize()
        {
            
        }

        public void OnAfterDeserialize()
        {
            
        }

        public void Actuate(ref NodeState nodeState)
        {
            
        }
    }
}
