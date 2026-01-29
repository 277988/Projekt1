using KinoWinForms.modele;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KinoWinForms
{
    public partial class SeansForm : Form
    {
        public Seans NowySeans { get; private set; }

        public SeansForm(List<Film> filmy)
        {
            InitializeComponent();

            comboFilmy.DataSource = filmy;
            comboFilmy.DisplayMember = "Tytul";

            comboGodzina.Items.AddRange(new object[]
            {
                "10:00","12:30","15:00","17:30","20:00","22:30"
            });

            comboGodzina.SelectedIndex = 0;
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            if (comboFilmy.SelectedItem == null)
            {
                MessageBox.Show("Wybierz film!");
                return;
            }

            NowySeans = new Seans
            {
                Film = (Film)comboFilmy.SelectedItem,
                Godzina = comboGodzina.Text,
                Miejsca = (int)numericMiejsca.Value
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}