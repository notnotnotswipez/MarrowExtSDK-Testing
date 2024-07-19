using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Warehouse;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using YieldAwaitable = Cysharp.Threading.Tasks.YieldAwaitable;

namespace SLZ.Marrow.SceneStreaming
{
	public class StreamSession
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CLoad_003Ed__28 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public StreamSession _003C_003E4__this;

			private float _003CmaxDeltaTime_003E5__2;

			private SceneInstance _003CloadingSI_003E5__3;

			private Scene _003CloadContainer_003E5__4;

			private MonoDisc _003CloadMonoDisc_003E5__5;

			private AudioClip _003CloadMusicClip_003E5__6;

			private double _003CtempPrePersistentTimeCache_003E5__7;

			private Scene _003CpersistentScene_003E5__8;

			private MarrowSettings _003Csettings_003E5__9;

			private UniTask<SceneInstance>.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

			private YieldAwaitable.Awaiter _003C_003Eu__3;

			private UniTask<AudioClip>.Awaiter _003C_003Eu__4;

			private UniTask<Scene>.Awaiter _003C_003Eu__5;

			private UniTask<SLZ.Marrow.Pool.Poolee>.Awaiter _003C_003Eu__6;

			private PlayerMarker _003CplayerMarker_003E5__10;

			private Transform _003CplayerTransform_003E5__11;

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
		private struct _003CLoadPersistentScenes_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<Scene> _003C_003Et__builder;

			public StreamSession _003C_003E4__this;

			private string _003CrootPersistentAddress_003E5__2;

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
		private struct _003CUnloadAllOtherScenes_003Ed__33 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public Scene loadingScene;

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

		private readonly LevelCrateReference _level;

		public readonly LevelCrate Level;

		private readonly LevelCrateReference _loadLevel;

		public readonly LevelCrate LoadLevel;

		private readonly SceneLoadQueue _persistentQueue;

		private Action _doLevelLoad;

		private Action _doLevelUnload;

		private bool _willPersistentSceneLoadHappened;

		private Action _willPersistentSceneLoad;

		private bool _doPersistentSceneLoadHappened;

		private Action _doPersistentSceneLoad;

		private List<PlayerMarker> _playerMarkers;

		private int _loadDependencyCount;

		public StreamStatus Status
		{
			[CompilerGenerated]
			get
			{
				return default(StreamStatus);
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public SceneLoader SceneLoader
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

		public StreamSession(LevelCrateReference level, LevelCrateReference loadLevel = null)
		{
		}

		public void RegisterLoadDependency()
		{
		}

		public void UnregisterLoadDependency()
		{
		}

		public void AddDoPersistentLoadCallback(Action cb)
		{
		}

		public void AddWillPersistentLoadCallback(Action cb)
		{
		}

		public void AddDoLevelLoadCallback(Action cb)
		{
		}

		public void AddDoLevelUnloadCallback(Action cb)
		{
		}

		[AsyncStateMachine(typeof(_003CLoad_003Ed__28))]
		internal UniTask Load()
		{
			return default(UniTask);
		}

		public void End()
		{
		}

		public StreamSession Refresh()
		{
			return null;
		}

		public void RegisterPlayerMarker(PlayerMarker playerMarker)
		{
		}

		[AsyncStateMachine(typeof(_003CLoadPersistentScenes_003Ed__32))]
		private UniTask<Scene> LoadPersistentScenes()
		{
			return default(UniTask<Scene>);
		}

		[AsyncStateMachine(typeof(_003CUnloadAllOtherScenes_003Ed__33))]
		private UniTask UnloadAllOtherScenes(Scene loadingScene)
		{
			return default(UniTask);
		}
	}
}
