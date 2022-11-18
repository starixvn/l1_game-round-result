using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.IntegrationTests
{
    public class BetHistoryTestCaseProvider : TestCaseDataProviderBase<BetHistoryTestCaseParam>, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() => GetTestCaseParams()
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