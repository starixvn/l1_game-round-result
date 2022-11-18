using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GameRoundResult.IntegrationTests
{
    public abstract class TestCaseDataProvider<T>
    {
        public abstract List<T> GetTestCaseParams();
    }

    public class TestCaseDataProviderBase<T>
    {
        public List<T> GetTestCaseParams()
        {
            var data = new List<T>();
            var types = Assembly.GetAssembly(typeof(TestCaseDataProvider<T>)).GetTypes().Where(type => type.IsSubclassOf(typeof(TestCaseDataProvider<T>)));
            foreach (var type in types)
            {
                var generator = (TestCaseDataProvider<T>)Activator.CreateInstance(type);
                data.AddRange(generator.GetTestCaseParams());
            }
            return data;
        }
    }
}