using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

namespace SLZ.Marrow.Warehouse
{
	[RequireComponent(typeof(BoxCollider))]
	public class CrateSpawnerGrid : MonoBehaviour
	{
		private struct GridRange
		{
			public Vector3 position;

			public float xMin;

			public float zMin;

			public float xMax;

			public float zMax;

			public float width;

			public float length;
		}

		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CStart_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public CrateSpawnerGrid _003C_003E4__this;

			private UniTask.Awaiter _003C_003Eu__1;

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
		private struct _003CSpawnGridAsync_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public CrateSpawnerGrid _003C_003E4__this;

			private List<CrateSpawner>.Enumerator _003C_003E7__wrap1;

			private UniTask<SLZ.Marrow.Pool.Poolee>.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

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

		public BoxCollider boxCollider;

		public bool allPallets;

		public List<PalletReference> pallets;

		public float margin;

		public float padding;

		public bool invertDirection;

		public bool manualSpawn;

		public List<SpawnableCrateReference> cratesToExclude;

		[SerializeField]
		[Header("Debug Fields")]
		private List<CrateSpawner> crateSpawners;

		[SerializeField]
		public List<float> rowMarkers;

		[SerializeField]
		public List<float> longestLengths;

		private void Reset()
		{
		}

		[AsyncStateMachine(typeof(_003CStart_003Ed__13))]
		private UniTaskVoid Start()
		{
			return default(UniTaskVoid);
		}

		[ContextMenu("Spawn")]
		public void SpawnGrid()
		{
		}

		[AsyncStateMachine(typeof(_003CSpawnGridAsync_003Ed__15))]
		private UniTask SpawnGridAsync()
		{
			return default(UniTask);
		}
	}
}
