using KinoWinForms.modele;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KinoWinForms
{
    public partial class WybierzBiletForm : Form
    {
        public Bilet WybranyBilet { get; private set; }

        public WybierzBiletForm(List<Bilet> bilety)
        {
            InitializeComponent();
            comboBilety.DataSource = bilety;
            comboBilety.DisplayMember = "Typ";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            WybranyBilet = comboBilety.SelectedItem as Bilet;
            DialogResult = DialogResult.OK;
        }
    }
}