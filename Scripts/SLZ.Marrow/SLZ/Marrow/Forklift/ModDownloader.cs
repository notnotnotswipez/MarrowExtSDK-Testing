using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using SLZ.Marrow.Forklift.Model;
using SLZ.Marrow.Warehouse;

namespace SLZ.Marrow.Forklift
{
	[PublicAPI]
	public static class ModDownloader
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CLoadModSettings_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			private TaskAwaiter<byte[]> _003C_003Eu__1;

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
		private struct _003CAddInvalidModFile_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public long modID;

			public long fileID;

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
		private struct _003CRemoveInvalidModFile_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public long modID;

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
		private struct _003CWriteModSettings_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			private FileStream _003Cfs_003E5__2;

			private StreamWriter _003Csw_003E5__3;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private object _003C_003E7__wrap5;

			private int _003C_003E7__wrap6;

			private TaskAwaiter _003C_003Eu__1;

			private ValueTaskAwaiter _003C_003Eu__2;

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
		private struct _003CDownloadMod_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<Pallet> _003C_003Et__builder;

			public ModListing listing;

			public ModTarget target;

			public CancellationToken cancellationToken;

			public IProgress<FileDownloadProgress> progress;

			private string _003CdownloadsDir_003E5__2;

			private FileStream _003CfileStream_003E5__3;

			private string _003CfilePath_003E5__4;

			private ModIOModTarget _003CmodIOTarget_003E5__5;

			private UniTask<SLZ.ModIO.Result<SLZ.ModIO.ApiModels.ModfileObject>>.Awaiter _003C_003Eu__1;

			private HttpClient _003ChttpClient_003E5__6;

			private HttpResponseMessage _003Cresponse_003E5__7;

			private UniTask<HttpResponseMessage>.Awaiter _003C_003Eu__2;

			private SwitchToThreadPoolAwaitable.Awaiter _003C_003Eu__3;

			private object _003C_003E7__wrap7;

			private int _003C_003E7__wrap8;

			private long? _003Cfilesize_003E5__10;

			private Stream _003CdownloadStream_003E5__11;

			private UniTask<Stream>.Awaiter _003C_003Eu__4;

			private object _003C_003E7__wrap11;

			private int _003C_003E7__wrap12;

			private byte[] _003Cbuffer_003E5__14;

			private int _003CbytesRead_003E5__15;

			private long _003CtotalRead_003E5__16;

			private UniTask.Awaiter _003C_003Eu__5;

			private UniTask<int>.Awaiter _003C_003Eu__6;

			private ValueTaskAwaiter _003C_003Eu__7;

			private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__8;

			private FileStream _003C_003E7__wrap16;

			private Pallet _003C_003E7__wrap17;

			private ZipArchive _003Czip_003E5__19;

			private Pallet _003Cpallet_003E5__20;

			private string _003CstagingDir_003E5__21;

			private string _003CdestinationDir_003E5__22;

			private UniTask<bool>.Awaiter _003C_003Eu__9;

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

		private const bool SPAMMY_UPDATES = false;

		private const bool STRICT_VERSION_EQUALITY_CHECK = false;

		[CanBeNull]
		private static JObject ModSettingsJSON;

		private static Dictionary<long, long> invalidMods;

		public static bool VerboseLogging => false;

		public static ModIOManager ModIOManager
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

		private static string ModSettingsPath => null;

		[AsyncStateMachine(typeof(_003CLoadModSettings_003Ed__10))]
		public static UniTask LoadModSettings()
		{
			return default(UniTask);
		}

		public static Dictionary<long, long> GetInvalidMods()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAddInvalidModFile_003Ed__12))]
		public static UniTask AddInvalidModFile(long modID, long fileID, CancellationToken cancelToken)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CRemoveInvalidModFile_003Ed__13))]
		public static UniTask RemoveInvalidModFile(long modID, CancellationToken cancelToken)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CWriteModSettings_003Ed__14))]
		public static UniTask WriteModSettings()
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CDownloadMod_003Ed__17))]
		public static UniTask<Pallet> DownloadMod(ModListing listing, ModTarget target, [CanBeNull] IProgress<FileDownloadProgress> progress, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask<Pallet>);
		}
	}
}
