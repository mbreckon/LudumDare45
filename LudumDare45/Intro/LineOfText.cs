using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LudumDare45.Windows
{
   class LineOfText
   {
      readonly string text;
      readonly GameGraphics graphics;
      readonly Vector2 textCentre;
      Vector2 textPosition;

      private int currentColour = 0;

      readonly Color[] colourCycle = new Color[]
      {
         Color.Black,
         Color.DimGray,
         Color.AntiqueWhite,
         Color.AliceBlue,
         Color.White,
         Color.White,
         Color.White,
         Color.White,
         Color.White,
         Color.White,
         Color.AntiqueWhite,
      };

      public LineOfText(
         GameGraphics graphics,
         ScreenSpace screenSpace,
         string text)
      {
         this.graphics = graphics;
         this.text = text;

         textCentre = graphics.MainFont.MeasureString(text) / 2;
         textPosition = screenSpace.ScreenCenter;
         CurrentFade = Fade.Invisible;
      }

      public void Animate()
      {
         if (CurrentFade == Fade.FadeIn)
         {
            if (currentColour < colourCycle.Length - 1)
               currentColour++;

            if (currentColour == colourCycle.Length - 1)
            {
               CurrentFade = Fade.FadeOut;
            }
         }
         else if (CurrentFade == Fade.FadeOut)
         {
            if (currentColour >= 0)
               currentColour--;
         }
      }

      public void MoveUp(int distance)
      {
         textPosition.Y -= distance;
      }

      public Fade CurrentFade { get; set; }

      public void Draw(SpriteBatch spriteBatch)
      {
         if (currentColour >= 0 && CurrentFade != Fade.Invisible)
         {
            spriteBatch.DrawString(
               graphics.MainFont,
               text,
               textPosition,
               colourCycle[currentColour],
               0, textCentre, 1.0f, SpriteEffects.None, 0.5f);
         }
      }
   }
}
