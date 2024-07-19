using Newtonsoft.Json;

namespace SLZ.Marrow.SaveData
{
	public interface ISpectatorSettings : IFixFieldsIfNeeded
	{
		[JsonProperty("eye_output")]
		EyeTarget EyeOutput { get; set; }

		[JsonProperty("spectator_camera_mode")]
		SpectatorCameraMode SpectatorCameraMode { get; set; }

		[JsonProperty("resolution_x")]
		int ResolutionX { get; set; }

		[JsonProperty("resolution_y")]
		int ResolutionY { get; set; }
	}
}
