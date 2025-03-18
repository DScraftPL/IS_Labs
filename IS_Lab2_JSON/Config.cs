using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Lab2_JSON
{
    class Config
    {
        public SerializationConfig Serialization { get; set; }
        public PathsConfig Paths { get; set; }
        public List<string> Operations { get; set; }
    }
    public class SerializationConfig
    {
        public string Source { get; set; }
    }
    public class PathsConfig
    {
        public string SourceFolder { get; set; }
        public string JsonSourceFile { get; set; }
        public string JsonDestinationFile { get; set; }
        public string YamlDestinationFile { get; set; }
    }
}
