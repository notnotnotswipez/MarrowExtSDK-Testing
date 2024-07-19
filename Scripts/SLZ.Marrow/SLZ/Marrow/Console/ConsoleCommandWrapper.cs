using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SLZ.Marrow.Console
{
	public sealed class ConsoleCommandWrapper
	{
		public readonly BaseConsoleCommand Command;

		public bool Installed
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			internal set
			{
			}
		}

		public IReadOnlyList<ConsoleCommandAttribute> Attributes
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

		public ConsoleCommandWrapper(Type commandType)
		{
		}
	}
}
