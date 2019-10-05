namespace LudumDare45.Windows
{

   internal class Level2 : Level
   {
      readonly TileMap tileMap = new TileMap(new string[]
      {
         "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                             BBBBBBBBBB",
         "B                            B         B",
         "B                           B          B",
         "B                      BBBBBB          B",
         "B                                      B",
         "B     BBBBBBBBBB  BBBBB                B",
         "B                                      B",
         "B                                      B",
         "BBBBBBBBBBB                            B",
         "B          B                           B",
         "B           B                          B",
         "B            B                         B",
         "B             BB     BB                B",
         "B                                      B",
         "B                                 B    B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B             BB                       B",
         "B                        BBBBBBBBBB    B",
         "B                                      B",
         "B                                      B",
         "BAAAAAAAAAAAAAA         AAAAAAAAAAAAAAAB",
      });

  
      public Level2(
         GameState gameState, 
         ScreenSpace screenSpace,
         GameGraphics graphics,
         ScreenController screenController)
         : base("Level 2", graphics, screenController, gameState, screenSpace)
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

         entities.AddRange(levelState.Enemies);

         levelState.Evidence =
            new Evidence(
               levelState,
               graphics.Evidence,
               26, 10,
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
               screenSpace.GetTilePosition(3, 37)
            )
         );
      }
   }
}
