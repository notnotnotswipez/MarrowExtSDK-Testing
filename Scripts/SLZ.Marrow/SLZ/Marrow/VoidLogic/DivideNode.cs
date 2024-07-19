using UnityEngine;

namespace SLZ.Marrow.VoidLogic
{
	[AddComponentMenu("VoidLogic/Nodes/VoidLogic Divide")]
	[HelpURL("https://github.com/StressLevelZero/MarrowSDK/wiki/VoidLogic/DivideNode")]
	[Support(SupportFlags.Supported, null)]
	public class DivideNode : BaseNode
	{
		private static readonly PortMetadata _portMetadata;

		public override PortMetadata PortMetadata => default(PortMetadata);

		public override void Calculate(ref NodeState nodeState)
		{
		}
	}
}
