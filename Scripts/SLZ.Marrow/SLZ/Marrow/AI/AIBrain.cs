using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SLZ.Marrow.Pool;
using SLZ.Marrow.PuppetMasta;
using UnityEngine;
using UnityEngine.Events;

namespace SLZ.Marrow.AI
{
	public class AIBrain : SpawnEvents
	{
		public class SpawnGroupEvent : UnityEvent<AIBrain, bool>
		{
			public SpawnGroupEvent()
			{
				
			}
		}

		[CompilerGenerated]
		private sealed class _003CCoArenaEntrance_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AIBrain _003C_003E4__this;

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
			public _003CCoArenaEntrance_003Ed__29(int _003C_003E1__state)
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

		[Header("References")]
		public BehaviourBaseNav behaviour;

		public PuppetMaster puppetMaster;

		public bool dontClearBaseConfig;

		public Action<AIBrain> onDeathDelegate;

		public Action<AIBrain> onResurrectDelegate;

		public Action<AIBrain> onNPC_DeathDelegate;

		public SpawnGroupEvent OnGroupDeregister;

		[HideInInspector]
		public bool isDead;

		private bool _wasConfigSet;

		private Coroutine arenaEntranceRoutine;

		private float entranceTimer;

		public BehaviourBaseNav.MentalState MentalState => default(BehaviourBaseNav.MentalState);

		public bool IsSoundAggroWhenInSecondaryZone => false;

		public void SpawnGroupIgnore(bool val)
		{
		}

		protected override void Reset()
		{
		}

		protected override void Awake()
		{
		}

		public override void OnPoolInitialize()
		{
		}

		public override void OnPoolDeInitialize()
		{
		}

		public void SetBaseConfig(BaseEnemyConfig config)
		{
		}

		public void SetVelocity(Vector3 velocity)
		{
		}

		public void SetAngularVelocity(Vector3 angularVelocity)
		{
		}

		public void SetAngularVelocity(float minAngularSpeed, float maxAngularSpeed)
		{
		}

		private void OnDeath()
		{
		}

		private void OnResurrection()
		{
		}

		public void StartArenaEntranceTimer(float time = 120f)
		{
		}

		public void StopArenaEntranceTimer()
		{
		}

		[IteratorStateMachine(typeof(_003CCoArenaEntrance_003Ed__29))]
		private IEnumerator CoArenaEntrance()
		{
			return null;
		}
	}
}
