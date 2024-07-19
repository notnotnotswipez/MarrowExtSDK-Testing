using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace SLZ.Marrow.SceneStreaming
{
	public class SceneLoadQueue
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CLoadAll_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public SceneLoadQueue _003C_003E4__this;

			public LoadSceneMode loadMode;

			public bool activateOnLoad;

			private SceneInstance[] _003Cresults_003E5__2;

			private int _003Ci_003E5__3;

			private AsyncOperationHandle<IList<IResourceLocation>> _003Chandle_003E5__4;

			private UniTask<IList<IResourceLocation>>.Awaiter _003C_003Eu__1;

			private UniTask<SceneInstance[]>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CUnloadAll_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public SceneLoadQueue _003C_003E4__this;

			public bool autoReleaseHandle;

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

		private Dictionary<Scene, uint> _loadedScenes;

		private Dictionary<string, SceneInstance> _addressToInstance;

		private HashSet<string> _loadAddressesHash;

		private List<string> _loadAddresses;

		private List<string> _unloadAddresses;

		private List<UniTask<SceneInstance>> _loadTasks;

		private List<UniTask> _unloadTasks;

		private CancellationTokenSource _loadCts;

		private CancellationTokenSource _unloadCts;

		public SceneInstance GetInstance(string address)
		{
			return default(SceneInstance);
		}

		public void AddLoad(string address)
		{
		}

		public void AddUnload(string address)
		{
		}

		public void Cancel()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadAll_003Ed__13))]
		public UniTask LoadAll(LoadSceneMode loadMode = LoadSceneMode.Additive, bool activateOnLoad = true)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CUnloadAll_003Ed__14))]
		public UniTask UnloadAll(bool autoReleaseHandle = true)
		{
			return default(UniTask);
		}

		~SceneLoadQueue()
		{
		}
	}
}
