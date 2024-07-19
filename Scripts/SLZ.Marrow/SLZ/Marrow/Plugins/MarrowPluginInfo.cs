using System;
using System.Runtime.CompilerServices;

namespace SLZ.Marrow.Plugins
{
	internal class MarrowPluginInfo : IEquatable<MarrowPluginInfo>
	{
		public string Namespace
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public string Version
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public string QualifiedName => null;

		public MarrowPluginInfo(string @namespace, string name, string version)
		{
		}

		public override string ToString()
		{
			return null;
		}

		private bool System_002EIEquatable_003CSLZ_002EMarrow_002EPlugins_002EMarrowPluginInfo_003E_002EEquals(MarrowPluginInfo other)
		{
			return false;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public static bool operator ==(MarrowPluginInfo lhs, MarrowPluginInfo rhs)
		{
			return false;
		}

		public static bool operator !=(MarrowPluginInfo lhs, MarrowPluginInfo rhs)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

        public bool Equals(MarrowPluginInfo other)
        {
            throw new NotImplementedException();
        }
    }
}
