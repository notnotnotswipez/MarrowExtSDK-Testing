using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Data;
using UnityEngine;
using UnityEngine.Audio;

namespace SLZ.Marrow.Audio
{
	public class Audio2dManager : MonoBehaviour
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CLoadMixers_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public Audio2dManager _003C_003E4__this;

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

		[CompilerGenerated]
		private sealed class _003COverrideCallback_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float releaseTime;

			public Audio2dManager _003C_003E4__this;

			private float _003CstopTime_003E5__2;

			private object System_002ECollections_002EGeneric_002EIEnumerator_003CSystem_002EObject_003E_002ECurrent
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

            public object Current => throw new NotImplementedException();

            [DebuggerHidden]
			public _003COverrideCallback_003Ed__20(int _003C_003E1__state)
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

			[DebuggerHidden]
			private void System_002ECollections_002EIEnumerator_002EReset()
			{
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

		[CompilerGenerated]
		private sealed class _003CLoopCue_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float introLength;

			public float tranFade;

			public Audio2dManager _003C_003E4__this;

			public AudioClip loop;

			private object System_002ECollections_002EGeneric_002EIEnumerator_003CSystem_002EObject_003E_002ECurrent
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

            public object Current => throw new NotImplementedException();

            [DebuggerHidden]
			public _003CLoopCue_003Ed__32(int _003C_003E1__state)
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

			[DebuggerHidden]
			private void System_002ECollections_002EIEnumerator_002EReset()
			{
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

		[CompilerGenerated]
		private sealed class _003CCoFadeReverbData_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float fadeTime;

			public Audio2dManager _003C_003E4__this;

			private float _003CstartTime_003E5__2;

			private float _003CendTime_003E5__3;

			private float _003ClerpPerc_003E5__4;

			private object System_002ECollections_002EGeneric_002EIEnumerator_003CSystem_002EObject_003E_002ECurrent
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

            public object Current => throw new NotImplementedException();

            [DebuggerHidden]
			public _003CCoFadeReverbData_003Ed__41(int _003C_003E1__state)
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

			[DebuggerHidden]
			private void System_002ECollections_002EIEnumerator_002EReset()
			{
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

		public AmbAndMusic[] ambAndMusics;

		private int _curAmb;

		private int _curMus;

		private Coroutine _loopPending;

		private bool _isOverride;

		private bool _overridenHasIntro;

		private AudioClip _overridenMusicClip;

		private float _overridenTargetVol;

		private float _overridenFadeInTime;

		private float _overridenFadeOutTime;

		private bool _overridenLoop;

		private AudioClip _overridenMusicIntro;

		private float _overridenLoopTransitionFade;

		private IEnumerator _overrideCallback;

		private double _timecodeMusic;

		private double _timecodeAmbience;

		private float[] tempData;

		private float minFadeTime;

		private Coroutine fadeRoutine;

		public AudioMixer mixer;

		public AudioReverbData prevReverbObj;

		public AudioReverbData reverbObj;

		private void Awake()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadMixers_003Ed__17))]
		private UniTaskVoid LoadMixers()
		{
			return default(UniTaskVoid);
		}

		public void CueOverrideMusic(AudioClip musicClip, float targetVol, float fadeInTime, float fadeOutTime, bool loop = true, bool timedRelease = true)
		{
		}

		public void StopOverrideMusic()
		{
		}

		[IteratorStateMachine(typeof(_003COverrideCallback_003Ed__20))]
		private IEnumerator OverrideCallback(float releaseTime)
		{
			return null;
		}

		public void CueAmbience(AudioClip ambienceClip, float targetVol = 0.1f, float fadeInTime = 3f, float fadeOutTime = 3f)
		{
		}

		public void CueAmbience(double timecode, AudioClip ambienceClip, float targetVol = 0.1f, float fadeInTime = 3f, float fadeOutTime = 3f)
		{
		}

		public void CueMusic(AudioClip musicClip, float targetVol, float fadeInTime = 1f, float fadeOutTime = 2f, bool loop = true)
		{
		}

		public void CueMusic(double timecode, AudioClip musicClip, float targetVol, float fadeInTime = 1f, float fadeOutTime = 2f, bool loop = true)
		{
		}

		private void CueMusicInternal(double timecode, AudioClip musicClip, float targetVol, float fadeInTime = 1f, float fadeOutTime = 2f, bool loop = true)
		{
		}

		public void CueMusicLoopWithIntro(AudioClip musicIntro, AudioClip musicLoop, float targetVol, float fadeInTime, float fadeOutTime, float loopTransitionFade)
		{
		}

		public void CueMusicLoopWithIntro(double timecode, AudioClip musicIntro, AudioClip musicLoop, float targetVol, float fadeInTime, float fadeOutTime, float loopTransitionFade)
		{
		}

		public void StopMusic(float fadeOutTime = 3f)
		{
		}

		public void StopMusic(double timecode, float fadeOutTime = 3f)
		{
		}

		public bool StopSpecificMusic(AudioClip specificClip, double timecode, float fadeOutTime = 3f)
		{
			return false;
		}

		private void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CLoopCue_003Ed__32))]
		private IEnumerator LoopCue(AudioClip loop, float introLength, float tranFade)
		{
			return null;
		}

		public float GetParamVal(string name, float value)
		{
			return 0f;
		}

		public void FadeToNewReverb(AudioReverbData reverbData)
		{
		}

		[IteratorStateMachine(typeof(_003CCoFadeReverbData_003Ed__41))]
		private IEnumerator CoFadeReverbData(float fadeTime)
		{
			return null;
		}

		private void StopFadeRoutine()
		{
		}
	}
}
