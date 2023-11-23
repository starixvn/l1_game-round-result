namespace GameRoundResult.Web.Models.GameRoundResult
{
    using System.Collections.Generic;

    public class RoundResultPagingViewModel
    {
        public IEnumerable<IEnumerable<string>> Data { get; set; }

        public long RecordsFiltered { get; set; }

        public long RecordsTotal { get; set; }
    }
}