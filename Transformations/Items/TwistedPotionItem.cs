using Terraria.ID;
using Terraria.ModLoader;


namespace Transformations.Items {
	public class TwistedPotionItem : ModItem {
		public override void SetStaticDefaults() {
			this.DisplayName.SetDefault("TwistedPotionItem");
			this.Tooltip.SetDefault( "This is a basic modded sword." );
		}

		public override void SetDefaults() {
			this.item.damage = 50;
			this.item.melee = true;
			this.item.width = 40;
			this.item.height = 40;
			this.item.useTime = 20;
			this.item.useAnimation = 20;
			this.item.useStyle = 1;
			this.item.knockBack = 6;
			this.item.value = 10000;
			this.item.rare = 2;
			this.item.UseSound = SoundID.Item1;
			this.item.autoReuse = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe( mod );
			recipe.AddIngredient( ItemID.DirtBlock, 10 );
			recipe.AddTile( TileID.WorkBenches );
			recipe.SetResult( this );
			recipe.AddRecipe();
		}
	}
}