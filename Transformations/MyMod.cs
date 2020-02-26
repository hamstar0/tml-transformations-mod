using Terraria;
using Terraria.ModLoader;
using Transformations.Buffs;
using HamstarHelpers.Services.Debug.CustomHotkeys;


namespace Transformations {
	public partial class TransformsMod : Mod {
		public static TransformsMod Instance { get; private set; }


		////////////////

		public static string GithubUserName => "hamstar0";
		public static string GithubProjectName => "tml-transformations-mod";



		////////////////

		public TransformsMod() {
			TransformsMod.Instance = this;
		}

		public override void Unload() {
			TransformsMod.Instance = null;
		}

		public override void PostSetupContent() {
			CustomHotkeys.BindActionToKey1( "Transformations: Test Psycho Buff", () => {
				Main.LocalPlayer.AddBuff( ModContent.BuffType<PsychoModeBuff>(), 60 * 60 );
			} );
		}
	}
}