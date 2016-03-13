namespace StayAFroggen.TextureLoading
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public static class TextureLoader
    {
        public static Texture2D TheOnePixel { get; private set; }
        public static Texture2D PrincessSheet { get; private set; }
        public static Texture2D Background { get; private set; }
        public static Texture2D GrassTile { get; private set; }
        public static Texture2D RoadTile { get; private set; }
        public static Texture2D ArrowTowerSprite { get; private set; }
        public static Texture2D ArrowTowerProjectile { get; private set; }
        public static Texture2D MagicTowerSheet { get; private set; }
        public static Texture2D MagicTowerProjectile { get; private set; }

        public static void Load(ContentManager content)
        {
            TheOnePixel = content.Load<Texture2D>("Sprites/TheOnePixel");
            Background = content.Load<Texture2D>("Background/test_background");

            PrincessSheet = content.Load<Texture2D>("Sprites/Princess_140x140");

            GrassTile = content.Load<Texture2D>("Tiles/grass_tile");
            RoadTile = content.Load<Texture2D>("Tiles/road_tile");

            ArrowTowerSprite = content.Load<Texture2D>("Sprites/ArrowTower_100x180");
            ArrowTowerProjectile = content.Load<Texture2D>("Sprites/Arrow_62x12");

            MagicTowerSheet = content.Load<Texture2D>("Sprites/MagicTower_100x230");
            MagicTowerProjectile = content.Load<Texture2D>("Sprites/magicProjectile_25x25");
        }
    }
}
