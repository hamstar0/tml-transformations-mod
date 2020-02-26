using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Transformations.Buffs;


namespace Transformations {
	partial class TransformsPlayer : ModPlayer {
		private void ClearTransformation() {
			this.IsTransformed = false;

			this.HairColor = null;
			this.Hair = null;
			this.Face = null;
			this.Head = null;
			this.Body = null;
			this.Legs = null;
			this.HairDye = null;
			this.FaceArmorDye = null;
			this.HeadArmorDye = null;
			this.BodyArmorDye = null;
			this.LegsArmorDye = null;
			this.ForceEquip = null;
			this.PsychoKills = 0;

			this.MovementScale = 1f;
			this.JumpScale = 1f;

			if( this.OldHair != null ) {
				this.player.hair = this.OldHair ?? 0;
				this.player.hairColor = this.OldHairColor ?? Color.Black;
				this.player.hairDye = this.OldHairDye.HasValue
					? (byte)this.OldHairDye.Value
					: (byte)0;

				this.OldHair = null;
				this.OldHairColor = null;
				this.OldHairDye = null;
			} 
		}


		////////////////

		private void UpdateTransformBuffs() {
			bool isTransformed = false;

			for( int i = 0; i < this.player.buffType.Length; i++ ) {
				int buffType = this.player.buffType[i];

				if( buffType <= 0 || this.player.buffTime[i] <= 0 ) {
					continue;
				}

				ModBuff mybuff = ModContent.GetModBuff( buffType );
				if( mybuff == null || !( mybuff is TransformBuffBase ) ) {
					continue;
				}

				if( isTransformed ) {
					this.player.ClearBuff( buffType );

					if( buffType == ModContent.BuffType<PsychoModeBuff>() ) {
						this.PsychoKills = 0;
					}
				}

				isTransformed = true;
			}

			if( !isTransformed && this.IsTransformed ) {
				this.ClearTransformation();
			}
		}
	}
}