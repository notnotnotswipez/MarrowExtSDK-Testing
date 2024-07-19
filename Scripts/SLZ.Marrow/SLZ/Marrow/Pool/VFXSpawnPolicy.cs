using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Data;
using UnityEngine;

namespace SLZ.Marrow.Pool
{
	public class VFXSpawnPolicy : SpawnPolicy
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CSpawn_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<Poolee> _003C_003Et__builder;

			public VFXSpawnPolicy _003C_003E4__this;

			public Vector3 position;

			public Pool pool;

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

		private double _timeOfLastSpawn;

		private Poolee _lastSpawn;

		private readonly VFXSpawnPolicyData _data;

		public VFXSpawnPolicy(VFXSpawnPolicyData data)
			: base(null)
		{
		}

		[AsyncStateMachine(typeof(_003CSpawn_003Ed__4))]
		public override UniTask<Poolee> Spawn(Pool pool, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion), Vector3? scale = null, Transform parent = null)
		{
			return default(UniTask<Poolee>);
		}
	}
}
