using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LudumDare45.Windows
{
   internal class ScreenSpace
   {
      const int TileSize = 16;

      public int Width => 40;
      public int Height => 28;
      public int FirstRow = 0;
      public int LastRow => Height - 1;
      public int FirstColumn => 0;
      public int LastColumn => Width - 1;
      public Vector2 ScreenCenter { get; }

      public bool IsOutOfBounds(Rectangle bounds) =>
         bounds.Left >= 16 && bounds.Right <= LastColumn * 16 &&
         bounds.Top >= 16 && bounds.Bottom <= LastRow * 16;

      readonly int areaXOffset;
      readonly int areaYOffset;

      public ScreenSpace(GraphicsDevice device)
      {
         var availableTileWidth = device.Viewport.Width / TileSize;
         var availableTileHeight = device.Viewport.Height / TileSize;

         areaXOffset = ((availableTileWidth - Width) / 2) * TileSize;
         areaYOffset = ((availableTileHeight - Height) / 2) * TileSize;

         ScreenCenter = 
            new Vector2(
               device.Viewport.Width / 2,
               device.Viewport.Height / 2
            );
      }

      public Vector2 GetTilePosition(int row, int column) =>
         new Vector2(column * TileSize, row * TileSize);

      public Vector2 Position(int x, int y) =>
         new Vector2(areaXOffset + x, areaYOffset + y);

      public Vector2 TilePosition(int tileX, int tileY) =>
         new Vector2(areaXOffset + tileX * TileSize, areaYOffset + tileY * TileSize);

      public Vector2 TileCentrePosition(int tileX, int tileY) =>
         new Vector2(
            (areaXOffset + tileX * TileSize) + (TileSize / 2),
            (areaYOffset + tileY * TileSize) + (TileSize / 2));
   }
}
