using UnityEngine;

namespace SLZ.Marrow.VoidLogic
{
	[HelpURL("https://github.com/StressLevelZero/MarrowSDK/wiki/VoidLogic/RemapNode")]
	[AddComponentMenu("VoidLogic/Nodes/VoidLogic Remap")]
	[Support(SupportFlags.Supported, null)]
	public class RemapNode : BaseNode
	{
		[SerializeField]
		[Tooltip("Output response curve")]
		private AnimationCurve _remapCurve;

		private static readonly PortMetadata _portMetadata;

		public override PortMetadata PortMetadata => default(PortMetadata);

		public override void Calculate(ref NodeState nodeState)
		{
		}
	}
}
