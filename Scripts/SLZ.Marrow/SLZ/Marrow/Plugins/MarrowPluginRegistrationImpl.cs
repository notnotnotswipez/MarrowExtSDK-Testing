using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SLZ.Marrow.Plugins
{
	internal class MarrowPluginRegistrationImpl : IMarrowPluginRegistration
	{
		public Type PluginType
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			internal set
			{
			}
		}

		public MarrowPluginAttribute MarrowPluginAttribute
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			internal set
			{
			}
		}

		public HashSet<string> Dependencies
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			internal set
			{
			}
		}

		public void AddDependency(string qualifiedName)
		{
		}
	}
}
