namespace StayAFroggen.Core
{
    using Enumerations;
    using Interfaces;
    using Microsoft.Xna.Framework;

    public static class Collision
    {
        public static bool CheckForCollisionWithWorldBounds(IUnit unit)
        {
            return false;
        }

        public static bool CheckForCollisionBetweenCollidables(ICollideable firstObj, ICollideable secondObj)
        {
            return firstObj.BoundingBox.Intersects(secondObj.BoundingBox);
        }

        public static bool CheckForCollisionBetweenCollidableAndRectangle(ICollideable firstObj, Rectangle rectangle)
        {
            return firstObj.BoundingBox.Intersects(rectangle);
        }

        // return true if the bounding box collides with a grass tile
        public static bool CheckForCollisionWithGrassTiles(Rectangle rect)
        {
            foreach (ITile tile in Engine.Tiles)
            {
                if (tile.Type == TileType.Road)
                {
                    continue;
                }
                if (CheckForCollisionBetweenCollidableAndRectangle(tile, rect))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
