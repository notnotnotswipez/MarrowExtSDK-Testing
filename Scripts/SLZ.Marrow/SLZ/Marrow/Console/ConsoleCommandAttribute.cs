using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace SLZ.Marrow.Console
{
	[MeansImplicitUse]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	[DebuggerDisplay("ConsoleCommand({ImplicitName})")]
	public sealed class ConsoleCommandAttribute : Attribute
	{
		public readonly string Namespace;

		public readonly string Name;

		public readonly string Description;

		public readonly string ImplicitName;

		public ConsoleCommandAttribute(string @namespace, string name, string description = "")
		{
		}
	}
}
