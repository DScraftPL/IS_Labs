using System.Data;
using YamlDotNet.Serialization;

namespace IS_Lab2_JSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string yaml = File.ReadAllText(Path.Combine("Assets", "basic_config.yaml"));
            var deserializer = new DeserializerBuilder().Build();

            var config = deserializer.Deserialize<Config>(yaml);

            var jsonSourceFile = Path.Combine(config.Paths.SourceFolder, config.Paths.JsonSourceFile);
            var jsonDestinationFile = Path.Combine(config.Paths.SourceFolder, config.Paths.JsonDestinationFile);
            var yamlDestinationFile = Path.Combine(config.Paths.SourceFolder, config.Paths.YamlDestinationFile);


            foreach (var operation in config.Operations)
            {
                if (operation == "serialize_json")
                {
                    if (config.Serialization.Source == "File")
                    {
                        Console.WriteLine("serialize_json_file");
                        SerializeJson.Run(jsonSourceFile, jsonDestinationFile);
                    }
                    else if (config.Serialization.Source == "Object")
                    {
                        Console.WriteLine("serialize_json_obj");
                        SerializeJson.Run(DeserializeJson.Deserialize(jsonSourceFile), jsonDestinationFile);
                    }
                }
                else if (operation == "deserialize_json")
                {
                    Console.WriteLine("deserialize_json");
                    DeserializeJson.Run(jsonSourceFile);
                }
                else if(operation == "convert_to_yaml")
                {
                    Console.WriteLine("convert_to_yaml");
                    ConvertJsonToYaml.Run(jsonSourceFile, yamlDestinationFile);
                }
                else if(operation == "somestats")
                {
                    Console.WriteLine("somestats");
                    DeserializeJson.SomeStats(jsonSourceFile);
                }
                else if(operation == "allstats")
                {
                    Console.WriteLine("allstats");
                    DeserializeJson.AllStats(jsonSourceFile);
                }
                else if(operation == "convert_json_to_xml")
                {
                    Console.WriteLine("convert_json_to_xml");
                    ConvertJsonToXML.Run(jsonSourceFile, Path.Combine("Assets", "temp.xml"));
                }
                else if(operation == "convert_xml_to_json")
                {
                    Console.WriteLine("convert_xml_to_json");
                    ConvertXMLToJson.Run(Path.Combine("Assets", "temp.xml"), jsonDestinationFile);
                }
            }
        }
    }
}