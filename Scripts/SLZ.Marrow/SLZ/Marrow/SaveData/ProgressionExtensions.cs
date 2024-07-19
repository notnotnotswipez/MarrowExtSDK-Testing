namespace SLZ.Marrow.SaveData
{
	public static class ProgressionExtensions
	{
		public const string PROGRESS = "SLZ.Marrow.progress";

		public const string COMPLETED = "SLZ.Marrow.completed";

		public static bool TrySetLevelCompleted(this IProgression progression, string levelKey, bool completed)
		{
			return false;
		}

		public static void SetCompleted(this IProgression progression, string levelKey, bool completed)
		{
		}

		public static bool TrySetLevelProgress(this IProgression progression, string levelKey, int progress)
		{
			return false;
		}

		public static bool TryGetLevelCompleted(this IProgression progression, string levelKey, out bool completed)
		{
			completed = default(bool);
			return false;
		}

		public static bool IsCompleted(this IProgression progression, string levelKey)
		{
			return false;
		}

		public static bool TryGetLevelProgress(this IProgression progression, string levelKey, out int progress)
		{
			progress = default(int);
			return false;
		}
	}
}
