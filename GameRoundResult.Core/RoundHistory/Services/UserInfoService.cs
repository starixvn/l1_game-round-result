using GameRoundResult.Core.Database.Entities;
using GameRoundResult.Core.Database.Entities.RoundHistory;
using GameRoundResult.Core.Models.RoundHistory;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameRoundResult.Core.Services.RoundHistory
{
    public interface IUserInfoService
    {
        Task<IEnumerable<UserInfoModel>> FilterByUidsAndUserName(IEnumerable<string> uids, string userName, bool excludeBot);
    }

    public class UserInfoService : IUserInfoService
    {
        private readonly IMongoCollection<UserInfosEntity> accountInfoCollection;
        private readonly IMongoCollection<UsersEntity> accountCollection;

        public UserInfoService(IMongoDatabase database)
        {
            accountInfoCollection = database.GetCollection<UserInfosEntity>(Document.GetCollectionName(typeof(UserInfosEntity)));
            accountCollection = database.GetCollection<UsersEntity>(Document.GetCollectionName(typeof(UsersEntity)));
        }

        public async Task<IEnumerable<UserInfoModel>> FilterByUidsAndUserName(IEnumerable<string> uids, string userName, bool excludeBot)
        {
            var userNameRegex = new Regex($"(?i){userName}");
            var userInfos = (await accountInfoCollection.FindAsync(info => uids.Contains(info.UserId) && (!excludeBot || !info.IsBot))).ToEnumerable();

            var builder = Builders<UsersEntity>.Filter;
            var filter = builder.In(x => x.Id, uids);
            var matchUserName = builder.Where(user => userName == null || userNameRegex.IsMatch(user.Local.MemberName));
            filter &= matchUserName;
            var users = await accountCollection.Find(filter).ToListAsync();
            return users.Join(userInfos,
                user => user.Id.ToString(),
                userInfo => userInfo.UserId,
                (user, userInfo) => new UserInfoModel(userInfo.UserId, user.Local.Username, user.Local.MemberName, userInfo.Name, userInfo.IsBot));
        }
    }
}
