using Terraria;
using Terraria.ModLoader;


namespace Transformations {
	public partial class TransformsMod : Mod {
		public override void PreUpdateEntities() {
			var myplayer = Main.LocalPlayer.GetModPlayer<TransformsPlayer>();
			myplayer.UpdateSlotsOverrides();
		}
	}
}