using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SLZ.Marrow.Audio;
using SLZ.Marrow.Interaction;
using UnityEngine;

namespace SLZ.Marrow.Zones
{
	public class Zone3dSound : ZoneLinkItem
	{
		public enum SoundMode
		{
			CONTINUOUS = 0,
			ONE_SHOT = 1,
			PLAY_ON_ENTER = 2
		}

		[CompilerGenerated]
		private sealed class _003CFade_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Zone3dSound _003C_003E4__this;

			public float fadeTarget;

			public float fadeTime;

			private WaitForSecondsRealtime _003Cwait_003E5__2;

			private float _003CfadeTargetClamped_003E5__3;

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
			public _003CFade_003Ed__29(int _003C_003E1__state)
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

		public SoundMode soundMode;

		public Transform[] targetTran;

		[HideInInspector]
		public AudioClip clip;

		[Tooltip("More than one clip will randomize for PLAY_ON_ENTER mode")]
		public AudioClip[] clips;

		[Range(0f, 1f)]
		public float primaryVolume;

		[Range(0f, 1f)]
		public float secondaryVolume;

		public float pitch;

		[Range(0.1f, 4f)]
		[Tooltip("Higher number fades faster")]
		public float fadeSpeed;

		[Tooltip("Radius of min sphere")]
		[Range(0.1f, 10f)]
		public float sourceRadius;

		private bool loop;

		private bool hasPlayed;

		private bool _fadeActive;

		private bool _inPrimary;

		private AudioPlayer _ap;

		private float _curVol;

		[Tooltip("0 = no delays, any other value, will cause wait to happen randomly between value and 50% of value")]
		public float waitTime;

		private float _nextFirable;

		private bool _useRandomClip;

		private int _randomClipIndex;

		private int _randomTransformIndex;

		public AudioPlayer audioPlayer => null;

		public void SetSecondaryVolume(float volume)
		{
		}

		private void PlayNew(Action callback = null)
		{
		}

		[IteratorStateMachine(typeof(_003CFade_003Ed__29))]
		private IEnumerator Fade(float fadeTarget, float fadeTime)
		{
			return null;
		}

		private float randomizeFloat(float max, float minMultiplier)
		{
			return 0f;
		}

		public void StopSound()
		{
		}

		public void PlaySound()
		{
		}
	}
}
