using System;

namespace GameRoundResult.Core._Share
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CollectionNameAttribute : Attribute
    {
        public CollectionNameAttribute(string collectionName)
        {
            if (string.IsNullOrWhiteSpace(collectionName))
            {
                throw new ArgumentNullException(nameof(collectionName));
            }

            CollectionName = collectionName;
        }

        public string CollectionName { get; }
    }
}
