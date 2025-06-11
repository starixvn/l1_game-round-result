using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("soloblackjack_bets")]
    public class SoloBlackjackBet : BlackjackBet
    {
    }
}
