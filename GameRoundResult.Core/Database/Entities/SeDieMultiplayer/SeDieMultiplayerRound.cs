using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities.SeDieMultiplayer
{
    [CollectionName("sediemultiplayer_rounds")]
    public class SeDieMultiplayerRound : GameRound
    {
        public SeDieMultiplayerResult Result { get; set; }
        public SeDieMultiplayerSettlementResult SettlementResult { get; set; }
    }

    public class SeDieMultiplayerResult : SeDieResultEntity { }

    public class SeDieMultiplayerSettlementResult : SeDieSettlementResultEntity { }
}
