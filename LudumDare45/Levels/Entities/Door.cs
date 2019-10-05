using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LudumDare45.Windows
{
   class Door : Entity
   {
      readonly ScreenSpace screenSpace;
      readonly Texture2D texture;
      readonly int row;
      readonly int column;
      readonly LevelState levelState;

      private int currentAnimationFrame = 0;
      private TimeSpan? lastTime;

      public Door(Texture2D texture, int row, int column, ScreenSpace screenSpace, LevelState levelState)
      {
         this.texture = texture;
         this.row = row;
         this.column = column;
         this.screenSpace = screenSpace;
         this.levelState = levelState;
      }

      public bool Collides(Rectangle bounds) =>
         bounds.Intersects(Bounds);

      private Rectangle Bounds
      {
         get
         {
            // Smaller than door and centered to trigger when player more
            // obviously over the door...
            return new Rectangle(column * 16 + 16, row * 16 + 16, 1, 1);
         }
      }

      public void Update(GameTime gameTime)
      {
         if (!levelState.EvidenceRetrieved)
            return;

         if (!lastTime.HasValue)
         {
            lastTime = gameTime.TotalGameTime;
         }

         int elapsed = (int)(gameTime.TotalGameTime - lastTime.Value).TotalMilliseconds;

         if (elapsed > 200)
         {
            if (currentAnimationFrame < 11)
            {
               currentAnimationFrame++;
            }
            lastTime = gameTime.TotalGameTime;
         }
      }

      public void Draw(SpriteBatch spriteBatch)
      {
         spriteBatch.Draw(
            texture,
            screenSpace.TilePosition(column, row),
            new Rectangle(currentAnimationFrame * 32, 0, 32, 32),
            Color.White
         );
      }
   }
}
