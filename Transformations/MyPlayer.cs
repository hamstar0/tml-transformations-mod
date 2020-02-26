using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using HamstarHelpers.Helpers.Debug;
using Transformations.Buffs;


namespace Transformations {
	/*class TransformsCustomPlayer : CustomPlayerData {
		public static TransformsPlayer Local { get; private set; } = null;



		////////////////

		protected override void OnEnter( object data ) {
			if( this.PlayerWho == Main.myPlayer ) {
				TransformsCustomPlayer.Local = TmlHelpers.SafelyGetModPlayer<TransformsPlayer>( this.Player );
			}
		}

		protected override object OnExit() {
			if( this.PlayerWho == Main.myPlayer ) {
				TransformsCustomPlayer.Local = null;
			}
			return base.OnExit();
		}
	}*/




	partial class TransformsPlayer : ModPlayer {
		internal Color? HairColor = null;

		internal int? Hair = null;
		internal sbyte? Face = null;
		internal int? Head = null;
		internal int? Body = null;
		internal int? Legs = null;

		internal int? HairDye = null;
		internal int? FaceArmorDye = null;
		internal int? HeadArmorDye = null;
		internal int? BodyArmorDye = null;
		internal int? LegsArmorDye = null;

		internal Item ForceEquip = null;

		////

		internal float MovementScale = 1f;
		internal float JumpScale = 1f;

		private int PsychoKills = 0;

		////


		private int? OldHair = null;
		private Color? OldHairColor = null;
		private int? OldHairDye = null;


		////////////////

		public bool IsTransformed { get; internal set; } = false;



		////////////////

		public override void PreUpdate() { }

		////

		public override void PreUpdateBuffs() {
			this.UpdateTransformBuffs();

			// This goes here because of the internal ordering of Player.Update hooks:
			this.UpdateDyeParticleOverrides();
		}

		////

		public override bool PreItemCheck() {
			if( this.ForceEquip == null ) {
				return base.PreItemCheck();
			}

			this.PreUpdateEquipOverride();

			return base.PreItemCheck();
		}

		public override void PostItemCheck() {
			if( this.ForceEquip == null ) {
				return;
			}

			this.PostUpdateEquipOverride();
		}

		////

		public override void PostUpdateRunSpeeds() {
			this.player.maxRunSpeed *= this.MovementScale;
			this.player.accRunSpeed = this.player.maxRunSpeed;
			this.player.moveSpeed *= this.MovementScale;

			Player.jumpHeight = (int)((float)Player.jumpHeight * this.JumpScale);
		}

		////

		public override void UpdateEquips( ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff ) {
			this.UpdateSlotsOverrides();
		}

		public override void FrameEffects() {
			this.UpdateSlotsOverrides();
		}


		////////////////

		public override void ModifyHitNPC( Item item, NPC target, ref int damage, ref float knockback, ref bool crit ) {
			damage += (int)( (float)damage * (float)this.PsychoKills * TransformsConfig.Instance.PsychoModeDamageScaleIncrease );
		}

		public override void OnHitNPC( Item item, NPC target, int damage, float knockback, bool crit ) {
			if( this.player.HasBuff(ModContent.BuffType<PsychoModeBuff>()) ) {
				if( target.life <= 0 ) {
					int atkPerc = (int)(TransformsConfig.Instance.PsychoModeDamageScaleIncrease * 100f);

					CombatText.NewText( target.getRect(), Color.Red, "+"+atkPerc+"% attack!" );
					this.PsychoKills++;
				}
			}
		}


		////////////////

		public override void ModifyDrawInfo( ref PlayerDrawInfo drawInfo ) {
			this.UpdateShaderOverrides( ref drawInfo );
		}

		public override void ModifyDrawLayers( List<PlayerLayer> layers ) {
			void addLayer( PlayerLayer layerAt, string name, Action<PlayerDrawInfo> action, int offset=0 ) {
				int idx = layers.FindIndex( l => l == layerAt );
				if( idx == -1 ) {
					return;
				}

				layers.Insert( idx + offset, new PlayerLayer( "Transformations", name, action ) );
			}

			if( this.ForceEquip != null ) {
				Item oldHeldItem = new Item();

				addLayer( PlayerLayer.HeldItem, "PreForceEquip", ( drawInfo ) => {
					oldHeldItem = this.player.HeldItem;
					this.player.inventory[this.player.selectedItem] = this.ForceEquip;
				} );
				addLayer( PlayerLayer.HeldItem, "PostForceEquip", ( drawInfo ) => {
					this.player.inventory[this.player.selectedItem] = oldHeldItem;
				}, 2 );
			}
		}
	}
}