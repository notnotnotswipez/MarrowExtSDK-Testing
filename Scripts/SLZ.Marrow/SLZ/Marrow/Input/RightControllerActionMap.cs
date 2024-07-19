using UnityEngine.XR;

namespace SLZ.Marrow.Input
{
	public class RightControllerActionMap : ControllerActionMap, InputActions.IControllerRActions
	{
		public override InputDeviceCharacteristics Characteristics => default(InputDeviceCharacteristics);
	}
}
