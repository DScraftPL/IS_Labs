using Newtonsoft.Json;


namespace IS_Lab2_JSON
{
    public class DeserializeJson
    {
        public static void Run(string filePath)
        {
            List<AdministrativeUnit> units = JsonConvert.DeserializeObject<List<AdministrativeUnit>>(File.ReadAllText(filePath));
        }
        public static List<AdministrativeUnit> Run1(string filePath)
        {
            return JsonConvert.DeserializeObject<List<AdministrativeUnit>>(File.ReadAllText(filePath));
        }
        public static List<AdministrativeUnit> Deserialize(string filePath)
        {
            return JsonConvert.DeserializeObject<List<AdministrativeUnit>>(File.ReadAllText(filePath));
        }
        public static void AllStats(string filePath)
        {
            Dictionary<string, Dictionary<string, int>> statystki = new Dictionary<string, Dictionary<string, int>>();
            List<AdministrativeUnit> units = JsonConvert.DeserializeObject<List<AdministrativeUnit>>(File.ReadAllText(filePath));
            foreach(var unit in units)
            {
                string wojewodztwo = unit.Województwo.Trim();
                if (!statystki.ContainsKey(wojewodztwo))
                {
                    statystki[wojewodztwo] = new Dictionary<string, int>();
                }
                if (!statystki[wojewodztwo].ContainsKey(unit.typ_JST))
                {
                    statystki[wojewodztwo][unit.typ_JST] = 0;
                }
                statystki[wojewodztwo][unit.typ_JST]++;
            }
            foreach (var wojewodztwo in statystki)
            {
                Console.WriteLine(wojewodztwo.Key);
                foreach (var typ in wojewodztwo.Value)
                {
                    Console.Write($"{typ.Key}: {typ.Value} ");
                }
                Console.WriteLine();
            }
        }
        public static void SomeStats(string filePath)
        {
            int example_stat = 0;
            List<AdministrativeUnit> units = JsonConvert.DeserializeObject<List<AdministrativeUnit>>(File.ReadAllText(filePath));
            foreach (var unit in units)
            {
                if (unit.typ_JST == "GM" && unit.Województwo == "dolnośląskie")
                {
                    example_stat++;
                }
            }
            Console.WriteLine("liczba urzędów miejskich w województwie dolnośląskim: " + " " + example_stat);
        }
    }
}