using Xunit;

namespace GameRoundResult.IntegrationTests
{
    [CollectionDefinition("IntergrationTest")]
    public class DatabaseCollection : ICollectionFixture<DbFixture>
    {
    }
}