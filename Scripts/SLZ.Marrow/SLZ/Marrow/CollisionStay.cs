using UnityEngine;

namespace SLZ.Marrow
{
	public class CollisionStay : MonoBehaviour
	{
		[SerializeField]
		private CollisionCollector _collisionCollector;

		private void Reset()
		{
		}

		private void OnCollisionStay(Collision c)
		{
		}
	}
}
