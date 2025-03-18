using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace IS_Lab1_XML
{
    class XMLReadAdvanced
    {
        public static void Read(string xmlpath)
        {
            int countJedna = 0, countWiele = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlpath);

            Dictionary<string, int> substanceCount = new Dictionary<string, int>();

            var produkty = doc.GetElementsByTagName("substancjaCzynna");

            foreach (XmlNode produkt in produkty)
            {
                if(produkt.Attributes != null)
                {
                    string name = produkt.Attributes["nazwaSubstancji"].Value;
                    if (substanceCount.ContainsKey(name))
                        substanceCount[name]++;
                    else
                        substanceCount[name] = 1;
                }
            }

            foreach (var kvp in substanceCount)
            {
                if (kvp.Value == 1)
                    countJedna++;
                else
                    countWiele++;
            }

            Console.WriteLine("Liczba substancji czynnych występujących w dokładnie jednym produkcie: {0}", countJedna);
            Console.WriteLine("Liczba substancji czynnych występujących w wielu produktach: {0}", countWiele);
        }
    }
}
