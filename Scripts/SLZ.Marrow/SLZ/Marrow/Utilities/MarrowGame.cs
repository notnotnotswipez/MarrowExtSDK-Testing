using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Input;
using SLZ.Marrow.Warehouse;
using UnityEngine;
using YieldAwaitable = Cysharp.Threading.Tasks.YieldAwaitable;

namespace SLZ.Marrow.Utilities
{
	public static class MarrowGame
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CInitialize_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public string appId;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private UniTask<UnityEngine.AddressableAssets.ResourceLocators.IResourceLocator>.Awaiter _003C_003Eu__2;

			private YieldAwaitable.Awaiter _003C_003Eu__3;

			private UniTask<MarrowSettings>.Awaiter _003C_003Eu__4;

			private UniTask.Awaiter _003C_003Eu__5;

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

		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CTryInitializeXRApi_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			private UniTask.Awaiter _003C_003Eu__1;

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

		public static MarrowPlayerLoop playerLoop;

		public static XRApi xr;

		public static AssetWarehouse assetWarehouse;

		public static MarrowSettings marrowSettings;

		public static Action<string> OnLogUpdate;

		private static Action _onReady;

		public static bool IsInitialized
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

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		public static void RuntimeInitializeAfterAssembliesLoaded()
		{
		}

		public static void RegisterOnReadyAction(Action action)
		{
		}

		[AsyncStateMachine(typeof(_003CInitialize_003Ed__12))]
		public static UniTask Initialize(string appId)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CTryInitializeXRApi_003Ed__13))]
		private static UniTask TryInitializeXRApi()
		{
			return default(UniTask);
		}

		private static void OnApplicationQuit()
		{
		}
	}
}
