using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LudumDare45.Windows
{
   class Evidence : Entity
   {
      readonly LevelState levelState;
      readonly ScreenSpace gameArea;
      readonly Texture2D texture;
      readonly int row;
      readonly int column;

      public Evidence(LevelState levelState, Texture2D texture, int row, int column, ScreenSpace gameArea)
      {
         this.levelState = levelState;
         this.texture = texture;
         this.row = row;
         this.column = column;
         this.gameArea = gameArea;
      }

      public void Update(GameTime _)
      {
      }

      public bool Collides(Rectangle bounds) =>
         bounds.Intersects(Bounds);

      public void Draw(SpriteBatch spriteBatch)
      {
         if (!levelState.EvidenceRetrieved)
         {
            spriteBatch.Draw(
               texture,
               gameArea.TilePosition(column, row),
               Color.White
            );
         }
      }

      private Rectangle Bounds =>
         new Rectangle(column * 16, row * 16, 16, 16);
   }
}
