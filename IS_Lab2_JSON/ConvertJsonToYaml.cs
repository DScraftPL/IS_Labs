using YamlDotNet;
using YamlDotNet.Serialization;
using Newtonsoft.Json;
using YamlDotNet.Serialization.NamingConventions;

namespace IS_Lab2_JSON
{
    public class ConvertJsonToYaml
    {
        public static void Run(string filePathIn, string filePathOut)
        {
            var jsonObject = DeserializeJson.Run1(filePathIn);
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            string yaml = serializer.Serialize(jsonObject);
            File.WriteAllText(filePathOut, yaml);
        }
    }
}
