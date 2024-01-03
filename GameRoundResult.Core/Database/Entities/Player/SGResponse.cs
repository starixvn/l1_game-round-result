using System;

namespace GameRoundResult.Core.Database.Entities.Player
{
    public class SGResponse<T> where T : SGResult
    {
        public DateTimeOffset TimeStamp { get; set; }

        public T Result { get; set; }
    }
}