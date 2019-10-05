namespace LudumDare45.Windows
{
   internal class Level6 : Level
   {
      readonly TileMap tileMap = new TileMap(new string[]
      {
         "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                BBB   B",
         "B                                      B",
         "B                  BB   BB             B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B             BBBBBBBB                 B",
         "B                                      B",
         "B                                      B",
         "B BBBBB                                B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B                                      B",
         "B       BB     BB    BB                B",
         "B      B                 BBBBBBBBBBBB  B",
         "B     B                                B",
         "B    B                                 B",
         "BAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB",
      });

  
      public Level6(
         GameState gameState, 
         ScreenSpace screenSpace,
         GameGraphics graphics,
         ScreenController screenController)
         : base("Level 6", graphics, screenController, gameState, screenSpace)
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

         entities.Add(new Bomb(graphics, 25, 7, 30, screenSpace, tileMap));

         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 26, 13, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 26, 16, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 26, 19, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 26, 21, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 26, 23, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 26, 25, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 26, 27, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 26, 29, screenSpace));

         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 23, 31, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 23, 34, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 23, 28, screenSpace));
         levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 23, 26, screenSpace));
         //levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 23, 31, screenSpace));
         //levelState.Enemies.Add(new EnemyStyle1(graphics.Enemy, map, 5, 5, screenSpace));
         entities.AddRange(levelState.Enemies);

         levelState.Evidence =
            new Evidence(
               levelState,
               graphics.Evidence,
               //5, 3,
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
               screenSpace.GetTilePosition(3, 35)
            )
         );
      }
   }
}
