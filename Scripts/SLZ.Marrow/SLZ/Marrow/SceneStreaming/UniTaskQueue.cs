using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace SLZ.Marrow.SceneStreaming
{
	public class UniTaskQueue<T>
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CWhenAll_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<T[]> _003C_003Et__builder;

			public UniTaskQueue<T> _003C_003E4__this;

			private UniTask<T[]>.Awaiter _003C_003Eu__1;

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

		private List<UniTask<T>> _taskQueue;

		public void Add(UniTask<T> task)
		{
		}

		[AsyncStateMachine(typeof(UniTaskQueue<>._003CWhenAll_003Ed__2))]
		public UniTask<T[]> WhenAll()
		{
			return default(UniTask<T[]>);
		}
	}
}
