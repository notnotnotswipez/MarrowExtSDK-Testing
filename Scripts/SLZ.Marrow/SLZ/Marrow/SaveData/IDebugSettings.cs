using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SLZ.Marrow.SaveData
{
	public interface IDebugSettings : IFixFieldsIfNeeded
	{
		[JsonExtensionData]
		IDictionary<string, JToken> AdditionalData { get; set; }

		[JsonProperty("developer_mode")]
		bool DeveloperMode { get; set; }
	}
}
