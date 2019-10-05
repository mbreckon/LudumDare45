namespace LudumDare45.Windows
{

   internal class Level7 : Level
   {
      readonly TileMap tileMap = new TileMap(new string[]
      {
         "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB",
         "B                                      B",
         "B                                      B",
         "B                 BBBBBBBBB            B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B         BBBBBBBBBBBBBBBBB            B",
         "B                                  BBBBB",
         "B                                      B",
         "B   BBB                    BBB         B",
         "B         BBB                          B",
         "B                                      B",
         "B         B                            B",
         "B             B                        B",
         "B                  BB                  B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                           BBBBBBB    B",
         "B                                      B",
         "B                     BB               B",
         "B                                      B",
         "B          BBBB                        B",
         "B                        BBBBBBBBBBBB  B",
         "B    BBBB                              B",
         "B                                      B",
         "BBBB                 AAAAAAAAAAAAAAAAAAB",
      });

  
      public Level7(
         GameState gameState, 
         ScreenSpace screenSpace,
         GameGraphics graphics,
         ScreenController screenController)
         : base("Level 7", graphics, screenController, gameState, screenSpace)
      {
         var map =
            new Map(
               screenSpace,
               tileMap,
               graphics
            );

         entities.Add(map);

         levelState.Door = new Door(graphics.Door, 25, 1, screenSpace, levelState);
         entities.Add(levelState.Door);

         entities.Add(new LivesIndicator(graphics.Life, screenSpace, gameState));

         //entities.Add(new Bomb(graphics, 20, 32, 60, screenSpace, tileMap));
         //entities.Add(new Bomb(graphics, 12, 10, 15, screenSpace, tileMap));
         entities.Add(new Bomb(graphics, 26, 5, 7, screenSpace, tileMap));

         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 26, 13, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 23, 31, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 6, 5, screenSpace));
         entities.AddRange(levelState.Enemies);

         levelState.Evidence =
            new Evidence(
               levelState,
               graphics.Evidence,
               //5, 3,
               6, 38,
               screenSpace
            );

         entities.Add(levelState.Evidence);

         entities.Add(
            new Player(
               gameState,
               screenController,
               graphics,
               screenSpace,
               map,
               levelState,
               screenSpace.GetTilePosition(screenSpace.LastRow - 2, 1)
            )
         );
      }
   }
}
