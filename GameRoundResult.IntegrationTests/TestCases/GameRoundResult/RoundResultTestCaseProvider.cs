using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.IntegrationTests
{
    public class RoundResultTestCaseProvider : TestCaseDataProviderBase<RoundResultTestCaseParam>, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() => GetTestCaseParams()
            .Select(e =>
            {
                return new object[] {
                    e.Game,
                    e.RoundId,
                    e.Date,
                    e.Language,
                    e.FileName,
                };
            }).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class RoundResultSelectOptionsTestCaseProvider : TestCaseDataProviderBase<RoundResultSelectOptionsTestCaseParam>, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() => GetTestCaseParams()
            .Select(e =>
            {
                return new object[] {
                    e.Game,
                    e.GameName,
                    e.Language,
                };
            }).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}