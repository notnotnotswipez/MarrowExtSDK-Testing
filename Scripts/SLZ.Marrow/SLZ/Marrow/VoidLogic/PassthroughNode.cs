using System.Runtime.CompilerServices;
using UnityEngine;

namespace SLZ.Marrow.VoidLogic
{
	[AddComponentMenu("VoidLogic/Nodes/VoidLogic Passthrough")]
	[Support(SupportFlags.Supported, null)]
	[HelpURL("https://github.com/StressLevelZero/MarrowSDK/wiki/VoidLogic/PassthroughNode")]
	public class PassthroughNode : BaseNode
	{
		[SerializeField]
		private bool _cutoff;

		private static readonly PortMetadata _portMetadata;

		public override PortMetadata PortMetadata => default(PortMetadata);

		public override void Calculate(ref NodeState nodeState)
		{
		}

		[MethodImpl(256)]
		public void Toggle()
		{
		}

		[MethodImpl(256)]
		public void TurnOn()
		{
		}

		[MethodImpl(256)]
		public void TurnOff()
		{
		}
	}
}
