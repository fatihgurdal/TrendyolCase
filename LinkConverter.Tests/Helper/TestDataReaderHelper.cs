using Newtonsoft.Json;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LinkConverter.Tests.Helper
{
    internal class TestDataReaderHelper
    {
        private const string TestNameSpace = "LinkConverter.Tests.Tests.";
        private static string ReadEmbededResource(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream resource = assembly.GetManifestResourceStream($"{TestNameSpace}{path}"))
            {
                using (StreamReader reader = new StreamReader(resource))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        internal static IEnumerable<T[]> GetAppsettingsTestData<T>(string path)
        {
            var json = ReadEmbededResource(path);
            var testData = JsonConvert.DeserializeObject<List<T>>(json);

            return testData.Select(x => new[] { x });
        }
    }
}
