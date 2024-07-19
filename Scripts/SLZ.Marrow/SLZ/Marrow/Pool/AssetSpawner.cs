using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Data;
using SLZ.Marrow.Warehouse;
using UnityEngine;

namespace SLZ.Marrow.Pool
{
	public class AssetSpawner : MonoBehaviour
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CRegisterAsync_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public Barcode barcode;

			private UniTask<GameObject>.Awaiter _003C_003Eu__1;

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
		private struct _003CInstantiateForWarmupAsync_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public Spawnable spawnable;

			private UniTask<Poolee>.Awaiter _003C_003Eu__1;

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
		private struct _003CSpawnAsync_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<Poolee> _003C_003Et__builder;

			public Spawnable spawnable;

			public bool ignorePolicy;

			public int? groupID;

			public Vector3 position;

			public Quaternion rotation;

			public Vector3? scale;

			public Transform parent;

			public Action<GameObject> despawnCallback;

			public Action<GameObject> spawnCallback;

			private SpawnPolicy _003CactivePolicy_003E5__2;

			private UniTask<Poolee>.Awaiter _003C_003Eu__1;

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

		private static bool _hasInstance;

		private static AssetSpawner _instance;

		private Dictionary<Barcode, Pool> _barcodeToPool;

		private Dictionary<Poolee, SpawnPolicy> _pooleeToPolicy;

		private Dictionary<int, SpawnPolicy> _policySpawns;

		private List<Pool> _poolList;

		private static ulong _spawnCount;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private static void Instantiate()
		{
		}

		public static ulong GetNewID()
		{
			return 0uL;
		}

		public static void Register(Spawnable spawnable)
		{
		}

		[AsyncStateMachine(typeof(_003CRegisterAsync_003Ed__12))]
		public static UniTask RegisterAsync(Barcode barcode)
		{
			return default(UniTask);
		}

		[AsyncStateMachine(typeof(_003CInstantiateForWarmupAsync_003Ed__13))]
		public static UniTask InstantiateForWarmupAsync(Spawnable spawnable)
		{
			return default(UniTask);
		}

		public static void Spawn(Spawnable spawnable, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion), Vector3? scale = null, Transform parent = null, bool ignorePolicy = false, int? groupID = null, Action<GameObject> spawnCallback = null, Action<GameObject> despawnCallback = null)
		{
		}

		[AsyncStateMachine(typeof(_003CSpawnAsync_003Ed__15))]
		public static UniTask<Poolee> SpawnAsync(Spawnable spawnable, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion), Vector3? scale = null, Transform parent = null, bool ignorePolicy = false, int? groupID = null, Action<GameObject> spawnCallback = null, Action<GameObject> despawnCallback = null)
		{
			return default(UniTask<Poolee>);
		}

		public static void Clear(Poolee poolee)
		{
		}

		public static void Despawn(Poolee poolee)
		{
		}
	}
}
