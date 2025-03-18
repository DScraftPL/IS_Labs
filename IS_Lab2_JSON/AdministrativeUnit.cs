using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Lab2_JSON
{
    public class AdministrativeUnit
    {
        public string Kod_TERYT { get; set; }
        public string nazwa_samorządu { get; set; }
        public string Województwo { get; set; }
        public string Powiat { get; set; }
        public string typ_JST { get; set; }
        public string nazwa_urzędu_JST { get; set; }
        public string miejscowość { get; set; }
        public string Kodpocztowy { get; set; }
        public string poczta { get; set; }
        public string Ulica { get; set; }
        public string Nrdomu { get; set; }
        public string telefonkierunkowy { get; set; }
        public string telefon { get; set; }
        public object telefon2 { get; set; }
        public object wewnętrzny { get; set; }
        public string FAXkierunkowy { get; set; }
        public string FAX { get; set; }
        public object FAXwewnętrzny { get; set; }
        public string ogólnyadrespocztyelektronicznejgminy_powiatu_województwa { get; set; }
        public string adreswwwjednostki { get; set; }
        public string ESP { get; set; }
    }
    public class CompressedUnit
    {
        public string Kod_TERYT { get; set; }
        public string Powiat { get; set; }
        public string Województwo { get; set; }
        public string typ_JST { get; set; }
        public string miejscowosc { get; set; }
        public string telefon_z_numerem_kierunkowym { get; set; }
    }
}
