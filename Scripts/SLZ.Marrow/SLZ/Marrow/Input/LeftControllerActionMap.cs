using UnityEngine.XR;

namespace SLZ.Marrow.Input
{
	public class LeftControllerActionMap : ControllerActionMap, InputActions.IControllerLActions
	{
		public override InputDeviceCharacteristics Characteristics => default(InputDeviceCharacteristics);
	}
}
