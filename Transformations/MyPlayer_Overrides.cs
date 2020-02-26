using System;
using Terraria;
using Terraria.ModLoader;
using HamstarHelpers.Helpers.Misc;
using HamstarHelpers.Helpers.Players;


namespace Transformations {
	partial class TransformsPlayer : ModPlayer {
		private Item _OldHeldItem;



		////////////////

		private void PreUpdateEquipOverride() {
			this._OldHeldItem = this.player.HeldItem;

			if( Main.mouseItem != null && !Main.mouseItem.IsAir ) {
				PlayerItemHelpers.DropInventoryItem( this.player, this.player.selectedItem );
			}

			this.player.inventory[this.player.selectedItem] = this.ForceEquip;
		}

		private void PostUpdateEquipOverride() {
			this.player.inventory[this.player.selectedItem] = this._OldHeldItem;
		}


		////////////////

		internal void UpdateSlotsOverrides() {
			if( this.OldHair == null ) {
				this.OldHair = this.player.hair;
				this.OldHairColor = this.player.hairColor;
				this.OldHairDye = this.player.hairDye;
			}

			this.player.hair = this.Hair ?? this.player.hair;
			this.player.hairColor = this.HairColor ?? this.player.hairColor;

			this.player.face = this.Face ?? this.player.face;
			this.player.head = this.Head ?? this.player.head;
			this.player.body = this.Body ?? this.player.body;
			this.player.legs = this.Legs ?? this.player.legs;
		}

		private void UpdateShaderOverrides( ref PlayerDrawInfo drawInfo ) {
			if( this.HairDye.HasValue ) {
				drawInfo.hairShader = ShaderHelpers.GetShaderIdByDyeItemType( this.HairDye.Value );
			}
			if( this.FaceArmorDye.HasValue ) {
				drawInfo.faceShader = ShaderHelpers.GetShaderIdByDyeItemType( this.FaceArmorDye.Value );
			}
			if( this.HeadArmorDye.HasValue ) {
				drawInfo.headArmorShader = ShaderHelpers.GetShaderIdByDyeItemType( this.HeadArmorDye.Value );
			}
			if( this.BodyArmorDye.HasValue ) {
				drawInfo.bodyArmorShader = ShaderHelpers.GetShaderIdByDyeItemType( this.BodyArmorDye.Value );
			}
			if( this.LegsArmorDye.HasValue ) {
				drawInfo.legArmorShader = ShaderHelpers.GetShaderIdByDyeItemType( this.LegsArmorDye.Value );
			}
		}

		private void UpdateDyeParticleOverrides() {
			if( this.FaceArmorDye.HasValue ) {
				this.player.cFace = ShaderHelpers.GetShaderIdByDyeItemType( this.FaceArmorDye.Value );
			}
			if( this.HeadArmorDye.HasValue ) {
				this.player.cHead = ShaderHelpers.GetShaderIdByDyeItemType( this.HeadArmorDye.Value );
			}
			if( this.BodyArmorDye.HasValue ) {
				this.player.cBody = ShaderHelpers.GetShaderIdByDyeItemType( this.BodyArmorDye.Value );
			}
			if( this.LegsArmorDye.HasValue ) {
				this.player.cLegs = ShaderHelpers.GetShaderIdByDyeItemType( this.LegsArmorDye.Value );
			}
		}
	}
}
