using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace LudumDare45.Windows
{
   class Intro : Screen
   {
      readonly string[] introText = new string[]
      {
         "It is 1987 and a heinous crime has been committed against humanity...!",
         "The world's crime agencies have gathered together...",
         "but so far no-one has solved the case",
         "As one of the world's leading Detective Inspectors...",
         "Starting from nothing, you must gather the key evidence",
         "Only when all the pieces of evidence are brought together...",
         "will the picture become clear",
         "The evidence is scattered through nine regions filled with hazards...",
         "Who said the life of a detective was one of pipe and slippers?",
         "Get out there and solve the crime!",
         "Press space to start the game"
      };

      readonly IntroText display;
      readonly AnimationTimer fadeInOutTimer;
      readonly AnimationTimer changeLineTimer;
      readonly GameGraphics graphics;
      readonly ScreenController screenController;

      public Intro(GameGraphics graphics, ScreenSpace screenSpace, ScreenController screenController)
      {
         this.graphics = graphics;
         this.screenController = screenController;
         display = new IntroText(graphics, screenSpace, introText);
         fadeInOutTimer = new AnimationTimer(150, () => display.Animate());
         changeLineTimer = new AnimationTimer(3000, () => display.Transition());
         Thread.Sleep(200);
      }

      public void Draw(SpriteBatch spriteBatch)
      {
         spriteBatch.Draw(graphics.Background, Vector2.Zero, Color.White);
         spriteBatch.Draw(graphics.Title, new Vector2(250, 0), Color.White);
         display.Draw(spriteBatch);
      }

      public void Update(GameTime gameTime)
      {
         fadeInOutTimer.Update(gameTime.TotalGameTime);
         changeLineTimer.Update(gameTime.TotalGameTime);

         if (Keyboard.GetState().IsKeyDown(Keys.Space))
         {
            screenController.GoToProgress();
         }
      }
   }
}
