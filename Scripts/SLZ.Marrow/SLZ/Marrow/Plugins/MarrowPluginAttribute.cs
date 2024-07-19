using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine.Scripting;

namespace SLZ.Marrow.Plugins
{
	[RequireAttributeUsages]
	[MeansImplicitUse]
	[AttributeUsage(AttributeTargets.Class)]
	public class MarrowPluginAttribute : Attribute
	{
		public string Namespace
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

		public string Name
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

		public string Version
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

		public MarrowPluginAttribute(string Namespace, string Name, string Version = "0.0.1-UNKNOWN")
		{
		}
	}
}
