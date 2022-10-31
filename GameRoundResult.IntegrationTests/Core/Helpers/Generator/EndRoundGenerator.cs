using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.IntegrationTests
{
    public class EndRoundGenerator : BaseTestDataGenerator<EndRoundModel>, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() => GetData()
            .Select(e =>
            {
                return new object[] {
                    e.Game,
                    e.PlayerId,
                    e.RoundId,
                    e.TotalAmount,
                    e.TotalWin,
                    e.ValidBet,
                    e.EndTime,
                    e.ErrorCode,
                    e.ErrorDescription};
            }).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}