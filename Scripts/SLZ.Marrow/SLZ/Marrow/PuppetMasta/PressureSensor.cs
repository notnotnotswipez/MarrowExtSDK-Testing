using System.Runtime.CompilerServices;
using UnityEngine;

namespace SLZ.Marrow.PuppetMasta
{
	public class PressureSensor : MonoBehaviour
	{
		public bool visualize;

		public LayerMask layers;

		private bool fixedFrame;

		private Vector3 P;

		private int count;

		public Vector3 center
		{
			[CompilerGenerated]
			get
			{
				return default(Vector3);
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public bool inContact
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public Vector3 bottom
		{
			[CompilerGenerated]
			get
			{
				return default(Vector3);
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public Rigidbody r
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		private void Awake()
		{
		}

		private void OnCollisionEnter(Collision c)
		{
		}

		private void OnCollisionStay(Collision c)
		{
		}

		private void OnCollisionExit(Collision c)
		{
		}

		private void FixedUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		private void ProcessCollision(Collision c)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
