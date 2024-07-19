using System.Runtime.CompilerServices;

namespace SLZ.Marrow.Utilities
{
	public class RingBuffer<TStruct> where TStruct : struct
	{
		private TStruct[] _buffer;

		private int _size;

		private int _cursor;

		public int Length
		{
			[CompilerGenerated]
			get
			{
				return 0;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public RingBuffer(int size)
		{
		}

		public void Add(in TStruct tStruct)
		{
		}

		public void Clear()
		{
		}

		private int Mod(int x, int m)
		{
			return 0;
		}
	}
}
