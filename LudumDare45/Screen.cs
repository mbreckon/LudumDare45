using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LudumDare45.Windows
{
   public interface Screen
   {
      void Update(GameTime gameTime);
      void Draw(SpriteBatch spriteBatch);
   }
}
