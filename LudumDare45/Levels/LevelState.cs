using System.Collections.Generic;

namespace LudumDare45.Windows
{
   class LevelState
   {
      public bool EvidenceRetrieved { get; set; }
      public bool LevelCompleted { get; set; }

      public Evidence Evidence { get; set; }
      public List<EnemyStyle1> Enemies { get; } = new List<EnemyStyle1>();

      public Door Door { get; set; }
   }
}
