namespace LudumDare45.Windows
{

   internal class Level3 : Level
   {
      readonly TileMap tileMap = new TileMap(new string[]
      {
         "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                        BBBBBBBB      B",
         "B                                      B",
         "B                                      B",
         "B           BBBB                    BBBB",
         "B                                      B",
         "B                                      B",
         "B                             BBB      B",
         "B                                      B",
         "B                                      B",
         "B                       BBB            B",
         "B                                      B",
         "B                                      B",
         "B                           BBBB       B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                  BBBBB",
         "B                                      B",
         "B        BBBB    BBBB    BBBB          B",
         "B        B                             B",
         "BAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA    AAAB",
      });

  
      public Level3(
         GameState gameState, 
         ScreenSpace screenSpace,
         GameGraphics graphics,
         ScreenController screenController)
         : base("Level 3", graphics, screenController, gameState, screenSpace)
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

         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 26, 20, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 26, 30, screenSpace));
         //levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 23, 31, screenSpace));
         //levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 5, 5, screenSpace));
         entities.AddRange(levelState.Enemies);

         levelState.Evidence =
            new Evidence(
               levelState,
               graphics.Evidence,
               //5, 3,
               10, 1,
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
              // screenSpace.GetTilePosition(5, 11)
              screenSpace.GetTilePosition(screenSpace.LastRow - 2, 1)
            )
         );
      }
   }
}
