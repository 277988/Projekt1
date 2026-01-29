using System.Drawing;
using System.Windows.Forms;

namespace KinoWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            listBoxFilmy = new ListBox();
            listBoxSeanse = new ListBox();
            listBoxRezerwacje = new ListBox();
            buttonDodajFilm = new Button();
            buttonUsun = new Button();
            buttonDodajSeans = new Button();
            buttonUsunSeans = new Button();
            buttonRezerwuj = new Button();
            buttonUsunRezerwacje = new Button();
            labelLista = new Label();
            labelSzczegoly = new Label();
            labelSeanse = new Label();
            labelRezerwacje = new Label();
            pictureBoxPlakat = new PictureBox();
            panelStatystyki = new Panel();
            panelSala = new Panel();
            panelCennik = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlakat).BeginInit();
            panelCennik.SuspendLayout();
            SuspendLayout();
             
            listBoxFilmy.Location = new Point(0, 0);
            listBoxFilmy.Name = "listBoxFilmy";
            listBoxFilmy.Size = new Size(250, 184);
            listBoxFilmy.TabIndex = 0;
            listBoxFilmy.SelectedIndexChanged += listBoxFilmy_SelectedIndexChanged;
            
            listBoxSeanse.Location = new Point(900, 30);
            listBoxSeanse.Name = "listBoxSeanse";
            listBoxSeanse.Size = new Size(312, 224);
            listBoxSeanse.TabIndex = 7;
            listBoxSeanse.SelectedIndexChanged += listBoxSeanse_SelectedIndexChanged;
           
            listBoxRezerwacje.Location = new Point(900, 320);
            listBoxRezerwacje.Name = "listBoxRezerwacje";
            listBoxRezerwacje.Size = new Size(335, 164);
            listBoxRezerwacje.TabIndex = 11;
             
            buttonDodajFilm.Location = new Point(25, 240);
            buttonDodajFilm.Name = "buttonDodajFilm";
            buttonDodajFilm.Size = new Size(120, 30);
            buttonDodajFilm.TabIndex = 1;
            buttonDodajFilm.Text = "Dodaj film";
            buttonDodajFilm.Click += buttonDodajFilm_Click;
           
            buttonUsun.Location = new Point(155, 240);
            buttonUsun.Name = "buttonUsun";
            buttonUsun.Size = new Size(120, 30);
            buttonUsun.TabIndex = 2;
            buttonUsun.Text = "Usuń film";
            buttonUsun.Click += buttonUsun_Click;
            
            buttonDodajSeans.Location = new Point(900, 255);
            buttonDodajSeans.Name = "buttonDodajSeans";
            buttonDodajSeans.Size = new Size(120, 30);
            buttonDodajSeans.TabIndex = 8;
            buttonDodajSeans.Text = "Dodaj seans";
            buttonDodajSeans.Click += buttonDodajSeans_Click;
            
            buttonUsunSeans.Location = new Point(1026, 255);
            buttonUsunSeans.Name = "buttonUsunSeans";
            buttonUsunSeans.Size = new Size(120, 30);
            buttonUsunSeans.TabIndex = 9;
            buttonUsunSeans.Text = "Usuń seans";
            buttonUsunSeans.Click += buttonUsunSeans_Click;
            
            buttonRezerwuj.Location = new Point(1115, 510);
            buttonRezerwuj.Name = "buttonRezerwuj";
            buttonRezerwuj.Size = new Size(120, 30);
            buttonRezerwuj.TabIndex = 12;
            buttonRezerwuj.Text = "Rezerwuj";
            buttonRezerwuj.Click += buttonRezerwacja_Click;
            
            buttonUsunRezerwacje.Location = new Point(900, 510);
            buttonUsunRezerwacje.Name = "buttonUsunRezerwacje";
            buttonUsunRezerwacje.Size = new Size(193, 30);
            buttonUsunRezerwacje.TabIndex = 13;
            buttonUsunRezerwacje.Text = "Usuń rezerwację";
            buttonUsunRezerwacje.Click += buttonUsunRezerwacje_Click;
            
            labelLista.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelLista.Location = new Point(25, 9);
            labelLista.Name = "labelLista";
            labelLista.Size = new Size(100, 32);
            labelLista.TabIndex = 3;
            labelLista.Text = "Lista filmów";
            labelSzczegoly.Location = new Point(500, 50);
            labelSzczegoly.Name = "labelSzczegoly";
            labelSzczegoly.Size = new Size(350, 258);
            labelSzczegoly.TabIndex = 5;
             
            labelSeanse.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelSeanse.Location = new Point(900, -3);
            labelSeanse.Name = "labelSeanse";
            labelSeanse.Size = new Size(100, 30);
            labelSeanse.TabIndex = 6;
            labelSeanse.Text = "Seanse";
            
            labelRezerwacje.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelRezerwacje.Location = new Point(-119, 289);
            labelRezerwacje.Name = "labelRezerwacje";
            labelRezerwacje.Size = new Size(138, 30);
            labelRezerwacje.TabIndex = 10;
            labelRezerwacje.Text = "Rezerwacje";
             
            pictureBoxPlakat.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxPlakat.Location = new Point(297, 50);
            pictureBoxPlakat.Name = "pictureBoxPlakat";
            pictureBoxPlakat.Size = new Size(180, 258);
            pictureBoxPlakat.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPlakat.TabIndex = 4;
            pictureBoxPlakat.TabStop = false;
             
            panelStatystyki.BackColor = SystemColors.Window;
            panelStatystyki.BorderStyle = BorderStyle.FixedSingle;
            panelStatystyki.Location = new Point(25, 320);
            panelStatystyki.Name = "panelStatystyki";
            panelStatystyki.Size = new Size(600, 263);
            panelStatystyki.TabIndex = 14;
            
            panelSala.BorderStyle = BorderStyle.FixedSingle;
            panelSala.Location = new Point(25, 589);
            panelSala.Name = "panelSala";
            panelSala.Size = new Size(600, 336);
            panelSala.TabIndex = 16;
             
            panelCennik.Controls.Add(listBoxFilmy);
            panelCennik.Location = new Point(25, 50);
            panelCennik.Name = "panelCennik";
            panelCennik.Size = new Size(250, 184);
            panelCennik.TabIndex = 15;
             
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(900, 288);
            label1.Name = "label1";
            label1.Size = new Size(135, 32);
            label1.TabIndex = 17;
            label1.Text = "Rezerwacje";
            
            ClientSize = new Size(1418, 1055);
            Controls.Add(label1);
            Controls.Add(labelLista);
            Controls.Add(buttonDodajFilm);
            Controls.Add(buttonUsun);
            Controls.Add(pictureBoxPlakat);
            Controls.Add(labelSzczegoly);
            Controls.Add(labelSeanse);
            Controls.Add(listBoxSeanse);
            Controls.Add(buttonDodajSeans);
            Controls.Add(buttonUsunSeans);
            Controls.Add(listBoxRezerwacje);
            Controls.Add(buttonRezerwuj);
            Controls.Add(buttonUsunRezerwacje);
            Controls.Add(panelStatystyki);
            Controls.Add(panelCennik);
            Controls.Add(panelSala);
            Name = "Form1";
            Text = "Kino — Zarządzanie Filmami";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlakat).EndInit();
            panelCennik.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxFilmy;
        private Button buttonDodajFilm;
        private Button buttonUsun;
        private Label labelLista;
        private Label labelSzczegoly;
        private PictureBox pictureBoxPlakat;

        private ListBox listBoxSeanse;
        private Button buttonDodajSeans;
        private Button buttonUsunSeans;
        private Label labelSeanse;

        private ListBox listBoxRezerwacje;
        private Button buttonRezerwuj;
        private Button buttonUsunRezerwacje;
        private Label labelRezerwacje;

        private Panel panelStatystyki;
        private Panel panelSala;
        private Panel panelCennik;
        private Label label1;
        private Label Rezerwacje;
    }
}