using System.Runtime.CompilerServices;
using UnityEngine;

namespace SLZ.Marrow.Input
{
	public class XRUICursor : MonoBehaviour, IUIInteractor
	{
		[SerializeField]
		private float _maxRaycastDistance;

		[SerializeField]
		private LayerMask _raycastMask;

		[SerializeField]
		private LineRenderer _lineRenderer;

		private bool _isClicked;

		private XRUIInputModule _inputModule;

		private static TrackedDeviceModel _invalidTrackedDeviceModel
		{
			[CompilerGenerated]
			get
			{
				return default(TrackedDeviceModel);
			}
		}

		public Vector3 HitPoint
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

		public bool IsHit
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

		protected void OnEnable()
		{
		}

		protected void OnDisable()
		{
		}

		public virtual void UpdateUIModel(ref TrackedDeviceModel model)
		{
		}

		private void LateUpdate()
		{
		}

		public bool TryGetUIModel(out TrackedDeviceModel model)
		{
			model = default(TrackedDeviceModel);
			return false;
		}

		public void Click(bool isClicked)
		{
		}
	}
}
