using Newtonsoft.Json;

namespace SLZ.Marrow.SaveData
{
	public interface ISettings : IFixFieldsIfNeeded
	{
		[JsonProperty("version")]
		int Version { get; set; }

		[JsonProperty("active_save_game")]
		string ActiveSave { get; set; }

		[JsonProperty("debug_settings")]
		IDebugSettings DebugSettings { get; set; }

		[JsonProperty("graphics_settings")]
		IGraphicsSettings GraphicsSettings { get; set; }

		[JsonProperty("spectator_settings")]
		ISpectatorSettings SpectatorSettings { get; set; }
	}
}
