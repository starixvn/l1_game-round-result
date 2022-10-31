using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameRoundResult.IntegrationTests
{
    public class RoundResultGenerator : BaseTestDataGenerator<RoundResultModel>, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() => GetData()
            .Select(e =>
            {
                return new object[] {
                    e.Game,
                    e.RoundId,
                    e.Date,
                    e.FileName,
                };
            }).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}