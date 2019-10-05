using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;

namespace LudumDare45.Windows
{
   /// <summary>
   /// This is the main type for your game.
   /// </summary>
   public class Game1 : Game, ScreenController
   {
      GraphicsDeviceManager graphics;
      SpriteBatch spriteBatch;
      GameState gameState;

      GameGraphics gameGraphics;
      ScreenSpace screenSpace;

      Screen currentScreen;
      bool ctrlFDown = false;

      public Game1()
      {
         graphics = new GraphicsDeviceManager(this);
         graphics.PreferredBackBufferWidth = 800;
         graphics.PreferredBackBufferHeight = 600;
         TargetElapsedTime = TimeSpan.FromMilliseconds(16);
         Window.Title = "Ludum Dare 45 - DI";
         Content.RootDirectory = "Content";
         gameState = new GameState();
      }

      public void GoToIntro()
      {
         Thread.Sleep(500);
         gameState = new GameState();
         currentScreen = new Intro(gameGraphics, screenSpace, this);
      }

      public void GoToProgress()
      {
         Thread.Sleep(500);
         currentScreen = new Progress(screenSpace, gameGraphics, gameState, this);
      }

      public void GoToLevel(int level)
      {
         Thread.Sleep(500);
         switch (level)
         {
            case 1:
               currentScreen = new Level1(gameState, screenSpace, gameGraphics, this);
               break;

            case 2:
               currentScreen = new Level2(gameState, screenSpace, gameGraphics, this);
               break;

            case 3:
               currentScreen = new Level3(gameState, screenSpace, gameGraphics, this);
               break;

            case 4:
               currentScreen = new Level4(gameState, screenSpace, gameGraphics, this);
               break;

            case 5:
               currentScreen = new Level5(gameState, screenSpace, gameGraphics, this);
               break;

            case 6:
               currentScreen = new Level6(gameState, screenSpace, gameGraphics, this);
               break;

            case 7:
               currentScreen = new Level7(gameState, screenSpace, gameGraphics, this);
               break;

            case 8:
               currentScreen = new Level8(gameState, screenSpace, gameGraphics, this);
               break;

            case 9:
               currentScreen = new Level9(gameState, screenSpace, gameGraphics, this);
               break;

         }
      }

      public void GoToRetryLevel()
      {
         GoToLevel(gameState.CurrentLevel + 1);
      }

      /// <summary>
      /// Allows the game to perform any initialization it needs to before starting to run.
      /// This is where it can query for any required services and load any non-graphic
      /// related content.  Calling base.Initialize will enumerate through any components
      /// and initialize them as well.
      /// </summary>
      protected override void Initialize()
      {
         // TODO: Add your initialization logic here

         base.Initialize();
      }

      /// <summary>
      /// LoadContent will be called once per game and is the place to load
      /// all of your content.
      /// </summary>
      protected override void LoadContent()
      {
         gameGraphics = new GameGraphics(Content);
         spriteBatch = new SpriteBatch(GraphicsDevice);
         screenSpace = new ScreenSpace(GraphicsDevice);

         GoToIntro();
      }

      /// <summary>
      /// UnloadContent will be called once per game and is the place to unload
      /// game-specific content.
      /// </summary>
      protected override void UnloadContent()
      {
         // TODO: Unload any non ContentManager content here
      }

      /// <summary>
      /// Allows the game to run logic such as updating the world,
      /// checking for collisions, gathering input, and playing audio.
      /// </summary>
      /// <param name="gameTime">Provides a snapshot of timing values.</param>
      protected override void Update(GameTime gameTime)
      {
         if (Keyboard.GetState().IsKeyDown(Keys.F) && Keyboard.GetState().IsKeyDown(Keys.LeftControl))
         {
            ctrlFDown = true;
         }
         else if (ctrlFDown)
         {
            graphics.ToggleFullScreen();
            ctrlFDown = false;
         }

         if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

         currentScreen.Update(gameTime);
         base.Update(gameTime);
      }

      /// <summary>
      /// This is called when the game should draw itself.
      /// </summary>
      /// <param name="gameTime">Provides a snapshot of timing values.</param>
      protected override void Draw(GameTime gameTime)
      {
         GraphicsDevice.Clear(Color.FromNonPremultiplied(20, 20, 20, 255));
         spriteBatch.Begin(samplerState: SamplerState.PointClamp);

         currentScreen.Draw(spriteBatch);
         spriteBatch.End();

         base.Draw(gameTime);
      }
   }
}
