using KinoWinForms.modele;

namespace KinoWinForms
{
    public partial class DodajFilmForm : Form
    {
        public Film NowyFilm { get; private set; }

        private string wybranyPlakat = null;

        public DodajFilmForm()
        {
            InitializeComponent();
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            try
            {
                NowyFilm = new Film
                {
                    Tytul = textTytul.Text,
                    Gatunek = textGatunek.Text,
                    Rok = int.Parse(textRok.Text),
                    CzasTrwania = int.Parse(textCzas.Text),
                    Opis = textOpis.Text,
                    SciezkaPlakatu = wybranyPlakat
                };

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonWybierzPlakat_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pliki graficzne|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                wybranyPlakat = dialog.FileName;

                picturePlakat.Image = Image.FromFile(wybranyPlakat);
                picturePlakat.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}