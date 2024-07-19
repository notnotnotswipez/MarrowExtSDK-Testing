using System;

namespace SLZ.Marrow
{
	[Flags]
	public enum GripFlags
	{
		HOVER = 1,
		FARHOVER = 2,
		ATTACH = 4,
		PULLING = 8
	}
}
