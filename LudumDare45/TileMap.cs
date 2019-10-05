using System.Collections.Generic;

namespace LudumDare45.Windows
{
   class TileMap
   {
      private char[,] map = new char[28, 40];

      private Dictionary<char, int> labelToSprite = new Dictionary<char, int>()
      {
         { 'A', 0 },
         { 'B', 1 }
      };

      public TileMap(string[] map)
      {
         for (int row = 0; row < 28; row++)
         {
            for (int col = 0; col < 40; col++)
            {
               this.map[row, col] = map[row][col];
            }
         }
      }

      public int? GetSprite(int row, int column)
      {
         if (map[row, column] == ' ')
            return null;
         else
            return labelToSprite[map[row, column]];
      }

      public bool GetCollision(double x, double y)
      {
         var column = (int)(x / 16);
         var row = (int)(y / 16);
         if (column > 39 || row > 27)
            return true;
         return map[row, column] != ' ';
      }

      public void ResetTile(int row, int column)
      {
         map[row, column] = ' ';
      }
   }
}
