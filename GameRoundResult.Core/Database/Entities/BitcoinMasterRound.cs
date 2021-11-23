using System;
using System.Collections.Generic;
using GameRoundResult.Core._Share;
using MongoDB.Bson.Serialization.Attributes;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("bitcoinmaster_rounds")]
    public class BitcoinMasterRound : GameRound
    {
        public BitcoinMasterRoundResult Result { get; set; }

        public Dictionary<string, bool> SettlementResult { get; set; }
    }

    public class BitcoinMasterRoundResult
    {
        [BsonElement("open")]
        public decimal BettingPrice { get; set; }

        [BsonElement("close")]
        public decimal ResultPrice { get; set; }

        public bool IsUp => ResultPrice > BettingPrice;
        public bool IsDown => ResultPrice < BettingPrice;

        public decimal PriceDiff => Math.Abs(ResultPrice - BettingPrice);
    }
}