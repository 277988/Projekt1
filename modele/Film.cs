namespace KinoWinForms.modele
{
    public class Film
    {
        public string Tytul { get; set; }
        public int Rok { get; set; }
        public string Gatunek { get; set; }
        public int CzasTrwania { get; set; }
        public string Opis { get; set; }
        public string SciezkaPlakatu { get; set; }
        public decimal CenaPodstawowa { get; set; } 


        public override string ToString() => Tytul;
    }
}