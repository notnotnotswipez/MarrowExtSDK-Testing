using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using SLZ.ModIO;
using SLZ.ModIO.ApiModels;
using SLZ.ModIO.WebSockets;
using UnityEngine;

namespace SLZ.Marrow.Forklift
{
	public class ModIOManager : MonoBehaviour
	{
		public delegate UniTask LoginSequenceHandler();

		public delegate UniTask UserCodePromptHandler(DeviceLoginResponseContext loginResponseContext);

		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CLoadAndCheckLogin_003Ed__42 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			public CancellationToken cancellationToken;

			public ModIOManager _003C_003E4__this;

			private CancellationTokenSource _003ClinkedCTS_003E5__2;

			private CancellationToken _003ClinkedToken_003E5__3;

			private string _003CloadedAccessToken_003E5__4;

			private UniTask<JObject>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

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

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass43_0
		{
			[StructLayout(3)]
			private struct _003C_003CLogIn_003Eb__0_003Ed : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncUniTaskMethodBuilder _003C_003Et__builder;

				public _003C_003Ec__DisplayClass43_0 _003C_003E4__this;

				private TaskAwaiter _003C_003Eu__1;

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

			public ModIOManager _003C_003E4__this;

			public CancellationTokenSource receiveAndOtherCTS;

			[AsyncStateMachine(typeof(_003C_003CLogIn_003Eb__0_003Ed))]
			internal UniTask _003CLogIn_003Eb__0()
			{
				return default(UniTask);
			}
		}

		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CLogIn_003Ed__43 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public ModIOManager _003C_003E4__this;

			public CancellationToken cancellationToken;

			private _003C_003Ec__DisplayClass43_0 _003C_003E8__1;

			private CancellationTokenSource _003ClinkedCTS_003E5__2;

			private CancellationToken _003ClinkedToken_003E5__3;

			private UniTask.Awaiter _003C_003Eu__1;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private TaskAwaiter _003C_003Eu__3;

			private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__4;

			private Exception _003Ce_003E5__6;

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
		private struct _003CApiOnMessageReceived_003Ed__44 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ModIOManager _003C_003E4__this;

			public Message message;

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
		private struct _003CApiOnMessageReceivedUT_003Ed__45 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public Message message;

			public ModIOManager _003C_003E4__this;

			private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

			private object _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

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
		private struct _003CValidateAccessToken_003Ed__46 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			public string accessToken;

			public ModIOManager _003C_003E4__this;

			public CancellationToken cancellationToken;

			private TaskAwaiter<Result<UserObject>> _003C_003Eu__1;

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
		private struct _003CLoadModSettings_003Ed__47 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<JObject> _003C_003Et__builder;

			public CancellationToken cancellationToken;

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

		private CancellationTokenSource _enableCTS;

		private CancellationTokenSource _receiveLoopCTS;

		private static string ModIOSettingsPath => null;

		public string ModIOApiKey
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

		public int ModIOGameId => 0;

		public bool IsLoggedIn
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

		public ModIOAPI ModIOAPI
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

		public ModIOWebSocketAPI ModIOWebSocketAPI
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

		[CanBeNull]
		public JObject ModSettingsJSON
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

		public event LoginSequenceHandler BeginUserInitiatedLogin
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event UserCodePromptHandler RequestUserCodeEntry
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event LoginSequenceHandler CompleteUserInitiatedLogin
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event LoginSequenceHandler FailUserInitiatedLogin
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadAndCheckLogin_003Ed__42))]
		public UniTask<bool> LoadAndCheckLogin(CancellationToken cancellationToken)
		{
			return default(UniTask<bool>);
		}

		[AsyncStateMachine(typeof(_003CLogIn_003Ed__43))]
		public UniTaskVoid LogIn(CancellationToken cancellationToken)
		{
			return default(UniTaskVoid);
		}

		[AsyncStateMachine(typeof(_003CApiOnMessageReceived_003Ed__44))]
		private Task ApiOnMessageReceived(Message message)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CApiOnMessageReceivedUT_003Ed__45))]
		private UniTask ApiOnMessageReceivedUT(Message message)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CValidateAccessToken_003Ed__46))]
		private UniTask<bool> ValidateAccessToken(string accessToken, CancellationToken cancellationToken)
		{
			return default(UniTask<bool>);
		}

		[AsyncStateMachine(typeof(_003CLoadModSettings_003Ed__47))]
		private static UniTask<JObject> LoadModSettings(CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask<JObject>);
		}

		private static RequestContext _oneOffRequestContext(string apiKey, string accessToken)
		{
			return null;
		}
	}
}
