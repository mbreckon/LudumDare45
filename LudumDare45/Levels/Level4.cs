namespace LudumDare45.Windows
{

   internal class Level4 : Level
   {
      readonly TileMap tileMap = new TileMap(new string[]
      {
         "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "BBBBBBBBBBBBBBBBBBBBBBBBBB             B",
         "B                                      B",
         "B                             BBB      B",
         "B                                      B",
         "B          BB                          B",
         "B                                      B",
         "B                  BBBBBB           BBBB",
         "B         B                            B",
         "B             B                        B",
         "B                  BBBBBBBBBBBBB       B",
         "B                                      B",
         "B                                      B",
         "B                                   BBBB",
         "B      BB                              B",
         "B              B                       B",
         "B                     BB    BBBB       B",
         "B                                      B",
         "B                                      B",
         "B                                BBBB  B",
         "B                                      B",
         "B     B                                B",
         "BAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB",
      });

  
      public Level4(
         GameState gameState, 
         ScreenSpace screenSpace,
         GameGraphics graphics,
         ScreenController screenController)
         : base("Level 4", graphics, screenController, gameState, screenSpace)
      {
         var map =
            new Map(
               screenSpace,
               tileMap,
               graphics
            );

         entities.Add(map);

         levelState.Door = new Door(graphics.Door, 18, 10, screenSpace, levelState);
         entities.Add(levelState.Door);

         entities.Add(new LivesIndicator(graphics.Life, screenSpace, gameState));

         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 26, 25, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 26, 32, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 26, 37, screenSpace));
         entities.AddRange(levelState.Enemies);

         levelState.Evidence =
            new Evidence(
               levelState,
               graphics.Evidence,
               5, 3,
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
