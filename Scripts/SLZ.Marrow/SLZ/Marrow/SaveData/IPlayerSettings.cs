using Newtonsoft.Json;

namespace SLZ.Marrow.SaveData
{
	public interface IPlayerSettings
	{
		[JsonProperty("modified")]
		string Modified { get; set; }

		[JsonProperty("haptics")]
		float Haptics { get; set; }

		[JsonProperty("right_handed")]
		bool RightHanded { get; set; }

		[JsonProperty("locomotion_curve")]
		int LocomotionCurve { get; set; }

		[JsonProperty("locomotion_degrees_per_snap")]
		float LocomotionDegreesPerSnap { get; set; }

		[JsonProperty("locomotion_direction")]
		int LocomotionDirection { get; set; }

		[JsonProperty("locomotion_snap_degrees_per_frame")]
		int LocomotionSnapDegreesPerFrame { get; set; }

		[JsonProperty("player_height")]
		float PlayerHeight { get; set; }

		[JsonProperty("chest_circumference")]
		float ChestCircumference { get; set; }

		[JsonProperty("underbust_circumference")]
		float UnderbustCircumference { get; set; }

		[JsonProperty("waist_circumference")]
		float WaistCircumference { get; set; }

		[JsonProperty("hips_circumference")]
		float HipsCircumference { get; set; }

		[JsonProperty("wingspan_length")]
		float WingspanLength { get; set; }

		[JsonProperty("inseam_length")]
		float InseamLength { get; set; }

		[JsonProperty("offset_sitting")]
		float OffsetSitting { get; set; }

		[JsonProperty("offset_floor")]
		float OffsetFloor { get; set; }

		[JsonProperty("standing")]
		bool Standing { get; set; }

		[JsonProperty("belt_location_right")]
		bool BeltLocationRight { get; set; }

		[JsonProperty("volume_global")]
		float VolumeGlobal { get; set; }

		[JsonProperty("volume_music")]
		float VolumeMusic { get; set; }

		[JsonProperty("volume_sfx")]
		float VolumeSFX { get; set; }
	}
}
