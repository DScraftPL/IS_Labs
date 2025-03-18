using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace IS_Lab2_JSON
{
    class ConvertXMLToJson
    {
        public static void Run(string filePathSource, string filePathDestination)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathSource);
            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            //Console.WriteLine(json);
            File.WriteAllText(filePathDestination, json);
        }
    }
}
