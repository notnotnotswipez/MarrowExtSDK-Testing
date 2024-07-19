using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

namespace SLZ.Marrow.Audio
{
	public class Audio3dManager : MonoBehaviour
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CLoadMixers_003Ed__53 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public Audio3dManager _003C_003E4__this;

			private UniTask<AudioMixer>.Awaiter _003C_003Eu__1;

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
		private struct _003CPlayAtPointAsync_003Ed__64 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<AudioPlayer> _003C_003Et__builder;

			public Vector3 position;

			public AudioClip clip;

			public AudioMixerGroup mixerGroup;

			public float? volume;

			public float? pitch;

			public float? minDistance;

			public float? spatialBlend;

			private UniTask<SLZ.Marrow.Pool.Poolee>.Awaiter _003C_003Eu__1;

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
		private struct _003CPlayAtLocalPointAsync_003Ed__65 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<AudioPlayer> _003C_003Et__builder;

			public Transform parent;

			public Vector3 localPosition;

			public AudioClip clip;

			public AudioMixerGroup mixerGroup;

			public float? volume;

			public float? pitch;

			public float? minDistance;

			public float? spatialBlend;

			private UniTask<SLZ.Marrow.Pool.Poolee>.Awaiter _003C_003Eu__1;

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
		private struct _003CPlay2dOneShotAsync_003Ed__66 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<AudioPlayer> _003C_003Et__builder;

			public AudioClip clip;

			public AudioMixerGroup mixerGroup;

			public float? volume;

			public float? pitch;

			private UniTask<SLZ.Marrow.Pool.Poolee>.Awaiter _003C_003Eu__1;

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

		private static float audio_GlobalVolume;

		private static float audio_MusicVolume;

		private static float audio_SFXVolume;

		public static AudioMixerGroup softInteraction
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

		public static AudioMixerGroup ambience
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

		public static AudioMixerGroup inHead
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

		public static AudioMixerGroup ui
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

		public static AudioMixerGroup gunShot
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

		public static AudioMixerGroup impact
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

		public static AudioMixerGroup bulletImpact
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

		public static AudioMixerGroup diegeticMusic
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

		public static AudioMixerGroup footsteps
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

		public static AudioMixerGroup hardInteraction
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

		public static AudioMixerGroup shells
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

		public static AudioMixerGroup npcVocals
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

		public static AudioMixerGroup nonDiegeticMusic
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

		public static float audio_Master
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static float audio_Music
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static float audio_SFX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadMixers_003Ed__53))]
		private UniTaskVoid LoadMixers()
		{
			return default(UniTaskVoid);
		}

		public static void PlayAtPoint(AudioClip clip, Vector3 position, AudioMixerGroup mixerGroup, float volume = 1f, float pitch = 1f, float? pitchRng = null, float? minDistance = null, float? spatialBlend = null)
		{
		}

		public static void PlayAtPoint(AudioClip[] clips, Vector3 position, AudioMixerGroup mixerGroup, float volume = 1f, float pitch = 1f, float? pitchRng = null, float? minDistance = null, float? spatialBlend = null)
		{
		}

		public static void PlayAtPoint(AudioClip clip, AudioClip clipHalfMo, Vector3 position, AudioMixerGroup mixerGroup, float volume = 1f, float pitch = 1f, float? pitchRng = null, float? minDistance = null, float? spatialBlend = null)
		{
		}

		public static void PlayAtPoint(AudioClip[] clips, AudioClip[] clipsHalfMo, Vector3 position, AudioMixerGroup mixerGroup, float volume = 1f, float pitch = 1f, float? pitchRng = null, float? minDistance = null, float? spatialBlend = null)
		{
		}

		public static void PlayAtLocalPoint(AudioClip clip, Transform parent, Vector3 localPosition, AudioMixerGroup mixerGroup, float volume = 1f, float pitch = 1f, float? pitchRng = null, float? minDistance = null, float? spatialBlend = null)
		{
		}

		public static void PlayAtLocalPoint(AudioClip[] clips, Transform parent, Vector3 localPosition, AudioMixerGroup mixerGroup, float volume = 1f, float pitch = 1f, float? pitchRng = null, float? minDistance = null, float? spatialBlend = null)
		{
		}

		public static void PlayAtLocalPoint(AudioClip clip, AudioClip clipHalfMo, Transform parent, Vector3 localPosition, AudioMixerGroup mixerGroup, float volume = 1f, float pitch = 1f, float? pitchRng = null, float? minDistance = null, float? spatialBlend = null)
		{
		}

		public static void PlayAtLocalPoint(AudioClip[] clips, AudioClip[] clipsHalfMo, Transform parent, Vector3 localPosition, AudioMixerGroup mixerGroup, float volume = 1f, float pitch = 1f, float? pitchRng = null, float? minDistance = null, float? spatialBlend = null)
		{
		}

		public static void Play2dOneShot(AudioClip clip, AudioMixerGroup mixerGroup, float? volume = null, float? pitch = null)
		{
		}

		public static void Play2dOneShot(AudioClip[] clips, AudioMixerGroup mixerGroup, float? volume = null, float? pitch = null)
		{
		}

		[AsyncStateMachine(typeof(_003CPlayAtPointAsync_003Ed__64))]
		private static UniTask<AudioPlayer> PlayAtPointAsync(AudioClip clip, Vector3 position, AudioMixerGroup mixerGroup, float? volume = null, float? pitch = null, float? minDistance = null, float? spatialBlend = null)
		{
			return default(UniTask<AudioPlayer>);
		}

		[AsyncStateMachine(typeof(_003CPlayAtLocalPointAsync_003Ed__65))]
		private static UniTask<AudioPlayer> PlayAtLocalPointAsync(AudioClip clip, Transform parent, Vector3 localPosition, AudioMixerGroup mixerGroup, float? volume = null, float? pitch = null, float? minDistance = null, float? spatialBlend = null)
		{
			return default(UniTask<AudioPlayer>);
		}

		[AsyncStateMachine(typeof(_003CPlay2dOneShotAsync_003Ed__66))]
		private static UniTask<AudioPlayer> Play2dOneShotAsync(AudioClip clip, AudioMixerGroup mixerGroup, float? volume = null, float? pitch = null)
		{
			return default(UniTask<AudioPlayer>);
		}

		public static void SpawnAudioPlayer(Vector3 position = default(Vector3), Action<GameObject> callback = null)
		{
		}

		public void SetLowPassFilter(float lpf)
		{
		}

		private static void SETMIXERS()
		{
		}
	}
}
