using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KinoWinForms.modele;

namespace KinoWinForms
{
    public partial class RezerwacjaForm : Form
    {
        public string Imie { get; private set; }

        public RezerwacjaForm(List<Seans> seanse)
        {
            InitializeComponent();

            comboSeanse.DataSource = seanse;
            comboSeanse.DisplayMember = "OpisSeansu";

            buttonZarezerwuj.Click += ButtonZarezerwuj_Click;
        }

        private void ButtonZarezerwuj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textImie.Text))
            {
                MessageBox.Show("Podaj imię!");
                return;
            }

            Imie = textImie.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}