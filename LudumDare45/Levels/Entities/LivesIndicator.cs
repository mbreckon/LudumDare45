using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LudumDare45.Windows
{
   class LivesIndicator : Entity
   {
      readonly GameState gameState;
      readonly ScreenSpace gameArea;
      readonly Texture2D life;

      public LivesIndicator(Texture2D life, ScreenSpace gameArea, GameState gameState)
      {
         this.gameState = gameState;
         this.gameArea = gameArea;
         this.life = life;
      }

      public void Update(GameTime _)
      {
      }

      public void Draw(SpriteBatch spriteBatch)
      {
         for (int i = 0; i < gameState.LivesRemaining; i++)
         {
            spriteBatch.Draw(
               life,
               gameArea.TilePosition(gameArea.LastColumn - i, -1),
               Color.White
            );
         }
      }
   }
}
