using System.Runtime.CompilerServices;
using UnityEngine;

namespace SLZ.Marrow.Utilities
{
	public class InspectorDisplayNameAttribute : PropertyAttribute
	{
		public string NewName
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public InspectorDisplayNameAttribute(string name)
		{
		}
	}
}
