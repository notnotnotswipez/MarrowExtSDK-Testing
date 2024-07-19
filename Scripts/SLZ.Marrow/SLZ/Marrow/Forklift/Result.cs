using System.Runtime.CompilerServices;

namespace SLZ.Marrow.Forklift
{
	public readonly struct Result<TOk, TErr>
	{
		public TOk Ok
		{
			[CompilerGenerated]
			get
			{
				return default(TOk);
			}
		}

		public bool IsOk
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
		}

		public TErr Err
		{
			[CompilerGenerated]
			get
			{
				return default(TErr);
			}
		}

		public bool IsErr => false;

		public Result(TOk ok)
		{
		}

		public Result(TErr err)
		{
		}
	}
}
