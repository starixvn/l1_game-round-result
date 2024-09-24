using System;

namespace GameRoundResult.Web.Configuration
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ViewNameAttribute : Attribute
    {
        public ViewNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}