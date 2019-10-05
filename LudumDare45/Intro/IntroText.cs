using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LudumDare45.Windows
{
   class IntroText
   {
      readonly List<LineOfText> lines = new List<LineOfText>();

      private int currentLine = 0;

      public IntroText(
         GameGraphics graphics,
         ScreenSpace screenSpace,
         string[] text)
      {
         foreach (var line in text)
            lines.Add(new LineOfText(graphics, screenSpace, line));
      }

      public void Animate()
      {
         foreach (var line in lines)
            line.Animate();
      }

      public void Transition()
      {
         lines[currentLine].CurrentFade = Fade.FadeIn;
         if (currentLine < lines.Count - 1)
            currentLine++;
      }

      public void Draw(SpriteBatch spriteBatch)
      {
         foreach (var line in lines)
            line.Draw(spriteBatch);
      }
   }
}
