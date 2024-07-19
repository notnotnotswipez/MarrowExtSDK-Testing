using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Data;
using UnityEngine;

namespace SLZ.Marrow
{
	public class AmmoSocket : Socket
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CForceLoadAsync_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public MagazineData magazineData;

			public AmmoSocket _003C_003E4__this;

			private Magazine _003Cmagazine_003E5__2;

			private UniTask<SLZ.Marrow.Pool.Poolee>.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

            void IAsyncStateMachine.MoveNext()
            {
                throw new NotImplementedException();
            }

            [DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                throw new NotImplementedException();
            }
        }

		[Header("Magazine Socket")]
		public string platform;

		[Header("References")]
		public Grip primaryGrip;

		public Gun gun;

		public bool despawnOnInsert;

		private bool _isHostGrabbed;

		private bool _isMagazineInserted;

		private bool _isProxyGripState;

		private AmmoPlug _magazinePlug;

		public Action<Hand, Gun> onUpdateProxyGripState;

		public override bool IsClearOnInsert => false;

		public bool HasMagazine => false;

		protected override void Awake()
		{
		}

		public InteractableHost GetHost()
		{
			return null;
		}

		private void OnPlugLocked(Plug plug)
		{
		}

		private void OnPlugUnlocked()
		{
		}

		protected override void OnPlugEnter(Plug plug)
		{
		}

		protected override void OnPlugExit(Plug plug)
		{
		}

		private void UpdateProxyGripState(Hand hand)
		{
		}

		public void EjectMagazine()
		{
		}

		private void UpdateMagGripPriority(int ammoCount)
		{
		}

		private void OnAttachedHandDelegate(InteractableHost host, Hand hand)
		{
		}

		private void OnDetachedHandDelegate(InteractableHost host, Hand hand)
		{
		}

		[AsyncStateMachine(typeof(_003CForceLoadAsync_003Ed__24))]
		public UniTask ForceLoadAsync(MagazineData magazineData)
		{
			return default(UniTask);
		}

		public override void OnDespawn()
		{
		}
	}
}
