namespace LudumDare45.Windows
{

   internal class Level8 : Level
   {
      readonly TileMap tileMap = new TileMap(new string[]
      {
         "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB",
         "B             B                        B",
         "B             B                        B",
         "B             B                        B",
         "B                              BBBBBBBBB",
         "B                                      B",
         "B  BBBBBBB                             B",
         "B                                      B",
         "B             BBBBBB    BBBBBB         B",
         "B                                      B",
         "B         BBB                          B",
         "B      BBBB                            B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "BBBBBBBBBBBBBBB   BB     BB    BB      B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                    BBB",
         "B        BBBBBBB                       B",
         "B                                      B",
         "B                 BB     BB    BB      B",
         "B                                      B",
         "B                                      B",
         "BAA                                    B",
      });

  
      public Level8(
         GameState gameState, 
         ScreenSpace screenSpace,
         GameGraphics graphics,
         ScreenController screenController)
         : base("Level 8", graphics, screenController, gameState, screenSpace)
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
         //entities.Add(new Bomb(graphics, 26, 5, 7, screenSpace, tileMap));

         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 7, 20, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 7, 30, screenSpace));
        levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 21, 10, screenSpace));
       //  levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 18, 1, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 10, 7, screenSpace));
    //     levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 14, 1, screenSpace));

         //     levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 5, 5, screenSpace));
         entities.AddRange(levelState.Enemies);

         levelState.Evidence =
            new Evidence(
               levelState,
               graphics.Evidence,
               //5, 3,
               14, 2,
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
               screenSpace.GetTilePosition(1, 38)
            )
         );
      }
   }
}
