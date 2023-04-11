using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.IntegrationTests
{
    public class RetrieveEndRoundTestCaseProvider : TestCaseDataProviderBase<RetrieveEndRoundTestCaseParam>, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() => GetTestCaseParams()
            .Select(e =>
            {
                return new object[] {
                    e.GameId,
                    e.GameName,
                    e.GameType,
                    e.TestCase,
                    e.PlayerId,
                    e.RoundId,
                };
            }).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}