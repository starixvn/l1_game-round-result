using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.IntegrationTests
{
    public class EndRoundTestCaseProvider : TestCaseDataProviderBase<EndRoundTestCaseParam>, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() => GetTestCaseParams()
            .Select(e =>
            {
                return new object[] {
                    e.Game,
                    e.TestCase,
                    e.PlayerId,
                    e.RoundId,
                    e.TotalAmount,
                    e.TotalWin,
                    e.ValidBet,
                    e.EndTime,
                    e.ErrorCode,
                    e.ErrorDescription
                };
            }).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}