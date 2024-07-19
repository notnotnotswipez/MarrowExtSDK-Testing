using System;
using System.Collections;
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
	public abstract class BaseConsoleCommand
	{
		[Flags]
		public enum CommandStatus : uint
		{
			Completable = 1u,
			Continuable = 2u,
			Disqualified = 4u,
			SuggestionIsDefault = 0x10000000u,
			SuggestionIsCurrentValue = 0x20000000u,
			SuggestionIsTemplate = 0x40000000u
		}

		[CompilerGenerated]
		private sealed class _003CParseNextArgument_003Ed__1 : IEnumerable<(CommandStatus, string, object)>, IEnumerable, IEnumerator<(CommandStatus, string, object)>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private (CommandStatus status, string token, object parsed) _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private string input;

			public string _003C_003E3__input;

			public BaseConsoleCommand _003C_003E4__this;

			private List<(string token, object parsed)> _003CcurrentParse_003E5__2;

			private IEnumerator<(string tok, int i)> _003C_003E7__wrap2;

			private (CommandStatus status, string token, object parsed) _003Cparse_003E5__4;

			private (CommandStatus, string, object) System_002ECollections_002EGeneric_002EIEnumerator_003C_0028SLZ_002EMarrow_002EConsole_002EBaseConsoleCommand_002ECommandStatusstatus_002CSystem_002EStringtoken_002CSystem_002EObjectparsed_0029_003E_002ECurrent
			{
				[DebuggerHidden]
				get
				{
					return default((CommandStatus, string, object));
				}
			}

			private object System_002ECollections_002EIEnumerator_002ECurrent
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

            public (CommandStatus, string, object) Current => throw new NotImplementedException();

            object IEnumerator.Current => throw new NotImplementedException();

            [DebuggerHidden]
			public _003CParseNextArgument_003Ed__1(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			private void System_002EIDisposable_002EDispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			private void System_002ECollections_002EIEnumerator_002EReset()
			{
			}

			[DebuggerHidden]
			private IEnumerator<(CommandStatus, string, object)> System_002ECollections_002EGeneric_002EIEnumerable_003C_0028SLZ_002EMarrow_002EConsole_002EBaseConsoleCommand_002ECommandStatusstatus_002CSystem_002EStringtoken_002CSystem_002EObjectparsed_0029_003E_002EGetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			private IEnumerator System_002ECollections_002EIEnumerable_002EGetEnumerator()
			{
				return null;
			}

            public IEnumerator<(CommandStatus, string, object)> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }

            bool IEnumerator.MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }

		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CDefaultEmptyCommand_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public BaseConsoleCommand _003C_003E4__this;

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

		[IteratorStateMachine(typeof(_003CParseNextArgument_003Ed__1))]
		public IEnumerable<(CommandStatus, string, object)> ParseNextArgument(string input)
		{
			return null;
		}

		protected virtual (CommandStatus, string, object) ParseTokenAtIndex(List<(string token, object parsed)> previousTokens, int index, string token)
		{
			return default((CommandStatus, string, object));
		}

		public virtual IUniTaskAsyncEnumerable<object> RunCommand(string command)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDefaultEmptyCommand_003Ed__4))]
		private UniTask DefaultEmptyCommand(IAsyncWriter<object> writer, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}
	}
}
