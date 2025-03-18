using System.IO;

namespace IS_Lab1_XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string xmlpath = Path.Combine("Assets", "data.xml");
            Console.WriteLine("XML loaded by DOM Approach");
            XMLReadWithDOMApproach.Read(xmlpath);
            Console.WriteLine("XML loaded by SAX Approach");
            XMLReadWithSAXApproach.Read(xmlpath);
            Console.WriteLine("XML loaded by XLSTDOM Approach");
            XMLReadWithXLSTDOM.Read(xmlpath);
            Console.WriteLine("Advanced XML Analysis");
            XMLReadAdvanced.Read(xmlpath);
            Console.ReadLine();
        }
    }
}
