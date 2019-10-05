using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LudumDare45.Windows
{
   public class Entities
   {
      readonly List<Entity> entities = new List<Entity>();

      public void Add(Entity entity) => entities.Add(entity);
      public void AddRange(IEnumerable<Entity> incoming) => entities.AddRange(incoming);

      public void Update(GameTime gameTime)
      {
         foreach (var entity in entities)
            entity.Update(gameTime);
      }

      public void Draw(SpriteBatch spriteBatch)
      {
         foreach (var entity in entities)
            entity.Draw(spriteBatch);
      }
   }
}
