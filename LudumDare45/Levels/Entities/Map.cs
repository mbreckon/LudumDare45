using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LudumDare45.Windows
{
   class Map : Entity
   {
      readonly ScreenSpace gameArea;
      readonly TileMap tileMap;
      readonly GameGraphics graphics;

      public Map(
         ScreenSpace gameArea,
         TileMap tileMap,
         GameGraphics graphics)
      {
         this.gameArea = gameArea;
         this.tileMap = tileMap;
         this.graphics = graphics;
      }

      public void Update(GameTime _)
      {
      }

      public Vector2 Clip(Vector2 position)
      {
         var nx =
            position.X > 16
               ? position.X <= (gameArea.LastColumn - 1) * 16
                  ? position.X
                  : (gameArea.LastColumn - 1) * 16
               : 16;

         var ny =
            position.Y > 16
               ? position.Y < gameArea.LastRow * 16
                  ? position.Y
                  : gameArea.LastRow * 16
               : 16;

         return new Vector2(nx, ny);
      }

      public void Draw(SpriteBatch spriteBatch)
      {
         for (int column = 0; column < gameArea.Width; column++)
         {
            for (int row = 0; row < gameArea.Height; row++)
            {
               var sprite = tileMap.GetSprite(row, column);
               if (sprite.HasValue)
               {
                  spriteBatch.Draw(
                     graphics.Tile(sprite.Value),
                     gameArea.TilePosition(column, row),
                     Color.White
                  );
               }
            }
         }
      }

      public Collision CheckCollision(Rectangle bounds)
      {
         return new Collision(
            tileMap.GetCollision(bounds.Left - 1, bounds.Top + 1) ||
               tileMap.GetCollision(bounds.Left - 1, bounds.Bottom - 1) ||
               tileMap.GetCollision(bounds.Left - 1, (bounds.Bottom + bounds.Top) / 2),
            tileMap.GetCollision(bounds.Right + 1, bounds.Top + 1) ||
               tileMap.GetCollision(bounds.Right + 1, bounds.Bottom - 1) ||
               tileMap.GetCollision(bounds.Right + 1, (bounds.Bottom + bounds.Top) / 2),
            tileMap.GetCollision(bounds.Left + 1, bounds.Top - 1) ||
               tileMap.GetCollision(bounds.Right + 1, bounds.Top - 1),
            tileMap.GetCollision(bounds.Left + 1, bounds.Bottom + 1) ||
               tileMap.GetCollision(bounds.Right + 1, bounds.Bottom + 1),
            tileMap.GetCollision(bounds.Left - 1, bounds.Bottom + 1),
            tileMap.GetCollision(bounds.Right + 1, bounds.Bottom + 1)
         );
      }
   }
}
