using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Interaction;
using YieldAwaitable = Cysharp.Threading.Tasks.YieldAwaitable;

namespace SLZ.Marrow.Zones
{
	internal class ZoneCullManager
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CWaitToSolveCullState_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public ZoneCullManager _003C_003E4__this;

			private YieldAwaitable.Awaiter _003C_003Eu__1;

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

		private readonly Dictionary<int, CullerData> _cullerDatas;

		private readonly Dictionary<InactiveStatus, List<int>> _entityToCullerId;

		private readonly Dictionary<InactiveStatus, int> _orphanEntityToLastCullerId;

		private List<CullerData> _changedCullers;

		private bool _isWaitingToSolveCullState;

		public void Register(int cullerId, int priority)
		{
		}

		public void Unregister(int cullerId)
		{
		}

		public void Register(int cullerId, MarrowEntity entity)
		{
		}

		public void Unregister(int cullerId, InactiveStatus disableCallbackHandler)
		{
		}

		public void Cull(InactiveStatus activatorEntity, int cullerId, bool isCulled)
		{
		}

		public void ForceCull(int cullerId, bool isCulled)
		{
		}

		public bool IsCulled(int cullerId)
		{
			return false;
		}

		public void Clear(InactiveStatus disableCallbackHandler)
		{
		}

		private void Orphan(InactiveStatus entity, int cullerId)
		{
		}

		private void UnOrphan(InactiveStatus entity)
		{
		}

		private void SolveOrphanedCullState(InactiveStatus disableCallbackHandler)
		{
		}

		private void SolveCullState(InactiveStatus disableCallbackHandler)
		{
		}

		internal bool TryGetCullerData(int cullerId, out CullerData cullerData)
		{
			cullerData = null;
			return false;
		}

		[AsyncStateMachine(typeof(_003CWaitToSolveCullState_003Ed__18))]
		private UniTaskVoid WaitToSolveCullState()
		{
			return default(UniTaskVoid);
		}
	}
}
