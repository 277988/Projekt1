using System.Collections.Generic;

namespace KinoWinForms.modele
{
    public class Rezerwacja
    {
        public string Imie { get; set; }

        public Seans Seans { get; set; }

        public int IloscBiletow { get; set; }

        public List<int> NumeryMiejsc { get; set; }

        public decimal Cena { get; set; }   
    }
}