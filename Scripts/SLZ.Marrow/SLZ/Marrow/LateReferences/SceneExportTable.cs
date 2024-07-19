using UnityEngine;

namespace SLZ.Marrow.LateReferences
{
	[RequireComponent(typeof(LinkLateReferenceSubscriptions))]
	[ExecuteAlways]
	public class SceneExportTable : ExportTable
	{
		private protected override void Awake()
		{
		}

		private void Reset()
		{
		}

		private protected override void OnDestroy()
		{
		}
	}
}
