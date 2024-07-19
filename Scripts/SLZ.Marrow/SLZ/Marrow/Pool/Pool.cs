using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using SLZ.Marrow.Warehouse;
using UnityEngine;

namespace SLZ.Marrow.Pool
{
	public class Pool
	{
		[StructLayout(3)]
		[CompilerGenerated]
		private struct _003CSpawn_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<Poolee> _003C_003Et__builder;

			public bool forceInstantiation;

			public Pool _003C_003E4__this;

			public Vector3 position;

			public Quaternion rotation;

			public Transform parent;

			public Vector3? scale;

			private UniTask<GameObject>.Awaiter _003C_003Eu__1;

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

		private readonly SpawnableCrate _crate;

		private bool _hasTemplateObject;

		private bool _isTemplateLoading;

		private GameObject _templateObject;

		private readonly Transform _parentTransform;

		private string _prefabName;

		private readonly List<Poolee> _objects;

		private readonly List<Poolee> _despawned;

		private readonly List<Poolee> _spawned;

		public Pool(SpawnableCrate sc, Transform rootTransform = null)
		{
		}

		[AsyncStateMachine(typeof(_003CSpawn_003Ed__10))]
		internal UniTask<Poolee> Spawn(Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion), Vector3? scale = null, Transform parent = null, bool forceInstantiation = false)
		{
			return default(UniTask<Poolee>);
		}

		public void Clear(Poolee poolee)
		{
		}

		public void Despawn(Poolee poolee, bool skipDisable = false)
		{
		}
	}
}
