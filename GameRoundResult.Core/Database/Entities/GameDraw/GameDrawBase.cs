using System;

namespace GameRoundResult.Core.Database.Entities.GameDraw
{
    public class GameDrawBase
    {
        public long DrawId { get; set; }
    }

    public class GameDrawResultBase : GameDrawBase
    {
        public DateTime Time { get; set; }
    }
}
