using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Interaction;
using SLZ.Marrow.Zones;
using UltEvents;
using UnityEngine;

namespace SLZ.Marrow.AI
{
	public class Encounter : ZoneLinkItem
	{
		public enum SpawnOrder
		{
			PARALLEL = 0,
			SERIES = 1
		}

		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CWarmupLoop_003Ed__34 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public SpawnGroup group;

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
		private struct _003CEncounterLoop_003Ed__35 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public SpawnGroup group;

			public CancellationToken ct;

			public Encounter _003C_003E4__this;

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

		public SpawnOrder spawnOrder;

		public SpawnGroup[] spawnGroups;

		[Header("Encounter Music")]
		public AudioClip encounterMusic;

		[Range(0f, 1f)]
		public float volume;

		public bool loop;

		[Range(0f, 10f)]
		public float fadeInTime;

		[Range(0f, 10f)]
		public float fadeOutTime;

		private CancellationTokenSource[] _spawnCTSs;

		private int completeCount;

		private bool _complete;

		private bool _isEncounterActive;

		public UltEvent OnComplete;

		private bool isWarmed;

		private MarrowEntity playerEntity;

		[HideInInspector]
		public static bool encounterPasted;

		public Action OnEncounterReset;

		protected void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}


		[ContextMenu("StartEncounter")]
		public void StartEncounter()
		{
		}

		public void StartEncounter(MarrowEntity activatorEntity)
		{
		}

		public void WarmupEncounter()
		{
		}

		private void StartGroupEncounter(int groupID)
		{
		}

		[ContextMenu("ForceStopAndReset")]
		public void ForceStopContext()
		{
		}

		public void ForceStopAndReset(bool killAll = true)
		{
		}

		[ContextMenu("ForceStopAndComplete")]
		public void ForceStopCompContext()
		{
		}

		public void ForceStopAndComplete(bool killAll = true)
		{
		}

		[ContextMenu("PauseEncounter")]
		public void PauseEncounter()
		{
		}

		private void AwardGroupCompletion(SpawnGroup group)
		{
		}

		public void MentalAllEncounter(MarrowEntity entity)
		{
		}

		public void CompleteEncounter()
		{
		}

		[AsyncStateMachine(typeof(_003CWarmupLoop_003Ed__34))]
		private UniTaskVoid WarmupLoop(SpawnGroup group)
		{
			return default(UniTaskVoid);
		}

		[AsyncStateMachine(typeof(_003CEncounterLoop_003Ed__35))]
		private UniTaskVoid EncounterLoop(SpawnGroup group, CancellationToken ct)
		{
			return default(UniTaskVoid);
		}
	}
}
