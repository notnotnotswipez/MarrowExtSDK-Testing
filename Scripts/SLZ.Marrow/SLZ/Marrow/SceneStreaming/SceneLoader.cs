using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Zones;
using YieldAwaitable = Cysharp.Threading.Tasks.YieldAwaitable;

namespace SLZ.Marrow.SceneStreaming
{
	public class SceneLoader
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CLoadAsync_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public SceneLoader _003C_003E4__this;

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
		private struct _003CLoadChunkBatch_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public SceneLoader _003C_003E4__this;

			public ChunkBatch chunkBatch;

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
		private struct _003CUnloadScenes_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public SceneLoader _003C_003E4__this;

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
		private struct _003CLoadScenes_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public SceneLoader _003C_003E4__this;

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

		private bool _isLoading;

		private SceneLoadQueue _sceneQueue;

		private List<SceneChunk> _activeChunks;

		private List<SceneChunk> _chunksToLoad;

		private List<SceneChunk> _chunksToUnload;

		private HashSet<string> _wasLoadedOnce;

		private Queue<ChunkBatch> _chunkQueue;

		private ChunkBatch _nextChunkBatch;

		public void Add(SceneChunk sceneChunk)
		{
		}

		[AsyncStateMachine(typeof(_003CLoadAsync_003Ed__10))]
		public UniTask LoadAsync()
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CLoadChunkBatch_003Ed__11))]
		private UniTask LoadChunkBatch(ChunkBatch chunkBatch)
		{
			return default(UniTask);
		}

		private void Solve(ChunkBatch cb)
		{
		}

		[AsyncStateMachine(typeof(_003CUnloadScenes_003Ed__13))]
		private UniTask UnloadScenes(ChunkBatch cb)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CLoadScenes_003Ed__14))]
		private UniTask LoadScenes(ChunkBatch cb)
		{
			return default(UniTask);
		}
	}
}
