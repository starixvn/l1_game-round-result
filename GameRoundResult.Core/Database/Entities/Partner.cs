using GameRoundResult.Core._Share;

namespace GameRoundResult.Core.Database.Entities
{
    [CollectionName("partners")]
    public class Partner : Document
    {
        public string PartnerId { get; set; }

        public string Name { get; set; }

        public string SecretKey { get; set; }
    }
}