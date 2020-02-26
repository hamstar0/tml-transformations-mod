using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;
using HamstarHelpers.Classes.UI.ModConfig;
using HamstarHelpers.Services.Configs;


namespace Transformations {
	class MyFloatInputElement : FloatInputElement { }




	class TransformsConfig : StackableModConfig {
		public static TransformsConfig Instance => ModConfigStack.GetMergedConfigs<TransformsConfig>();



		////////////////

		public override ConfigScope Mode => ConfigScope.ServerSide;

		////

		[DefaultValue( true )]
		public bool PsychoPotionEnable { get; set; } = true;

		[Range(0f, 1f)]
		[DefaultValue( 0.05f )]
		public float PsychoModeDamageScaleIncrease { get; set; } = 0.05f;
	}
}
