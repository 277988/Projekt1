namespace KinoWinForms
{
    partial class DodajFilmForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelTytul = new Label();
            labelGatunek = new Label();
            labelRok = new Label();
            labelCzas = new Label();
            labelOpis = new Label();
            textTytul = new TextBox();
            textGatunek = new TextBox();
            textRok = new TextBox();
            textCzas = new TextBox();
            textOpis = new TextBox();
            buttonZapisz = new Button();
            buttonAnuluj = new Button();
            picturePlakat = new PictureBox();
            buttonWybierzPlakat = new Button();

            ((System.ComponentModel.ISupportInitialize)picturePlakat).BeginInit();
            SuspendLayout();

            
            labelTytul.AutoSize = true;
            labelTytul.Location = new Point(12, 30);
            labelTytul.Name = "labelTytul";
            labelTytul.Size = new Size(40, 20);
            labelTytul.TabIndex = 0;
            labelTytul.Text = "Tytuł";

             
            labelGatunek.AutoSize = true;
            labelGatunek.Location = new Point(12, 70);
            labelGatunek.Name = "labelGatunek";
            labelGatunek.Size = new Size(63, 20);
            labelGatunek.TabIndex = 1;
            labelGatunek.Text = "Gatunek";

            
            labelRok.AutoSize = true;
            labelRok.Location = new Point(12, 110);
            labelRok.Name = "labelRok";
            labelRok.Size = new Size(34, 20);
            labelRok.TabIndex = 2;
            labelRok.Text = "Rok";

             
            labelCzas.AutoSize = true;
            labelCzas.Location = new Point(12, 150);
            labelCzas.Name = "labelCzas";
            labelCzas.Size = new Size(131, 20);
            labelCzas.TabIndex = 3;
            labelCzas.Text = "Czas trwania (min)";

             
            labelOpis.AutoSize = true;
            labelOpis.Location = new Point(12, 190);
            labelOpis.Name = "labelOpis";
            labelOpis.Size = new Size(39, 20);
            labelOpis.TabIndex = 4;
            labelOpis.Text = "Opis";

            
            textTytul.Location = new Point(150, 27);
            textTytul.Name = "textTytul";
            textTytul.Size = new Size(200, 27);
            textTytul.TabIndex = 5;

             
            textGatunek.Location = new Point(150, 67);
            textGatunek.Name = "textGatunek";
            textGatunek.Size = new Size(200, 27);
            textGatunek.TabIndex = 6;

             
            textRok.Location = new Point(150, 107);
            textRok.Name = "textRok";
            textRok.Size = new Size(200, 27);
            textRok.TabIndex = 7;

             
            textCzas.Location = new Point(150, 147);
            textCzas.Name = "textCzas";
            textCzas.Size = new Size(200, 27);
            textCzas.TabIndex = 8;

             
            textOpis.Location = new Point(150, 187);
            textOpis.Name = "textOpis";
            textOpis.Size = new Size(200, 27);
            textOpis.TabIndex = 9;

             
            picturePlakat.BorderStyle = BorderStyle.FixedSingle;
            picturePlakat.Location = new Point(380, 27);
            picturePlakat.Name = "picturePlakat";
            picturePlakat.Size = new Size(160, 220);
            picturePlakat.SizeMode = PictureBoxSizeMode.StretchImage;
            picturePlakat.TabIndex = 10;
            picturePlakat.TabStop = false;

             
            buttonWybierzPlakat.Location = new Point(380, 260);
            buttonWybierzPlakat.Name = "buttonWybierzPlakat";
            buttonWybierzPlakat.Size = new Size(160, 35);
            buttonWybierzPlakat.TabIndex = 11;
            buttonWybierzPlakat.Text = "Wybierz plakat";
            buttonWybierzPlakat.Click += buttonWybierzPlakat_Click;

             
            buttonZapisz.Location = new Point(30, 260);
            buttonZapisz.Name = "buttonZapisz";
            buttonZapisz.Size = new Size(100, 35);
            buttonZapisz.TabIndex = 12;
            buttonZapisz.Text = "Zapisz";
            buttonZapisz.Click += buttonZapisz_Click;

            
            buttonAnuluj.Location = new Point(150, 260);
            buttonAnuluj.Name = "buttonAnuluj";
            buttonAnuluj.Size = new Size(100, 35);
            buttonAnuluj.TabIndex = 13;
            buttonAnuluj.Text = "Anuluj";
            buttonAnuluj.Click += buttonAnuluj_Click;

             
            ClientSize = new Size(560, 320);
            Controls.Add(labelTytul);
            Controls.Add(textTytul);
            Controls.Add(labelGatunek);
            Controls.Add(textGatunek);
            Controls.Add(labelRok);
            Controls.Add(textRok);
            Controls.Add(labelCzas);
            Controls.Add(textCzas);
            Controls.Add(labelOpis);
            Controls.Add(textOpis);
            Controls.Add(buttonZapisz);
            Controls.Add(buttonAnuluj);
            Controls.Add(picturePlakat);
            Controls.Add(buttonWybierzPlakat);
            Name = "DodajFilmForm";
            Text = "Dodaj film";

            ((System.ComponentModel.ISupportInitialize)picturePlakat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTytul;
        private Label labelGatunek;
        private Label labelRok;
        private Label labelCzas;
        private Label labelOpis;
        private TextBox textTytul;
        private TextBox textGatunek;
        private TextBox textRok;
        private TextBox textCzas;
        private TextBox textOpis;
        private Button buttonZapisz;
        private Button buttonAnuluj;
        private PictureBox picturePlakat;
        private Button buttonWybierzPlakat;
    }
}