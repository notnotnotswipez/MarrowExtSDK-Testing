using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SLZ.Marrow.Console
{
	public class ConsoleCommandWrapperConverter : IObjectDescriber, ITokenConverter<ConsoleCommandWrapper>
	{
		[CompilerGenerated]
		private sealed class _003CConvert_003Ed__3 : IEnumerable<ConsoleCommandWrapper>, IEnumerable, IEnumerator<ConsoleCommandWrapper>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ConsoleCommandWrapper _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private TokenParseContext context;

			public TokenParseContext _003C_003E3__context;

			private string token;

			public string _003C_003E3__token;

			private HashSet<ConsoleCommandWrapper>.Enumerator _003C_003E7__wrap1;

			private ConsoleCommandWrapper _003CcommandWrapper_003E5__3;

			private IEnumerator<ConsoleCommandAttribute> _003C_003E7__wrap3;

			private ConsoleCommandWrapper System_002ECollections_002EGeneric_002EIEnumerator_003CSLZ_002EMarrow_002EConsole_002EConsoleCommandWrapper_003E_002ECurrent
			{
				[DebuggerHidden]
				get
				{
					return null;
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

            public ConsoleCommandWrapper Current => throw new NotImplementedException();

            object IEnumerator.Current => throw new NotImplementedException();

            [DebuggerHidden]
			public _003CConvert_003Ed__3(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			private void System_002ECollections_002EIEnumerator_002EReset()
			{
			}

			[DebuggerHidden]
			private IEnumerator<ConsoleCommandWrapper> System_002ECollections_002EGeneric_002EIEnumerable_003CSLZ_002EMarrow_002EConsole_002EConsoleCommandWrapper_003E_002EGetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			private IEnumerator System_002ECollections_002EIEnumerable_002EGetEnumerator()
			{
				return null;
			}

            public IEnumerator<ConsoleCommandWrapper> GetEnumerator()
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

		public bool CanDescribe(Type type)
		{
			return false;
		}

		public bool TryDescribe(object obj, TokenParseContext context, out ObjectDescription description)
		{
			description = null;
			return false;
		}

		public bool CanConvert(Type type)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CConvert_003Ed__3))]
		public IEnumerable<ConsoleCommandWrapper> Convert(string token, TokenParseContext context)
		{
			return null;
		}

		public TokenSuggestions<ConsoleCommandWrapper> SuggestConversions(string partialOrEmptyToken, TokenParseContext context)
		{
			return null;
		}
	}
}
