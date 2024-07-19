using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Warehouse;
using UnityEngine;
using UnityEngine.Scripting;

namespace SLZ.Marrow.Plugins
{
	[Preserve]
	public sealed class MarrowPlugins
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CTriggerOnBeforeLevelLoad_003Ed__44 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public MarrowPlugins _003C_003E4__this;

			public LevelCrateReference level;

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
		private struct _003CTriggerOnAfterLevelLoad_003Ed__45 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public MarrowPlugins _003C_003E4__this;

			public LevelCrateReference level;

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
		private struct _003CTriggerOnBeforeLevelUnload_003Ed__46 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public MarrowPlugins _003C_003E4__this;

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
		private struct _003CTriggerOnAfterLevelUnload_003Ed__47 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public MarrowPlugins _003C_003E4__this;

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
		private struct _003C_TriggerAsync_003Ed__48<TPlugin> : IAsyncStateMachine where TPlugin : IMarrowPlugin
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public MarrowPlugins _003C_003E4__this;

			public bool forward;

			public Func<MarrowPluginWrapper, TPlugin, object, UniTask> callback;

			public object context;

			private List<List<string>>.Enumerator _003C_003E7__wrap1;

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

		private const bool DISABLE_LIFECYCLE_LOGGING = false;

		private const bool DISABLE_GRAPH_LOGGING = true;

		private const bool DISABLE_ASSEMBLY_LOGGING = true;

		private static MarrowPlugins _instance;

		public static MarrowPlugins Instance => null;

		public bool IsRunning
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		private OrderedDictionary OrderedPluginWrappersByQN
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		private Dictionary<Type, MarrowPluginWrapper> PluginWrappersByType
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		private Dictionary<string, HashSet<string>> DependenciesByQN
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		private List<List<string>> CachedGroups
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		[RuntimeInitializeOnLoadMethod]
		private static void EnsurePluginSystem()
		{
		}

		private MarrowPlugins()
		{
		}

		~MarrowPlugins()
		{
		}

		private void Application_quitting()
		{
		}

		private void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
		{
		}

		private void OnAfterAssembliesLoaded()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void AfterAssembliesLoaded()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
		private static void BeforeSplashScreen()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void BeforeSceneLoad()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void AfterSceneLoad()
		{
		}

		internal UniTask TriggerOnMarrowPluginLoad()
		{
			return default(UniTask);
		}

		internal UniTask TriggerOnMarrowPluginStart()
		{
			return default(UniTask);
		}

		internal UniTask TriggerOnMarrowPluginStop()
		{
			return default(UniTask);
		}

		internal UniTask TriggerOnMarrowPluginEditorPaused()
		{
			return default(UniTask);
		}

		internal UniTask TriggerOnMarrowPluginEditorUnpaused()
		{
			return default(UniTask);
		}

		internal UniTask TriggerOnMarrowPluginEditorEnteredEditMode()
		{
			return default(UniTask);
		}

		internal UniTask TriggerOnMarrowPluginEditorExitingEditMode()
		{
			return default(UniTask);
		}

		internal UniTask TriggerOnMarrowPluginEditorEnteredPlayMode()
		{
			return default(UniTask);
		}

		internal UniTask TriggerOnMarrowPluginEditorExitingPlayMode()
		{
			return default(UniTask);
		}

		internal UniTask TriggerOnMarrowPluginEditorBeforeAssemblyReload()
		{
			return default(UniTask);
		}

		internal UniTask TriggerOnMarrowPluginEditorAfterAssemblyReload()
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CTriggerOnBeforeLevelLoad_003Ed__44))]
		internal UniTask TriggerOnBeforeLevelLoad(LevelCrateReference level)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CTriggerOnAfterLevelLoad_003Ed__45))]
		internal UniTask TriggerOnAfterLevelLoad(LevelCrateReference level)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CTriggerOnBeforeLevelUnload_003Ed__46))]
		internal UniTask TriggerOnBeforeLevelUnload()
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CTriggerOnAfterLevelUnload_003Ed__47))]
		internal UniTask TriggerOnAfterLevelUnload()
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003C_TriggerAsync_003Ed__48<>))]
		private UniTask _TriggerAsync<TPlugin>(bool forward, object context, Func<MarrowPluginWrapper, TPlugin, object, UniTask> callback) where TPlugin : IMarrowPlugin
		{
			return default(UniTask);
		}

		private static void _ThrowIfCycles(List<List<string>> groups)
		{
		}

		public bool TryGetPlugin<TPlugin>(out TPlugin plugin) where TPlugin : IMarrowPlugin
		{
			plugin = default(TPlugin);
			return false;
		}

		private bool TryGetPluginWrapper<TPlugin>(out MarrowPluginWrapper marrowPluginWrapper) where TPlugin : IMarrowPlugin
		{
			marrowPluginWrapper = null;
			return false;
		}

		private bool TryGetPluginWrapper(string qualifiedName, out MarrowPluginWrapper marrowPluginWrapper)
		{
			marrowPluginWrapper = null;
			return false;
		}

		internal void ScanForPluginsInAssembly(Assembly loadedAssembly, bool includingTests = false)
		{
		}

		private void AddPlugin(Type type)
		{
		}

		internal void AddPlugins(List<(Type, MarrowPluginAttribute)> plugins)
		{
		}
	}
}
