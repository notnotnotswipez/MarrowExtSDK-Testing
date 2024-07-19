using Newtonsoft.Json;

namespace SLZ.Marrow.SaveData
{
	public interface IGraphicsSettings : IFixFieldsIfNeeded
	{
		[JsonProperty("graphics_quality")]
		GraphicsQuality GraphicsQuality { get; set; }

		[JsonProperty("adaptive_resolution")]
		bool AdaptiveResolution { get; set; }

		[JsonProperty("texture_resolution")]
		int TextureResolution { get; set; }

		[JsonProperty("msaa")]
		int MSAA { get; set; }

		[JsonProperty("smaa")]
		SettingLevel SMAA { get; set; }

		[JsonProperty("hbao")]
		SettingLevel HBAO { get; set; }

		[JsonProperty("ssr")]
		SettingLevel SSR { get; set; }

		[JsonProperty("shadow_cascade")]
		int ShadowCascade { get; set; }

		[JsonProperty("render_scale")]
		int RenderScale { get; set; }

		[JsonProperty("shadows")]
		SettingLevel Shadows { get; set; }

		[JsonProperty("bloom")]
		SettingLevel Bloom { get; set; }

		[JsonProperty("volumetrics")]
		SettingLevel Volumetrics { get; set; }

		[JsonProperty("LOD_Bias")]
		int LODBias { get; set; }

		[JsonProperty("FoveatedRenderingMode")]
		FoveatedRenderingMode FoveatedRenderingModeSetting { get; set; }

		[JsonProperty("FoveatedPreset")]
		FoveatedPresets FoveatedPresetSetting { get; set; }

		[JsonProperty("FoveatedOuterRadius")]
		int FoveatedOuterRadius { get; set; }

		[JsonProperty("FoveatedInnerRatio")]
		int FoveatedInnerRatio { get; set; }

		[JsonProperty("FoveatedSamplingAnisotropy")]
		int FoveatedSamplingAnisotropy { get; set; }

		[JsonProperty("EnableFoveatedRenderingMenu")]
		bool EnableFoveatedRenderingMenu { get; set; }
	}
}
