using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Xml;

namespace IS_Lab1_XML
{
    internal class XMLReadWithXLSTDOM
    {
        public static void Read(string xmlpath)
        {
            XPathDocument document = new XPathDocument(xmlpath);
            XPathNavigator navigator = document.CreateNavigator();
            XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
            manager.AddNamespace("x", "http://rejestry.ezdrowie.gov.pl/rpl/eksport-danych-v5.0.0");
            XPathExpression query = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy[@nazwaPostaciFarmaceutycznej = 'Krem' and @nazwaPowszechnieStosowana = 'Mometasoni furoas']");
            query.SetContext(manager);
            int count = navigator.Select(query).Count;
            Console.WriteLine("Liczba produktów leczniczych w postaci kremu, których jedyną substancją czynną jest Mometasoni furoas {0}", count);

            Dictionary<string, HashSet<string>> leki = new Dictionary<string, HashSet<string>>();
            query = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy");
            query.SetContext(manager);
            XPathNodeIterator iterator = navigator.Select(query);
            while (iterator.MoveNext())
            {
                string postac = iterator.Current.GetAttribute("nazwaPostaciFarmaceutycznej", "");
                string sc = iterator.Current.GetAttribute("nazwaPowszechnieStosowana", "");
                if (!leki.ContainsKey(sc))
                {
                    leki[sc] = new HashSet<string>();
                }
                leki[sc].Add(postac);
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
            XPathExpression nquery = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy/x:daneOWytworcy/x:wytworcy");
            nquery.SetContext(manager);
            XPathNodeIterator nIterator = navigator.Select(nquery);
            while (nIterator.MoveNext())
            {
                string kraj = nIterator.Current.GetAttribute("krajWytworcyImportera", "");
                string nazwa = nIterator.Current.GetAttribute("nazwaWytworcyImportera", "");
                //Console.WriteLine(kraj, nazwa);
                if (!tworcy.ContainsKey(kraj))
                {
                    tworcy[kraj] = new HashSet<string>();
                }
                tworcy[kraj].Add(nazwa);
            }
            var posortowane = tworcy
                .OrderByDescending(x => x.Value.Count)
                .Take(5)
                .ToList();
            foreach (var t in posortowane)
            {
                Console.WriteLine("Kraj: {0}, liczba wytwórców: {1}", t.Key, t.Value.Count);
                foreach (var w in t.Value)
                {
                    Console.WriteLine("\t{0}", w);
                }
            }
        }
    }
}
