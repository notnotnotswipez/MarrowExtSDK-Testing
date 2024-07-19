using System;

namespace SLZ.Marrow
{
	[Flags]
	public enum InteractionOptions
	{
		MultipleHands = 1,
		ToggledGrip = 2,
		FarHover = 4,
		SwitchHands = 8
	}
}
