using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Pool;
using UnityEngine;
using UnityEngine.Rendering;
using YieldAwaitable = Cysharp.Threading.Tasks.YieldAwaitable;

namespace SLZ.Bonelab
{
	[RequireComponent(typeof(Volume))]
	public class FadeVolume : SpawnEvents
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CFadeOverTime_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public float seconds;

			public FadeVolume _003C_003E4__this;

			private float _003CrecpSeconds_003E5__2;

			private float _003Ctimer_003E5__3;

			private YieldAwaitable.Awaiter _003C_003Eu__1;

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

		public Volume volume;

		public Action onComplete;

		public float duration;

		private float startValue;

		private float endValue;

		public MeshRenderer meshRenderer;

		private Material mat;

		protected override void Awake()
		{
		}

		public override void OnPoolInitialize()
		{
		}

		[AsyncStateMachine(typeof(_003CFadeOverTime_003Ed__9))]
		private UniTaskVoid FadeOverTime(float seconds)
		{
			return default(UniTaskVoid);
		}

		private static float easeInOutQuint(float start, float end, float val)
		{
			return 0f;
		}

		private void SetValues(float lerper)
		{
		}
	}
}
