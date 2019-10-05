using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace LudumDare45.Windows
{
   internal class Level : Screen
   {
      protected readonly Entities entities = new Entities();
      protected readonly LevelState levelState = new LevelState();

      protected readonly GameGraphics graphics;
      protected readonly ScreenController screenController;
      protected readonly GameState gameState;
      protected readonly ScreenSpace screenSpace;

      private string levelName;

      protected Level(
         string levelName,
         GameGraphics graphics,
         ScreenController screenController,
         GameState gameState,
         ScreenSpace screenSpace
      )
      {
         this.levelName = levelName;
         this.graphics = graphics;
         this.screenController = screenController;
         this.gameState = gameState;
         this.screenSpace = screenSpace;
      }

      public void Update(GameTime gameTime)
      {
         if (gameState.LivesRemaining > 0)
         {
            entities.Update(gameTime);
         }
         else if (gameState.LivesRemaining == 0)
         {
            Thread.Sleep(500);
            gameState.LivesRemaining--;
         }
         else
         {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
               screenController.GoToIntro();
            }
         }
      }

      public void Draw(SpriteBatch spriteBatch)
      {
         spriteBatch.Draw(graphics.Background, Vector2.Zero, Color.White);
         spriteBatch.DrawString(
            graphics.MainFont,
            levelName,
            new Vector2(90, 32),
            Color.White
         );

         entities.Draw(spriteBatch);

         if (gameState.LivesRemaining <= 0)
         {
            var text = "Game Over";
            var fontOrigin = graphics.MainFont.MeasureString(text) / 2;

            spriteBatch.DrawString(
               graphics.MainFont,
               text,
               screenSpace.ScreenCenter,
               Color.White,
               0,
               fontOrigin, 1.0f, SpriteEffects.None, 0.5f
            );
         }
      }
   }
}
