using System.Collections.Generic;

namespace KinoWinForms.modele
{
    public class Seans
    {
        public Film Film { get; set; }
        public string Godzina { get; set; }
        public int Miejsca { get; set; } = 50;

      

        public List<int> ZajeteNumeryMiejsc { get; set; } = new();

        public string OpisSeansu =>
    $"{Film.Tytul} - {Godzina} ({ZajeteNumeryMiejsc.Count}/{Miejsca})";

    }
}