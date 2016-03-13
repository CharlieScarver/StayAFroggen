namespace StayAFroggen.Core
{
    using System.Collections.Generic;
    using System.IO;
    using Enumerations;
    using GameObjects.Tiles;
    using GameObjects.Towers;
    using GameObjects.Units;
    using Interfaces;
    using Microsoft.Xna.Framework;

    public static class Engine
    {
        static Engine()
        {
            Units = new List<IUnit>();
            Tiles = new List<ITile>();
            Towers = new List<ITower>();
        }

        public static ICollection<IUnit> Units { get; }

        public static ICollection<ITile> Tiles { get; }

        public static ICollection<ITower> Towers { get; }

        public static void InitializeGameObjects()
        {
            //var tower = new ArrowTower(new Vector2(6 * 80, 1 * 80));
            //Towers.Add(tower);

            var princess = new Princess(new Vector2(0 * 80, 1 * 80));
            Units.Add(princess);
        }

        public static void InitializeLevel(string level)
        {
            using (StreamReader reader = new StreamReader("Content/Levels/1.txt"))
            {
                string line = "";
                int lineCount = 0;
                Vector2 position;
                ITile tile;

                while ((line = reader.ReadLine()) != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        switch (line[i])
                        {
                            // Player and Enemies
                            case '0':
                                position = new Vector2(i * 80, lineCount * 80);
                                tile = new Tile(position, TileType.Grass);
                                Tiles.Add(tile);
                                break;
                            case '1':
                            case '2':
                                position = new Vector2(i * 80, lineCount * 80);
                                tile = new Tile(position, TileType.Road);
                                Tiles.Add(tile);
                                break;
                            case 'p':
                                position = new Vector2(i * 80, lineCount * 80);
                                tile = new Tile(position, TileType.Grass);
                                Tiles.Add(tile);

                                IBuilder builder = new Builder(position);
                                Units.Add(builder);
                                break;

                        }
                    }
                    lineCount++;
                }
            }
        }
    }
}
