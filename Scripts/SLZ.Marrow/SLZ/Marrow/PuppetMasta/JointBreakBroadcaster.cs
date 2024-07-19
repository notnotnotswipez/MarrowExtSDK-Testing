using UnityEngine;

namespace SLZ.Marrow.PuppetMasta
{
	public class JointBreakBroadcaster : MonoBehaviour
	{
		[HideInInspector]
		[SerializeField]
		public PuppetMaster puppetMaster;

		[HideInInspector]
		[SerializeField]
		public int muscleIndex;

		private void OnJointBreak()
		{
		}
	}
}
