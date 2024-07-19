using System;
using System.Runtime.CompilerServices;
using SLZ.Algorithms.Unity;
using UnityEngine;

namespace SLZ.Marrow.VoidLogic
{
	public abstract class BaseNode : MonoBehaviour, IVoidLogicSink, IVoidLogicNode, ISerializationCallbackReceiver, IVoidLogicSource
	{
		[SerializeField]
		[Tooltip("Previous node(s) in the chain")]
		[Interface(typeof(IVoidLogicSource), false)]
		[Obsolete("Replace with `_previousConnections`")]
		private MonoBehaviour[] _previous;
		
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

		public abstract PortMetadata PortMetadata { get; }

		public int InputCount => 0;

		public virtual int OutputCount => 0;

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		[MethodImpl(256)]
		protected static bool EqualWithTolerance(float term1, float term2, float tolerance)
		{
			return false;
		}

		public abstract void Calculate(ref NodeState nodeState);

        public bool TryGetInputAtIndex(uint idx, out IVoidLogicSource input)
        {
            throw new NotImplementedException();
        }
    }
}
