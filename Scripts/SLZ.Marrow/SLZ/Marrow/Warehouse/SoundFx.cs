using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

namespace SLZ.Marrow.Warehouse
{
	public class SoundFx : DataCard
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CPreloadAssets_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public SoundFx _003C_003E4__this;

			private UniTask<AudioClip[]>.Awaiter _003C_003Eu__1;

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
		private struct _003CLoadRandomAudioClip_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<AudioClip> _003C_003Et__builder;

			public SoundFx _003C_003E4__this;

			public bool noRepeats;

			private UniTask<AudioClip>.Awaiter _003C_003Eu__1;

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

		[SerializeField]
		[Tooltip("AudioClip that represents the sound effect. Add multiple to be used as variation sounds")]
		private MarrowAssetT<AudioClip>[] _audioClips;

		private MarrowAssetT<AudioClip>[] _audioClipsCachedRandom;

		private bool randomFirst;

		public MarrowAssetT<AudioClip>[] AudioClips
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override bool IsBundledDataCard()
		{
			return false;
		}


		[AsyncStateMachine(typeof(_003CLoadRandomAudioClip_003Ed__8))]
		public UniTask<AudioClip> LoadRandomAudioClip(bool noRepeats = true)
		{
			return default(UniTask<AudioClip>);
		}

		public MarrowAssetT<AudioClip> GetRandomAudioClip(bool noRepeats = true)
		{
			return null;
		}

		private MarrowAssetT<AudioClip> GetRandomAudioClipNoRepeat()
		{
			return null;
		}

		public override void ImportPackedAssets(Dictionary<string, PackedAsset> packedAssets)
		{
		}

		public override List<PackedAsset> ExportPackedAssets()
		{
			return null;
		}
	}
}
