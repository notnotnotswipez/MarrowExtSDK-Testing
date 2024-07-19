using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Interaction;
using SLZ.Marrow.Pool;
using SLZ.Marrow.Warehouse;
using UnityEngine;
using YieldAwaitable = Cysharp.Threading.Tasks.YieldAwaitable;

namespace SLZ.Marrow.Zones
{
	public class CrateSpawnSequencer : ZoneLinkItem, ISpawnListenable
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CSpawnLoop_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public CrateSpawnSequencer _003C_003E4__this;

			public CancellationToken ct;

			private UniTask.Awaiter _003C_003Eu__1;

			private YieldAwaitable.Awaiter _003C_003Eu__2;

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
		private float initialDelay;

		[SerializeField]
		private float spawnInterval;

		[Tooltip("Max amount that can be spawned")]
		[SerializeField]
		private float maxConcurrent;

		[Tooltip("Randomize which spawner is used")]
		[SerializeField]
		private bool randomizeSpawner;

		[SerializeField]
		private CrateSpawner[] crateSpawners;

		private int _spawnerIndex;

		private bool isActive;

		private CancellationTokenSource _spawnCTS;

		private Dictionary<CrateSpawner, RandomizeCrate> _crateRandLookup;

		private HashSet<Poolee> spawnedObjs;

		public List<Poolee> spawnedPoolees;

		public bool despawnAndReuseOldest;

		[Tooltip("How many items should get despawned each time limits are hit")]
		public int despawnCount;


		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		public void StartSpawning()
		{
		}

		public void StopSpawning()
		{
		}

		public void OnSpawn(GameObject go)
		{
		}

		public void OnDespawn(GameObject go)
		{
		}

		private void DespawnOldest()
		{
		}

		[AsyncStateMachine(typeof(_003CSpawnLoop_003Ed__24))]
		private UniTaskVoid SpawnLoop(CancellationToken ct)
		{
			return default(UniTaskVoid);
		}
	}
}
