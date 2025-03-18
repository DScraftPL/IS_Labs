using Newtonsoft.Json;
using System.Runtime.InteropServices.Marshalling;

namespace IS_Lab2_JSON
{
    public class SerializeJson
    {
        public static void Run(List<AdministrativeUnit> units, string filePath)
        {
            var selectedUnits = units.Select(unit => new CompressedUnit
            {
                Kod_TERYT = unit.Kod_TERYT,
                Powiat = unit.Powiat,
                Województwo = unit.Województwo,
                typ_JST = unit.typ_JST,
                miejscowosc = unit.miejscowość,
                telefon_z_numerem_kierunkowym = $"{unit.telefonkierunkowy} {unit.telefon}"
            }).ToList();

            string json = JsonConvert.SerializeObject(selectedUnits, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        public static void Run(string filePathSource, string FilePathDestination)
        {
            var units = DeserializeJson.Deserialize(filePathSource);
            Run(units, FilePathDestination);
        }
    }
}
