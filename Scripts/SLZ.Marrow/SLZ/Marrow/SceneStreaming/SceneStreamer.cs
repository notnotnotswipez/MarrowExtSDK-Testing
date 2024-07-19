using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Warehouse;

namespace SLZ.Marrow.SceneStreaming
{
	public static class SceneStreamer
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CLoadAsync_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public LevelCrateReference level;

			public LevelCrateReference loadLevel;

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

		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CReloadAsync_003Ed__9 : IAsyncStateMachine
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

		private static StreamSession _session;

		public static Action doAnyLevelLoad;

		public static Action doAnyLevelUnload;

		public static StreamSession Session => null;

		public static void Load(Barcode levelBarcode, Barcode loadLevelBarcode = null)
		{
		}

		public static void Load(LevelCrateReference level, LevelCrateReference loadLevel)
		{
		}

		[AsyncStateMachine(typeof(_003CLoadAsync_003Ed__7))]
		public static UniTask LoadAsync(LevelCrateReference level, LevelCrateReference loadLevel = null)
		{
			return default(UniTask);
		}

		public static void Reload()
		{
		}

		[AsyncStateMachine(typeof(_003CReloadAsync_003Ed__9))]
		public static UniTask ReloadAsync()
		{
			return default(UniTask);
		}
	}
}
