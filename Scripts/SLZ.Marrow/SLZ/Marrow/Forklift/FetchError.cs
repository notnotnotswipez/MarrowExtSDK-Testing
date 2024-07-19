using System;
using System.Runtime.CompilerServices;

namespace SLZ.Marrow.Forklift
{
	public readonly struct FetchError
	{
		public Exception Exception
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public int ErrorCode
		{
			[CompilerGenerated]
			get
			{
				return 0;
			}
		}

		public string ErrorDescription
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public int Index
		{
			[CompilerGenerated]
			get
			{
				return 0;
			}
		}

		public FetchError(Exception exception, int index = -1)
		{
		}

		public FetchError(int errorCode, string errorDescription, int index = -1)
		{
		}
	}
}
