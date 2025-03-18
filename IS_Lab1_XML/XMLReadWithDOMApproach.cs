using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IS_Lab1_XML
{
    internal class XMLReadWithDOMApproach
    {
        public static void Read(string xmlpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlpath);
            string postac;
            string sc;
            string nazwaStosowana;
            string nazwaPostaciFarmaceutycznej;
            int count = 0;
            var drugs = doc.GetElementsByTagName("produktLeczniczy");
            foreach (XmlNode d in drugs)
            {
                postac = d.Attributes.GetNamedItem("nazwaPostaciFarmaceutycznej").Value;
                sc = d.Attributes.GetNamedItem("nazwaPowszechnieStosowana").Value;
                if (postac == "Krem" && sc == "Mometasoni furoas")
                    count++;
            }
            Console.WriteLine("Liczba produktów leczniczych w postaci kremu, których jedyną substancją czynną jest Mometasoni furoas {0}", count);

            Dictionary<string, HashSet<string>> leki = new Dictionary<string, HashSet<string>>();
            foreach (XmlNode d in drugs)
            {
                nazwaStosowana = d.Attributes.GetNamedItem("nazwaPowszechnieStosowana").Value;
                nazwaPostaciFarmaceutycznej = d.Attributes.GetNamedItem("nazwaPostaciFarmaceutycznej").Value;
                if(!leki.ContainsKey(nazwaStosowana))
                {
                    leki[nazwaStosowana] = new HashSet<string>();
                }
                leki[nazwaStosowana].Add(nazwaPostaciFarmaceutycznej);
            }
            count = 0;
            foreach (var l in leki)
            {
                if (l.Value.Count > 1)
                {
                    count++;
                }
            }
            Console.WriteLine("Liczba różnych preparatów o tej samej nazwie powszechnej: {0}", count);

            Dictionary<string, HashSet<string>> tworcy = new Dictionary<string, HashSet<string>>();
            var wytworcy = doc.GetElementsByTagName("wytworcy");
            foreach (XmlNode w in wytworcy)
            {
                    var nazwaWytworcy = w.Attributes["nazwaWytworcyImportera"];
                    var krajWytworcy = w.Attributes["krajWytworcyImportera"];

                if (nazwaWytworcy == null || krajWytworcy == null)
                    continue;
                if (!tworcy.ContainsKey(krajWytworcy.Value))
                {
                    tworcy[krajWytworcy.Value] = new HashSet<string>();
                }
                tworcy[krajWytworcy.Value].Add(nazwaWytworcy.Value);
            }
            var posortowane = tworcy
                .OrderByDescending(x => x.Value.Count)
                .Take(5)
                .ToList();
            foreach (var t in posortowane)
            {
                Console.WriteLine("Kraj: {0}, liczba wytwórców: {1}", t.Key, t.Value.Count);
            }
        }
    }
}
