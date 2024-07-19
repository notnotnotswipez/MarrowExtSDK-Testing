using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace SLZ.Marrow.Utilities
{
	public static class MarrowEntitlement
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CCheckEntitlementAsync_003Ed__0 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			public string appId;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

            void IAsyncStateMachine.MoveNext()
            {
                throw new System.NotImplementedException();
            }

            [DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                throw new System.NotImplementedException();
            }
        }

		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CCheckSteamEntitlementAsync_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			public string appId;

			private void MoveNext()
			{
			}

            void IAsyncStateMachine.MoveNext()
            {
                throw new System.NotImplementedException();
            }

            [DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                throw new System.NotImplementedException();
            }
        }

		[AsyncStateMachine(typeof(_003CCheckEntitlementAsync_003Ed__0))]
		public static UniTask<bool> CheckEntitlementAsync(string appId)
		{
			return default(UniTask<bool>);
		}

		public static void Close()
		{
		}

		[AsyncStateMachine(typeof(_003CCheckSteamEntitlementAsync_003Ed__2))]
		private static UniTask<bool> CheckSteamEntitlementAsync(string appId)
		{
			return default(UniTask<bool>);
		}
	}
}
