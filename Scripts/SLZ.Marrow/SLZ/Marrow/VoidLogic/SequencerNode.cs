using System.Runtime.CompilerServices;
using UnityEngine;

namespace SLZ.Marrow.VoidLogic
{
	[AddComponentMenu("VoidLogic/Nodes/VoidLogic Sequencer")]
	[Support(SupportFlags.AlphaSupported, "This needs to be updated to use sensors and actuators.")]
	[HelpURL("https://github.com/StressLevelZero/MarrowSDK/wiki/VoidLogic/SequencerNode")]
	public class SequencerNode : BaseNode
	{
		private bool _isRunning;

		private float _time;

		private float _cachedEndKeyTime;

		private float _cachedValue;

		private static readonly PortMetadata _portMetadata;

		private AnimationCurve Sequence
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

		public bool RealTime
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

		public float TimeScale
		{
			[CompilerGenerated]
			get
			{
				return 0f;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public bool Loop
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

		public bool ResetTimeOnSequenceCompletion
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

		private EdgeDetector StartEdgeDetector
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

		private EdgeDetector ResetEdgeDetector
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

		public override PortMetadata PortMetadata => default(PortMetadata);

		private void Start()
		{
		}

		private void Update()
		{
		}

		public override void Calculate(ref NodeState nodeState)
		{
		}
	}
}
