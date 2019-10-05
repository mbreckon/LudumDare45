using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace LudumDare45.Windows
{
   class Player : Entity
   {
      readonly GameGraphics graphics;
      readonly ScreenSpace screenSpace;
      readonly Map level;
      readonly ScreenController screenController;
      private GameState gameState;

      readonly Vector2 respawnPosition;

      private Vector2 position;
      private Direction direction;

      const float Acceleration = 1.05f;
      const float TopSpeed = 6.0f;
      const float Deccelleration = 0.6f;
      const float MaxJumpHeight = 64;
      const float Gravity = 1.1f;
      const float TerminalVelocity = 8.0f;

      Vector2 velocity;

      private float targetJumpHeight = 0;
      private bool falling = false;
      private bool jumping = false;
      LevelState state;

      public Player(
         GameState gameState,
         ScreenController screenController,
         GameGraphics graphics,
         ScreenSpace gameArea,
         Map level,
         LevelState state,
         Vector2 respawnPosition)
      {
         this.screenController = screenController;
         this.graphics = graphics;
         this.screenSpace = gameArea;
         this.level = level;
         this.state = state;
         this.gameState = gameState;
         this.respawnPosition = respawnPosition;
         position = respawnPosition; 

         direction = Direction.Right;
      }

      public void Update(GameTime gameTime)
      {
         if (Math.Abs(velocity.X) < 0.1)
            velocity.X = 0.0f;

         if (Math.Abs(velocity.Y) < 0.1)
            velocity.Y = 0.0f;

         if (Keyboard.GetState().IsKeyDown(Keys.Space) && !jumping && !falling)
         {
            // Start a jump if one hasn't already been done
            jumping = true;

            // Y works negatively...
            targetJumpHeight = position.Y - MaxJumpHeight;
            velocity.Y = -4;

            // If close to top speed then enable jump speed boost...
            if (velocity.X > TopSpeed - 0.001)
               velocity.X *= 1.1f;
         }
         else if (jumping)
         {
           // velocity.Y = velocity.Y * JumpAcceleration;
            if (position.Y < targetJumpHeight)
            {
               jumping = false;
               falling = true;
               velocity.Y = 1f ;
            }
            else
            {
               velocity.Y = velocity.Y * Gravity;
            }
         }
         else if (Keyboard.GetState().IsKeyDown(Keys.Left) && !jumping && !falling)
         {
            if (velocity.X > 0)
               velocity.X = 0;

            if (Math.Abs(velocity.X) < 0.001)
               velocity.X = -1;

            velocity.X *= Acceleration;
            if (Math.Abs(velocity.X) > TopSpeed)
               velocity.X = Math.Sign(velocity.X) * TopSpeed;

            direction = Direction.Left;
         }
         else if (Keyboard.GetState().IsKeyDown(Keys.Right) && !jumping && !falling)
         {
            if (direction == Direction.Left)
               velocity.X = 0;

            if (Math.Abs(velocity.X) < 0.001)
               velocity.X = 1;

            velocity.X *= Acceleration;
            if (Math.Abs(velocity.X) > TopSpeed)
               velocity.X = Math.Sign(velocity.X) * TopSpeed;

            direction = Direction.Right;
         }
         else if (!jumping && !falling)
         {
            velocity.X = velocity.X * Deccelleration;
         }

         if (falling)
         {
            velocity.Y *= Gravity;

            if (velocity.Y > TerminalVelocity)
               velocity.Y = TerminalVelocity;
         }


         var collisionChecks =
            level.CheckCollision(ProjectedBounds);

         if (velocity.X < 0 && collisionChecks.Left ||
            velocity.X > 0 && collisionChecks.Right)
         {
            velocity.X = 0;
         }
         else
         {
            position.X = position.X + velocity.X;
         }

         if (collisionChecks.Top && !collisionChecks.Bottom)
         {
            jumping = false;
            falling = true;
            velocity.Y = 2.0f;
            position.Y = ((int)(position.Y + velocity.Y) / 16) * 16;
         }
         else if (!collisionChecks.Bottom)
         {
            if (!jumping && !falling)
            {
               velocity.X = velocity.X * 0.2f;

               falling = true;
               velocity.Y = 2.0f;
            }

            position.Y = position.Y + velocity.Y;
         }
         else
         {
            falling = false;
            jumping = false;
            velocity.Y = 0;
         }

         if (!screenSpace.IsOutOfBounds(Bounds))
         {
            gameState.LivesRemaining--;
            screenController.GoToRetryLevel();
            return;
         }

         if (state.Evidence.Collides(Bounds))
         {
            state.EvidenceRetrieved = true;
         }

         foreach (var enemy in state.Enemies)
         {
            if (enemy.Collides(Bounds))
            {
               gameState.LivesRemaining--;
               screenController.GoToRetryLevel();
               return;
            }
         }

         if (state.EvidenceRetrieved && state.Door.Collides(Bounds))
         {
            gameState.CurrentLevel++;
            screenController.GoToProgress();
            return;
         }
      }

      private Rectangle ProjectedBounds =>
         new Rectangle(
            (int)(position.X + velocity.X),
            (int)(position.Y + velocity.Y),
            16, 32
         );

      private Rectangle Bounds =>
         new Rectangle(
            (int)(position.X),
            (int)(position.Y),
            16, 32
         );

      public void Draw(SpriteBatch spriteBatch)
      {
         spriteBatch.Draw(
            direction == Direction.Right ? graphics.PlayerRight : graphics.PlayerLeft,
            screenSpace.Position((int)position.X, (int)position.Y),
            Color.White
         );

         //var collisionChecks =
         //   level.CheckCollision(ProjectedBounds);

         //spriteBatch.DrawString(
         //      font,
         //      $"{velocity.X}, {velocity.Y}",
         //      new Vector2(600, 0),
         //      Color.White
         //   );
         //spriteBatch.DrawString(
         //   font,
         //   $"{collisionChecks.Left}, " +
         //   $"{collisionChecks.Right}, " +
         //   $"{collisionChecks.Top}, " +
         //   $"{collisionChecks.Bottom}", 
         //   Vector2.Zero, 
         //   Color.White
         //);
      }
   }
}
