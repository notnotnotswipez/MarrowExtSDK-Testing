using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace SLZ.Marrow.Combat
{
	public class VisualDamageController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CBleedOverTimer_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			private float _003Ct_003E5__2;

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
			public _003CBleedOverTimer_003Ed__25(int _003C_003E1__state)
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

		[NonSerialized]
		private const int MAX_HITS = 32;

		[NonSerialized]
		private int Count;

		private PosespaceImpactManager impactManager;

		[NonSerialized]
		private const int MAX_HITS_CUT = 8;

		[NonSerialized]
		private int Count_CUT;

		[NonSerialized]
		private List<Matrix4x4> CutPoint;

		[NonSerialized]
		private Matrix4x4[] CutPos;

		[Tooltip("Renderers to set hit variables for")]
		public Renderer[] Renderers;

		public float meshScaleFactor;

		public float hitScaleFactor;

		private int NumberOfHits;

		private int NumberOfCuts;

		private int NumberOfHitsID;

		private int EllipsoidPosArrayID;

		private int ElipsoidMatricesID;

		private int NumberOfElipsoidsID;

		public bool isLODVisible()
		{
			return false;
		}

		public void AddToHitArray(Matrix4x4 Matrix)
		{
		}

		public void AddToCutArray(Matrix4x4 Matrix)
		{
		}

		public void ResetHits()
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void InitializeBlock()
		{
		}

		public void UpdateArray()
		{
		}

		public void collectSkins()
		{
		}

		[IteratorStateMachine(typeof(_003CBleedOverTimer_003Ed__25))]
		private IEnumerator BleedOverTimer()
		{
			return null;
		}
	}
}
