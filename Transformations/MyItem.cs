using System;
using Terraria;
using Terraria.ModLoader;


namespace Transformations {
	class TransformItem : GlobalItem {
		public override void PreUpdateVanitySet( Player player, string set ) {
			var myplayer = player.GetModPlayer<TransformsPlayer>();
			myplayer.UpdateSlotsOverrides();
		}
	}
}