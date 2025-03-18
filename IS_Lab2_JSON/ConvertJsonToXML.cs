using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace IS_Lab2_JSON
{
    class ConvertJsonToXML
    {
        public static void Run(string filePathSource, string filePathDestination)
        {
            string json = File.ReadAllText(filePathSource);
            var result = JsonConvert.DeserializeObject<List<AdministrativeUnit>>(json);
            string jsonObject = JsonConvert.SerializeObject(new { Items = result });

            XmlDocument doc = JsonConvert.DeserializeXmlNode(jsonObject, "root");

            doc.Save(filePathDestination);
        }
    }
}
