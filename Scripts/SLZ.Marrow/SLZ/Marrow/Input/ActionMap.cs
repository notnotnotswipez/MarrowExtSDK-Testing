using System.Runtime.CompilerServices;
using UnityEngine.XR;

namespace SLZ.Marrow.Input
{
	public class ActionMap
	{
		public InputDevice ISDevice
		{
			[CompilerGenerated]
			get
			{
				return default(InputDevice);
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		public virtual void OnPreNewInputUpdate()
		{
		}

		public virtual void OnPostNewInputUpdate()
		{
		}
	}
}
