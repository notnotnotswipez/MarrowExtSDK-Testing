using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Data;
using UnityEngine;

namespace SLZ.Marrow.Pool
{
	public class SpawnPolicy
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CSpawn_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<Poolee> _003C_003Et__builder;

			public SpawnPolicy _003C_003E4__this;

			public Pool pool;

			public Vector3 position;

			public Quaternion rotation;

			public Vector3? scale;

			public Transform parent;

			private UniTask<Poolee>.Awaiter _003C_003Eu__1;

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
		private struct _003CSpawnFromPool_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<Poolee> _003C_003Et__builder;

			public Pool pool;

			public Vector3 position;

			public Quaternion rotation;

			public Vector3? scale;

			public Transform parent;

			private UniTask<Poolee>.Awaiter _003C_003Eu__1;

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

		protected readonly List<Poolee> _poolees;

		private int _requestedSpawns;

		private readonly SpawnPolicyData _data;

		public SpawnPolicy(SpawnPolicyData data)
		{
		}

		[AsyncStateMachine(typeof(_003CSpawn_003Ed__4))]
		public virtual UniTask<Poolee> Spawn(Pool pool, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion), Vector3? scale = null, Transform parent = null)
		{
			return default(UniTask<Poolee>);
		}

		[AsyncStateMachine(typeof(_003CSpawnFromPool_003Ed__5))]
		protected virtual UniTask<Poolee> SpawnFromPool(Pool pool, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion), Vector3? scale = null, Transform parent = null)
		{
			return default(UniTask<Poolee>);
		}

		public void Clear(Poolee poolee)
		{
		}

		public virtual bool Despawn(Pool pool, Poolee poolee)
		{
			return false;
		}
	}
}
