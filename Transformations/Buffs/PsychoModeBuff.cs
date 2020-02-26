using System;
using Terraria;
using Terraria.ID;


namespace Transformations.Buffs {
	class PsychoModeBuff : TransformBuffBase {
		public override void SetDefaults() {
			this.DisplayName.SetDefault( "Psycho Mode" );
			this.Description.SetDefault( "An obsessive madness overtakes you" );
			//Main.buffNoTimeDisplay[this.Type] = true;
			Main.buffNoSave[this.Type] = true;
		}


		public override void Update( Player player, ref int buffIndex ) {
			var myplayer = player.GetModPlayer<TransformsPlayer>();
			if( myplayer.IsTransformed ) { return; }

			myplayer.Hair = 15;
			myplayer.Head = ArmorIDs.Head.MimeMask;
			myplayer.Body = ArmorIDs.Body.AnglerVest;
			myplayer.Legs = ArmorIDs.Legs.FallenTuxedoPants;

			myplayer.HeadArmorDye = ItemID.SilverDye;
			myplayer.BodyArmorDye = ItemID.BlackDye;

			myplayer.ForceEquip = new Item();
			myplayer.ForceEquip.SetDefaults( ItemID.PsychoKnife );

			myplayer.MovementScale = 1.5f;
			myplayer.JumpScale = 1.5f;

			myplayer.IsTransformed = true;
		}
	}
}
