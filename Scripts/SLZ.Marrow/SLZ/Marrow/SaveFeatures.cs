using System;

namespace SLZ.Marrow
{
	[Serializable]
	[Flags]
	public enum SaveFeatures
	{
		Completion = 1,
		PartialProgress = 2,
		Inventory = 4,
		Everything = 7
	}
}
