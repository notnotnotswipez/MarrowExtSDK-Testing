using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace SLZ.Marrow.VoidLogic
{
	[Serializable]
	public sealed class EdgeDetector
	{
		private bool _inputWasNotLow;

		private bool _inputWasNotHigh;

		private float _nextAvailableTick;

		public float HighThreshold
		{
			[CompilerGenerated]
			get
			{
				return 0f;
			}
			[CompilerGenerated]
			internal set
			{
			}
		}

		public float LowThreshold
		{
			[CompilerGenerated]
			get
			{
				return 0f;
			}
			[CompilerGenerated]
			internal set
			{
			}
		}

		public TriggerBehavior TriggerBehavior
		{
			[CompilerGenerated]
			get
			{
				return default(TriggerBehavior);
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public float MaximumRepeatRate
		{
			[CompilerGenerated]
			get
			{
				return 0f;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public EdgeDetector(float lowThreshold = 0.05f, float highThreshold = 0.95f, TriggerBehavior triggerBehavior = TriggerBehavior.OnRisingEdge, float maximumRepeatRate = 60f)
		{
		}

		private EdgeType Tick(float nextInput)
		{
			return default(EdgeType);
		}

		private ValueType TestValue(float value)
		{
			return default(ValueType);
		}

		[PublicAPI]
		public bool TickAndTest(float value)
		{
			return false;
		}

		[PublicAPI]
		public bool TickAndTest(float value, out EdgeType edgeType)
		{
			edgeType = default(EdgeType);
			return false;
		}
	}
}
