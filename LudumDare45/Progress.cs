using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace LudumDare45.Windows
{
   class Progress : Screen
   {
      readonly GameGraphics graphics;
      readonly Vector2 position;
      readonly Vector2 levelsCompletePosition;
      readonly Vector2 nextLevelPosition;
      readonly ScreenController screenController;

      private Vector2 currentDetectivePosition;
      private GameState gameState;
      private AnimationTimer timer;
      private int currentState;

      public Progress(
         ScreenSpace screenSpace,
         GameGraphics graphics,
         GameState gameState,
         ScreenController screenController)
      {
         this.graphics = graphics;
         this.gameState = gameState;
         this.screenController = screenController;
         position = screenSpace.ScreenCenter - new Vector2(200, 200);
         levelsCompletePosition = screenSpace.ScreenCenter - new Vector2(100, 230);
         nextLevelPosition = screenSpace.ScreenCenter + new Vector2(-100, 210);
         currentDetectivePosition = new Vector2(0, 550);
      }

      public void Draw(SpriteBatch spriteBatch)
      {
         spriteBatch.Draw(graphics.Background, Vector2.Zero, Color.White);

         spriteBatch.Draw(graphics.Level(gameState.CurrentLevel), position, Color.White);

         spriteBatch.DrawString(
            graphics.MainFont,
            $"Levels completed: {gameState.CurrentLevel}",
            levelsCompletePosition,
            Color.White
         );

         if (gameState.CurrentLevel < 9)
         {
            spriteBatch.DrawString(
               graphics.MainFont,
               $"Go! Level {gameState.CurrentLevel + 1}...",
               nextLevelPosition,
               Color.White
            );
         }
         else
         {
            if (currentState == 0)
            {
               var text = $"You've gathered all the evidence...who is the culprit?";
               var fontOrigin = graphics.MainFont.MeasureString(text) / 2;

               spriteBatch.DrawString(
                  graphics.MainFont,
                  text,
                  nextLevelPosition,
                  Color.White, 0, fontOrigin, 1.0f, SpriteEffects.None, 0.5f);

            }
            if (currentState > 1)
            {
               spriteBatch.DrawString(
                  graphics.MainFont,
                  $"Never gonna give you up!",
                  nextLevelPosition,
                  Color.White
               );
            }
         }

         spriteBatch.Draw(graphics.PlayerRight, currentDetectivePosition, Color.White);
      }

      public void Update(GameTime gameTime)
      {
         if (gameState.CurrentLevel < 9)
         {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) || currentDetectivePosition.X > 800)
               screenController.GoToLevel(gameState.CurrentLevel + 1);

            currentDetectivePosition.X += 2;
         }
         else
         {
            currentDetectivePosition = new Vector2(400, 550);
            if (timer == null)
               timer = new AnimationTimer(4000, () => currentState++);
            else
               timer.Update(gameTime.TotalGameTime);
         }

         if (currentState == 1)
         {
            if (gameState.CurrentLevel < 10)
               gameState.CurrentLevel++;
         }

         if (currentState > 3 && currentState < 5)
         {
            var sh = new Process();
            sh.StartInfo.UseShellExecute = true;
            sh.StartInfo.FileName = "https://www.youtube.com/watch?time_continue=2&v=dQw4w9WgXcQ";
            sh.Start();
            timer = null;
            currentState = 10;
         }

      }
   }
}
