using System;
using UnityEngine;

namespace SLZ.Marrow.VoidLogic
{
	[Support(SupportFlags.Deprecated, "Use Button + Toggle instead")]
	[Support(SupportFlags.Unsupported, null)]
	[Obsolete("Use Button + Toggle instead", true)]
	[AddComponentMenu(null)]
	public class ToggleButtonNode : ButtonNode
	{
		private float _multiplier;

		private static readonly PortMetadata _portMetadata;

		public override PortMetadata PortMetadata => default(PortMetadata);

		public override void Calculate(ref NodeState nodeState)
		{
		}
	}
}
