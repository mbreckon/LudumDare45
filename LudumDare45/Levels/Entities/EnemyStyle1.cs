using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LudumDare45.Windows
{
   class EnemyStyle1 : Entity
   {
      readonly ScreenSpace gameArea;
      readonly Texture2D texture;
      readonly Map map;

      private Vector2 velocity;
      private Vector2 position;

      public EnemyStyle1(Texture2D texture, Map map, int row, int column, ScreenSpace gameArea)
      {
         this.texture = texture;
         position = gameArea.GetTilePosition(row, column);
         velocity = new Vector2(-1.0f, 0);
         this.map = map;
         this.gameArea = gameArea;
      }

      public void Update(GameTime gameTime)
      {
         // This enemy moves simply backwards and forwards along
         // a platform until it can't move then it comes back the other way.
         var collisionChecks =
            map.CheckCollision(ProjectedBounds);

         if (velocity.X < 0 && collisionChecks.Left || !collisionChecks.BottomLeft)
         {
            velocity.X = 1.0f;
         }
         else if (velocity.X > 0 && collisionChecks.Right || !collisionChecks.BottomRight)
         {
            velocity.X = -1.0f;
         }

        position = position + velocity;
      }

      public bool Collides(Rectangle bounds) =>
         bounds.Intersects(Bounds);

      public void Draw(SpriteBatch spriteBatch)
      {
         spriteBatch.Draw(
            texture,
            gameArea.Position(
               (int)position.X,
               (int)position.Y
            ),
            Color.White
         );
      }

      private Rectangle ProjectedBounds =>
         new Rectangle(
            (int)(position.X + velocity.X),
            (int)(position.Y + velocity.Y),
            16, 16
         );

      private Rectangle Bounds =>
         new Rectangle(
            (int)(position.X),
            (int)(position.Y),
            16, 16
         );
   }
}
