using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using SLZ.Marrow.SaveData;
using SLZ.Marrow.Warehouse;
using UnityEngine;

namespace SLZ.Marrow
{
	public abstract class MarrowLevelManager<TDataManager, TSave, TSettings, TPlayerSettings, TProgression, TUnlocks, TResumePoint> : MonoBehaviour where TDataManager : MarrowDataManager<TDataManager, TSave, TSettings, TPlayerSettings, TProgression, TUnlocks> where TSave : class, ISave<TPlayerSettings, TProgression, TUnlocks>, new() where TSettings : class, ISettings, new() where TPlayerSettings : class, IPlayerSettings, new() where TProgression : class, IProgression, new() where TUnlocks : class, IUnlocks, new() where TResumePoint : IResumePoint
	{
		protected bool _isLoadCalled;

		private static bool ShouldResumeProgressForThisLoad
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		[Tooltip("Name of the level in the save data")]
		public string LevelKey
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		[Tooltip("Mark level complete after level load")]
		public bool CompleteOnLoad
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		[Tooltip("Does this level save completion/progress/inventory?")]
		public SaveFeatures SaveFeatures
		{
			[CompilerGenerated]
			get
			{
				return default(SaveFeatures);
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		[Tooltip("Amount of time to wait after triggering level load before actually loading the level.")]
		protected double LevelLoadBufferTime
		{
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		[Tooltip("Crate reference to a fadeout VFX override, if any")]
		public SpawnableCrateReference FadeoutVFXOverride
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		[Tooltip("Crate references to levels to possibly load")]
		public LevelCrateReference[] LevelJumpList
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		protected TResumePoint[] ProgressionPoint
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

		public int Progress
		{
			[CompilerGenerated]
			get
			{
				return 0;
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		public bool IsResuming
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			protected set
			{
			}
		}

		private protected abstract TDataManager DataManager { get; }

		private protected abstract TSave ActiveSave { get; }

		public static void ThisLoadShouldResumeProgress()
		{
		}

		public virtual void Awake()
		{
		}

		public virtual void Start()
		{
		}

		private void TeleportToProgress()
		{
		}

		[PublicAPI]
		public void SetCompleted()
		{
		}

		[PublicAPI]
		public void SetProgress(int progress)
		{
		}

		[PublicAPI]
		public void JustSave()
		{
		}

		[PublicAPI]
		public void JustJumpToLevelAtIndex(int levelIndex = 0)
		{
		}

		[PublicAPI]
		private protected void JustJumpToLevelWithBarcode(Barcode levelBarcode)
		{
		}

		private protected virtual void PerformJump(LevelCrateReference nextLevel, LevelCrateReference loadScreenLevelOverride = null, SpawnableCrateReference fadeoutVfxOverride = null)
		{
		}

		private protected abstract void ResumeProgress();

		private protected abstract void OnProgressionRestore();

		private protected abstract void OnProgressionSave();
	}
}
