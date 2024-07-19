using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Palmmedia.ReportGenerator.Core.Logging;

namespace SLZ.Marrow.Utilities
{
	public static class MarrowLogger
	{
		private static ILoggerFactory _loggerFactory
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		[PublicAPI]
		public static ILogger Logger
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		static MarrowLogger()
		{
		}

		[PublicAPI]
		public static ILogger GetLogger(string categoryName)
		{
			return null;
		}
	}
}
