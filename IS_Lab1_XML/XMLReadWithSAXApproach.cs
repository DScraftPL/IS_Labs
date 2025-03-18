using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IS_Lab1_XML
{
    internal class XMLReadWithSAXApproach
    {
        public static void Read(string xmlpath)
        {
            // konfiguracja początkowa dla XmlReadera
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            settings.IgnoreWhitespace = true;
            // odczyt zawartości dokumentu
            XmlReader reader = XmlReader.Create(xmlpath, settings);
            // zmienne pomocnicze
            int count = 0;
            string postac = "";
            string sc = "";
            reader.MoveToContent();
            Dictionary<string, HashSet<string>> leki = new Dictionary<string, HashSet<string>>();
            // analiza każdego z węzłów dokumentu
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "produktLeczniczy")
                {
                    postac = reader.GetAttribute("nazwaPostaciFarmaceutycznej");
                    sc = reader.GetAttribute("nazwaPowszechnieStosowana");
                    if (postac == "Krem" && sc == "Mometasoni furoas")
                        count++;
                    if(!leki.ContainsKey(sc))
                    {
                        leki[sc] = new HashSet<string>();
                    }
                    leki[sc].Add(postac);
                }
            }
            Console.WriteLine("Liczba produktów leczniczych w postacikremu, których jedyną substancją czynną jest Mometasoni furoas {0}", count);
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
            reader = XmlReader.Create(xmlpath, settings);
            reader.MoveToContent();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "wytworcy")
                {
                    string nazwa = reader.GetAttribute("nazwaWytworcyImportera");
                    string kraj = reader.GetAttribute("krajWytworcyImportera");
                    if(kraj != null && nazwa != null)
                    {
                        if (!tworcy.ContainsKey(kraj))
                        {
                            tworcy[kraj] = new HashSet<string>();
                        }
                        tworcy[kraj].Add(nazwa);
                    }
                }
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
