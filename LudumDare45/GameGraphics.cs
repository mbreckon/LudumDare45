using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LudumDare45.Windows
{
   class GameGraphics
   {
      readonly List<Texture2D> tileSprites = new List<Texture2D>();
      readonly List<string> tileSpriteNames =
         new List<string>()
         {
            "ground1",
            "ground2"
         };

      readonly List<Texture2D> levelSprites = new List<Texture2D>();
      readonly List<string> levelSpriteNames =
         new List<string>()
         {
            "LevelSquare-Beginning",
            "LevelSquare-Level1",
            "LevelSquare-Level2",
            "LevelSquare-Level3",
            "LevelSquare-Level4",
            "LevelSquare-Level5",
            "LevelSquare-Level6",
            "LevelSquare-Level7",
            "LevelSquare-Level8",
            "LevelSquare-Level9",
            "LevelSquare-Complete"
         };

      public GameGraphics(ContentManager content)
      {
         MainFont = content.Load<SpriteFont>("Intro");
         Door = content.Load<Texture2D>("door");
         Life = content.Load<Texture2D>("life");
         Bomb = content.Load<Texture2D>("bomb");
         Enemy = content.Load<Texture2D>("enemy1");
         Evidence = content.Load<Texture2D>("evidence1");
         PlayerLeft = content.Load<Texture2D>("player-left");
         PlayerRight = content.Load<Texture2D>("player-right");
         Background = content.Load<Texture2D>("background");
         Title = content.Load<Texture2D>("title");

         foreach (var tileSpriteName in tileSpriteNames)
         {
            tileSprites.Add(
               content.Load<Texture2D>(tileSpriteName)
            );
         }

         foreach (var levelSpriteName in levelSpriteNames)
         {
            levelSprites.Add(
               content.Load<Texture2D>(levelSpriteName)
            );
         }
      }

      public Texture2D Level(int id) => levelSprites[id];
      public Texture2D Tile(int id) => tileSprites[id];
      public Texture2D Door { get; }
      public Texture2D Life { get; }
      public Texture2D Bomb { get; }
      public Texture2D Enemy { get; }
      public Texture2D Evidence { get; }
      public Texture2D PlayerLeft { get; }
      public Texture2D PlayerRight { get; }
      public Texture2D Background { get; }
      public Texture2D Title { get; }

      public SpriteFont MainFont { get; }
   }
}
