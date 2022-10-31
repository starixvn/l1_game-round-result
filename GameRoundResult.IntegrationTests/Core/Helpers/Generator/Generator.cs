using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GameRoundResult.IntegrationTests
{
    public abstract class Generator<T>
    {
        public abstract List<T> GetData();
    }

    public class BaseTestDataGenerator<T>
    {
        public List<T> GetData()
        {
            var data = new List<T>();
            var types = Assembly.GetAssembly(typeof(Generator<T>)).GetTypes().Where(type => type.IsSubclassOf(typeof(Generator<T>)));
            foreach (var type in types)
            {
                var generator = (Generator<T>)Activator.CreateInstance(type);
                data.AddRange(generator.GetData());
            }
            return data;
        }
    }
}