using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LudumDare45.Windows
{
   public interface Entity
   {
      void Update(GameTime time);
      void Draw(SpriteBatch spriteBatch);
   }
}
