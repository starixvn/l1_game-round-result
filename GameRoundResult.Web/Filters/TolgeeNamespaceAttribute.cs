using System;

namespace GameRoundResult.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class TolgeeNamespaceAttribute : Attribute
    {
        public TolgeeNamespaceAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}