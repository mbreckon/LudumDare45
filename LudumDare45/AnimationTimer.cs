using System;

namespace LudumDare45.Windows
{
   class AnimationTimer
   {
      readonly int milliseconds;
      readonly Action action;

      public AnimationTimer(int milliseconds, Action action)
      {
         this.milliseconds = milliseconds;
         this.action = action;
      }

      public void Update(TimeSpan currentTime)
      {
         if (!lastTime.HasValue)
            lastTime = currentTime;

         var elapsedTime = (currentTime - lastTime.Value).TotalMilliseconds;
         if (elapsedTime > milliseconds)
         {
            action();
            lastTime = currentTime;
         }
      }

      private TimeSpan? lastTime;
   }
}
