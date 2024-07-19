using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine.XR.Management;

namespace SLZ.Marrow.Input
{
	public class XRApi
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CInitialize_003Ed__54 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public XRApi _003C_003E4__this;

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

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass60_0
		{
			public RefreshRateFeature feature;

			internal bool _003CInitializeXRLoader_003Eb__0()
			{
				return false;
			}
		}

		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CInitializeXRLoader_003Ed__60 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public XRApi _003C_003E4__this;

			private _003C_003Ec__DisplayClass60_0 _003C_003E8__1;

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
		private struct _003CWatchXRChanges_003Ed__61 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public XRApi _003C_003E4__this;

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

		private readonly CancellationTokenSource _cts;

		private InputActions _inputActions;

		public XRManagerSettings Settings => null;

		public XRHMD HMD
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

		public XRController LeftController
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

		public XRController RightController
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

		public XRHand LeftHand
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

		public XRHand RightHand
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

		public XRBody Body
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

		public GamepadActionMap Gamepad
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

		public ViveTrackerActionMap Trackers
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

		public DisplaySubsystemManager Display
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

		public InputSubsystemManager Input
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

		public MeshSubsystemManager Mesh
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

		public bool HasPalmPoseFeature
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

		private static bool IsFeatureSupported<TFeature>() where TFeature : OpenXRFeature
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CInitialize_003Ed__54))]
		public UniTask Initialize()
		{
			return default(UniTask);
		}

		public void Deinitialize()
		{
		}

		public void Refresh()
		{
		}

		private void OnStartFrame()
		{
		}

		private void OnPreNewInputUpdate()
		{
		}

		private void OnPostNewInputUpdate()
		{
		}

		[AsyncStateMachine(typeof(_003CInitializeXRLoader_003Ed__60))]
		private UniTask InitializeXRLoader()
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CWatchXRChanges_003Ed__61))]
		private UniTaskVoid WatchXRChanges()
		{
			return default(UniTaskVoid);
		}
	}
}
