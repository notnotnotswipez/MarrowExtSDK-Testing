using System;
using System.Collections.Generic;
using SLZ.Marrow.Warehouse;
using UnityEngine;

namespace SLZ.Marrow
{
	public class GunManager : MonoBehaviour
	{
		public static bool HasInstance;

		public static GunManager Instance;

		private List<Gun> _activePlayerGuns;

		private readonly List<Action<Gun>> _gunFireCallbacks;

		private readonly List<Action<Hand, Gun>> _gunGrabbedCallbacks;

		private readonly List<Action<Hand, Gun>> _gunDroppedCallbacks;

		private bool _canFireGun;

		[SerializeField]
		private MarrowQuery _playerTag;

		public bool CanFireGun => false;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void RegisterGunFireCallback(Action<Gun> onFireCallback)
		{
		}

		public void UnregisterGunFireCallback(Action<Gun> onFireCallback)
		{
		}

		public void RegisterGunGrabbedCallback(Action<Hand, Gun> onGrabbedCallback)
		{
		}

		public void UnregisterGunGrabbedCallback(Action<Hand, Gun> onGrabbedCallback)
		{
		}

		public void RegisterGunDroppedCallback(Action<Hand, Gun> onDroppedCallback)
		{
		}

		public void UnregisterGunDroppedCallback(Action<Hand, Gun> onDroppedCallback)
		{
		}

		public void OnGunGrabbed(Hand hand, Gun gun)
		{
		}

		public void OnGunDropped(Hand hand, Gun gun)
		{
		}

		private void OnGunFire(Gun gun)
		{
		}

		public void DisableGunFire()
		{
		}

		public void EnableGunFire()
		{
		}
	}
}
