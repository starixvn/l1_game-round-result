using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.IntegrationTests
{
    public class BetHistoryGenerator : BaseTestDataGenerator<BetHistoryModel>, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() => GetData()
            .Select(e =>
            {
                return new object[] {
                    e.Game,
                    e.PlayerId,
                    e.RoundId,
                    e.Language,
                    e.FileName,
                };
            }).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}