using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SLZ.Marrow.SaveData
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum FoveatedRenderingMode : sbyte
	{
		RDM = 0,
		VRS = 1
	}
}
