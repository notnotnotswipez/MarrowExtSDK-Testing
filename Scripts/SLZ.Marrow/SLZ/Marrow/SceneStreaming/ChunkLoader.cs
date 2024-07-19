using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using YieldAwaitable = Cysharp.Threading.Tasks.YieldAwaitable;

namespace SLZ.Marrow.SceneStreaming
{
	public class ChunkLoader
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CSetActive_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public Chunk chunk;

			public ChunkLoader _003C_003E4__this;

			private UniTask.Awaiter _003C_003Eu__1;

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
		private struct _003CLoad_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public ChunkLoader _003C_003E4__this;

			public Chunk chunk;

			private UniTask.Awaiter _003C_003Eu__1;

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
		private struct _003CUnloadChunks_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public ChunkLoader _003C_003E4__this;

			private UniTask.Awaiter _003C_003Eu__1;

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
		private struct _003CLoadChunks_003Ed__28 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public ChunkLoader _003C_003E4__this;

			private bool _003CcallTetrahedralize_003E5__2;

			private UniTask.Awaiter _003C_003Eu__1;

			private YieldAwaitable.Awaiter _003C_003Eu__2;

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

		private SceneLoadQueue _sceneQueue;

		private List<Chunk> _activeChunks;

		private List<Chunk> _chunksToLoad;

		private List<Chunk> _chunksToUnload;

		private List<Chunk> _occupiedChunks;

		private HashSet<string> _wasLoadedOnce;

		private static Dictionary<string, List<ChunkTrigger>> _chunkToTrigger;

		private Chunk _bufferedChunk;

		private bool _isLoading;

		public List<ChunkTrigger> Triggers
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

		public List<ChunkTracker> Trackers
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

		public void SetOccupiedChunk(Chunk chunk)
		{
		}

		public void RemoveOccupiedChunk(Chunk chunk)
		{
		}

		public void RegisterTrigger(ChunkTrigger trigger)
		{
		}

		public void UnregisterTrigger(ChunkTrigger trigger)
		{
		}

		public void RegisterTracker(ChunkTracker tracker)
		{
		}

		public void UnregisterTracker(ChunkTracker tracker)
		{
		}

		private void SolveChunks(Chunk chunk)
		{
		}

		[AsyncStateMachine(typeof(_003CSetActive_003Ed__25))]
		public UniTask SetActive(Chunk chunk)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CLoad_003Ed__26))]
		private UniTask Load(Chunk chunk)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CUnloadChunks_003Ed__27))]
		private UniTask UnloadChunks()
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CLoadChunks_003Ed__28))]
		private UniTask LoadChunks()
		{
			return default(UniTask);
		}
	}
}
