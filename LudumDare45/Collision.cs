namespace LudumDare45.Windows
{
   class Collision
   {
      public Collision(bool left, bool right, bool top, bool bottom, bool bottomLeft, bool bottomRight)
      {
         Left = left;
         Right = right;
         Top = top;
         Bottom = bottom;
         BottomLeft = bottomLeft;
         BottomRight = bottomRight;
      }

      public bool Left { get; }
      public bool Right { get; }
      public bool Top { get; }
      public bool Bottom { get; }
      public bool BottomLeft { get; }
      public bool BottomRight { get; }
   }
}
