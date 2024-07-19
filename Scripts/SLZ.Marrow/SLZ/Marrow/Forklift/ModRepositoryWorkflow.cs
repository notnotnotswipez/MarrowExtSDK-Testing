using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using SLZ.Marrow.Forklift.Model;

namespace SLZ.Marrow.Forklift
{
	public static class ModRepositoryWorkflow
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CFetchRepositoriesAsync_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<ModRepository[]> _003C_003Et__builder;

			public string parent;

			private string _003CrepositoriesTxt_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

			private UniTask<List<(int lineNumber, Uri url)>>.Awaiter _003C_003Eu__2;

			private UniTask<ModRepository[]>.Awaiter _003C_003Eu__3;

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
		private struct _003CReadValidUrlsAsync_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<List<(int lineNumber, Uri url)>> _003C_003Et__builder;

			public string repositoriesList;

			private List<(int lineNumber, Uri url)> _003Curis_003E5__2;

			private TaskAwaiter<string[]> _003C_003Eu__1;

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

		[PublicAPI]
		public static bool TryParseRepository(JObject repositoryJson, out ModRepository repo)
		{
			repo = null;
			return false;
		}

		[PublicAPI]
		[AsyncStateMachine(typeof(_003CFetchRepositoriesAsync_003Ed__1))]
		public static UniTask<ModRepository[]> FetchRepositoriesAsync(string parent)
		{
			return default(UniTask<ModRepository[]>);
		}

		[PublicAPI]
		[AsyncStateMachine(typeof(_003CReadValidUrlsAsync_003Ed__2))]
		public static UniTask<List<(int, Uri)>> ReadValidUrlsAsync(string repositoriesList)
		{
			return default(UniTask<List<(int, Uri)>>);
		}
	}
}
