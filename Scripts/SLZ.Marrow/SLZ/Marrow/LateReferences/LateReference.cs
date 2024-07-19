using System;
using System.Runtime.CompilerServices;
using UltEvents;
using UnityEngine;

namespace SLZ.Marrow.LateReferences
{
	public abstract class LateReference : ISerializationCallbackReceiver
	{
		public string StaticType
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private protected set
			{
			}
		}

		public string DynamicType
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private protected set
			{
			}
		}

		public string UniqueId
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			protected internal set
			{
			}
		}

		public bool ReferenceLinked
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			private protected set
			{
			}
		}

		public abstract UnityEngine.Object InternalObject { get; set; }

		public abstract void OnBeforeSerialize();

		public abstract void OnAfterDeserialize();

		public abstract void LateReferenceDidLink(ExportTable exportTable, UnityEngine.Object obj);

		public abstract Type GetStaticType();
	}
	[Serializable]
	public class LateReference<T> : LateReference where T : UnityEngine.Object
	{
		public T Object
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public UltEvent<ExportTable, LateReference> OnLateReferenceLinked
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			protected internal set
			{
			}
		}

		[Obsolete("For internal use. Use Object instead")]
		public override UnityEngine.Object InternalObject
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void OnBeforeSerialize()
		{
		}

		public override void OnAfterDeserialize()
		{
		}

		public override void LateReferenceDidLink(ExportTable exportTable, UnityEngine.Object obj)
		{
		}

		public override Type GetStaticType()
		{
			return null;
		}
	}
}
