using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LudumDare45.Windows
{
   class Bomb : Entity
   {
      readonly ScreenSpace screenSpace;
      readonly GameGraphics graphics;
      readonly TileMap tileMap;
      int row;
      int column;
      int seconds;
      TimeSpan? startTime; 
      int secondsRemaining;

      public Bomb(GameGraphics graphics, int row, int column, int seconds, ScreenSpace screenSpace, TileMap tileMap)
      {
         this.graphics = graphics;
         this.row = row;
         this.column = column;
         this.seconds = seconds;
         this.screenSpace = screenSpace;
         this.tileMap = tileMap;
      }

      public void Update(GameTime gameTime)
      {
         if (!startTime.HasValue)
            startTime = gameTime.TotalGameTime;

         secondsRemaining = seconds - (int)(gameTime.TotalGameTime - startTime.Value).TotalSeconds;
         if (secondsRemaining < 0)
            secondsRemaining = 0;

         if (secondsRemaining == 0)
         {
            tileMap.ResetTile(row - 1, column - 1);
            tileMap.ResetTile(row - 1, column);
            tileMap.ResetTile(row - 1, column + 1);

            tileMap.ResetTile(row, column - 1);
            tileMap.ResetTile(row, column);
            tileMap.ResetTile(row, column + 1);

            tileMap.ResetTile(row + 1, column - 1);
            tileMap.ResetTile(row + 1, column);
            tileMap.ResetTile(row + 1, column + 1);
         }
      }

      public void Draw(SpriteBatch spriteBatch)
      {
         if (secondsRemaining != 0)
         {
            spriteBatch.Draw(
               graphics.Bomb,
               screenSpace.TilePosition(column, row),
               Color.White
            );

            if (secondsRemaining < 6)
            {
               var text = $"{secondsRemaining}";
               var fontOrigin = graphics.MainFont.MeasureString(text) / 2;

               spriteBatch.DrawString(
                  graphics.MainFont,
                  text,
                  screenSpace.TileCentrePosition(column, row - 1),
                  Color.White, 0, fontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            }
         }
      }
   }
}
