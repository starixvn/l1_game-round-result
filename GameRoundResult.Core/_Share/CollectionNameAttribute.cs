using System;
namespace GameRoundResult.Core._Share
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CollectionNameAttribute : Attribute
    {
        public CollectionNameAttribute(string roundCollectionName, string betCollectionName)
        {
            if (string.IsNullOrWhiteSpace(roundCollectionName))
            {
                throw new ArgumentNullException(nameof(roundCollectionName));
            }

            if (string.IsNullOrWhiteSpace(betCollectionName))
            {
                throw new ArgumentNullException(nameof(betCollectionName));
            }

            RoundCollectionName = roundCollectionName;
            BetCollectionName = betCollectionName;
        }

        public CollectionNameAttribute(string roundCollectionName, string betCollectionName, string onesCollectionName)
            : this (roundCollectionName, betCollectionName)
        {
            if (string.IsNullOrWhiteSpace(onesCollectionName))
            {
                throw new ArgumentNullException(nameof(onesCollectionName));
            }

            OnesCollectionName = onesCollectionName;
        }

        public string RoundCollectionName { get; }

        public string BetCollectionName { get; }

        public string OnesCollectionName { get; }
    }
}
