namespace LudumDare45.Windows
{
   interface ScreenController
   {
      void GoToIntro();
      void GoToProgress();
      void GoToLevel(int level);
      void GoToRetryLevel();
   }
}
