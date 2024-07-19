using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Cysharp.Threading.Tasks.Linq;

namespace SLZ.Marrow.Console
{
	[ConsoleCommand("__builtin", "help", "Show console help")]
	internal class HelpConsoleCommand : BaseConsoleCommand
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CCreate_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public IAsyncWriter<object> writer;

			private IEnumerator<ConsoleCommandAttribute> _003C_003E7__wrap1;

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

		public override IUniTaskAsyncEnumerable<object> RunCommand(string command)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CCreate_003Ed__1))]
		private static UniTask Create(IAsyncWriter<object> writer, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}
	}
}
