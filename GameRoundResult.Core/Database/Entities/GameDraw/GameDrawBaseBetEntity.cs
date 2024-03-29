using GameRoundResult.Core._Share;
using System.Collections.Generic;

namespace GameRoundResult.Core.Database.Entities.GameDraw
{
    public class GameDrawBaseBetEntity: BaseBetEntity
    {
        public virtual decimal TotalBet { get; }

        public long DrawId { get; set; }
    }
}
