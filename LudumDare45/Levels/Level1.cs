namespace LudumDare45.Windows
{
   internal class Level1 : Level
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
         "B                                      B",
         "B       BBBBBBBBBBBB    BBBBBBB        B",
         "B                                      B",
         "B                                      B",
         "BBBBB                                  B",
         "B                                      B",
         "B                                      B",
         "B     BBBBBBBBBB                       B",
         "B                                      B",
         "B                  BBBB                B",
         "B                                      B",
         "B                                      B",
         "B                           BBBBBBB    B",
         "B                                      B",
         "B                     BBBB             B",
         "B                                      B",
         "B              BBBB                    B",
         "B                                      B",
         "B        BBBB                          B",
         "B                                      B",
         "BAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB",
      });

  
      public Level1(
         GameState gameState, 
         ScreenSpace screenSpace,
         GameGraphics graphics,
         ScreenController screenController)
         : base("Level 1", graphics, screenController, gameState, screenSpace)
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

         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 26, 30, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 7, 14, screenSpace));
         entities.AddRange(levelState.Enemies);

         levelState.Evidence =
            new Evidence(
               levelState,
               graphics.Evidence,
               6, 38,
             //  26, 10,
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
