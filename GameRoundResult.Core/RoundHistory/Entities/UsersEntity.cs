using GameRoundResult.Core._Share;
using System;

namespace GameRoundResult.Core.Database.Entities.RoundHistory
{
    [CollectionName("users")]
    public class UsersEntity : Document
    {        
        public int __v { get; set; }

        public LocalAccount Local { get; set; }

        public string UserIdStr { get; set; }

        public string OperatorId { get; set; }

        public string PlayerId { get; set; }
    }

    public class LocalAccount
    {
        public int Ban_pass { get; set; }

        public bool Ban_login { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime regDate { get; set; }

        public string MemberId { get; set; }

        public string MemberName { get; set; }

        public string Language { get; set; }
    }
}
