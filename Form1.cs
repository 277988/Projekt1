using KinoWinForms.modele;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace KinoWinForms
{
    public partial class Form1 : Form
    {
        List<Film> filmy = new();
        List<Seans> seanse = new();
        List<Rezerwacja> rezerwacje = new();

        Dictionary<int, string> wybraneMiejsca = new();

        Chart chartStatystyki;
        Label labelWybrane;
        Label labelCena;
        Label labelMiejsca;

        Button buttonRezerwacja;
        string connStr = "server=127.0.0.1;port=3306;user=48727;password=12345;database=kino;";

        Dictionary<string, decimal> ceny = new()
        {
            { "Normalny", 25 },
            { "Ulgowy", 18 },
            { "VIP", 40 }
        };

        public Form1()
        {
            InitializeComponent();

            
            this.Load += Form1_Load;
            buttonUsunRezerwacje.Click += buttonUsunRezerwacje_Click;

            buttonRezerwacja = new Button();

            panelSala.AutoScroll = true;
            InicjalizujWykres();
            InicjalizujDolneLabelki();
            OdswiezWykres();

            LoadDataFromDatabase(); 
            OdswiezFilmy();
            OdswiezSeanse();
            OdswiezRezerwacje();
        }

        
        protected override void OnPaint(PaintEventArgs e)
        {
            var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                ClientRectangle,
                Color.FromArgb(20, 20, 40),
                Color.FromArgb(0, 90, 160),
                45f);

            e.Graphics.FillRectangle(brush, ClientRectangle);
        }

        
        void InicjalizujWykres()
        {
            chartStatystyki = new Chart();
            chartStatystyki.Dock = DockStyle.Fill;
            panelStatystyki.Controls.Add(chartStatystyki);
            OdswiezWykres();
        }

        void OdswiezWykres()
        {
            chartStatystyki.Series.Clear();
            chartStatystyki.ChartAreas.Clear();

            ChartArea area = new ChartArea("main");
            chartStatystyki.ChartAreas.Add(area);

            Series series = new Series("Statystyki");
            series.ChartType = SeriesChartType.Column;

            series.Points.AddXY("Filmy", filmy.Count);
            series.Points.AddXY("Seanse", seanse.Count);
            series.Points.AddXY("Rezerwacje", rezerwacje.Count);
            series.Points.AddXY("Bilety", rezerwacje.Sum(r => r.IloscBiletow));

            chartStatystyki.Series.Add(series);

            chartStatystyki.Invalidate(); 
        }

        
        void OdswiezFilmy()
        {
            listBoxFilmy.DataSource = null;
            listBoxFilmy.DataSource = filmy;
            listBoxFilmy.DisplayMember = "Tytul";
            OdswiezWykres();
        }

        private void buttonDodajFilm_Click(object sender, EventArgs e)
        {
            var f = new DodajFilmForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                filmy.Add(f.NowyFilm);
                AddFilmToDatabase(f.NowyFilm); 
                OdswiezFilmy();
            }
        }

        private void buttonUsun_Click(object sender, EventArgs e)
        {
            if (listBoxFilmy.SelectedItem is not Film f) return;

            DeleteFilmFromDatabase(f); 

            filmy.Remove(f);
            seanse.RemoveAll(s => s.Film == f);
            rezerwacje.RemoveAll(r => r.Seans.Film == f);

            pictureBoxPlakat.Image = null;

            OdswiezFilmy();
            OdswiezSeanse();
            OdswiezRezerwacje();
            panelSala.Controls.Clear();
            labelSzczegoly.Text = "";
        }

        private void listBoxFilmy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFilmy.SelectedItem is not Film f) return;

            labelSzczegoly.Text =
$@"Tytu³: {f.Tytul}
Rok: {f.Rok}
Gatunek: {f.Gatunek}
Czas: {f.CzasTrwania} min

Opis: {f.Opis}";

            if (!string.IsNullOrEmpty(f.SciezkaPlakatu) &&
                System.IO.File.Exists(f.SciezkaPlakatu))
            {
                pictureBoxPlakat.Image = Image.FromFile(f.SciezkaPlakatu);
            }
        }

        void OdswiezSeanse()
        {
            listBoxSeanse.DataSource = null;
            listBoxSeanse.DataSource = seanse.Select(s => s.OpisSeansu).ToList();
            OdswiezWykres();
        }

        private void buttonDodajSeans_Click(object sender, EventArgs e)
        {
            var f = new SeansForm(filmy);
            if (f.ShowDialog() == DialogResult.OK)
            {
                seanse.Add(f.NowySeans);
                AddSeansToDatabase(f.NowySeans); 
                OdswiezSeanse();
                OdswiezWykres();
            }
        }

        private void buttonUsunSeans_Click(object sender, EventArgs e)
        {
            if (listBoxSeanse.SelectedIndex < 0) return;

            var s = seanse[listBoxSeanse.SelectedIndex];
            DeleteSeansFromDatabase(s); 
            seanse.Remove(s);
            rezerwacje.RemoveAll(r => r.Seans == s);

            OdswiezSeanse();
            OdswiezRezerwacje();
            panelSala.Controls.Clear();
            OdswiezWykres();
        }

        private void listBoxSeanse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSeanse.SelectedIndex >= 0)
                PokazSale(seanse[listBoxSeanse.SelectedIndex]);
        }

        
        void PokazSale(Seans seans)
        {
            panelSala.Controls.Clear();
            wybraneMiejsca.Clear();

            Label ekran = new Label()
            {
                Text = "EKRAN",
                Dock = DockStyle.Top,
                Height = 35,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelSala.Controls.Add(ekran);

            int size = 40;
            int gap = 8;
            int startX = 170;
            int startY = 60;

            char[] rzedy = { 'A', 'B', 'C', 'D', 'E' };

            int numer = 1;

            for (int row = 0; row < 5; row++)
            {
                panelSala.Controls.Add(new Label()
                {
                    Text = rzedy[row].ToString(),
                    Left = 70,
                    Top = startY + row * (size + gap) + 10
                });

                for (int col = 0; col < 10; col++)
                {
                    int nr = numer++;

                    Button b = new Button();
                    b.Width = size;
                    b.Height = size;
                    b.Left = startX + col * (size + gap);
                    b.Top = startY + row * (size + gap);
                    b.Text = nr.ToString();

                    b.BackColor = seans.ZajeteNumeryMiejsc.Contains(nr)
                        ? Color.Red
                        : Color.Green;

                    b.Click += (s, e) =>
                    {
                        if (seans.ZajeteNumeryMiejsc.Contains(nr)) return;

                        if (wybraneMiejsca.ContainsKey(nr))
                        {
                            wybraneMiejsca.Remove(nr);
                            b.BackColor = Color.Green;
                        }
                        else
                        {
                            string typ = WybierzTyp();
                            if (typ == null) return;

                            wybraneMiejsca[nr] = typ;
                            b.BackColor = Color.Blue;
                        }

                        OdswiezDol();
                    };

                    panelSala.Controls.Add(b);
                }
            }

            OdswiezDol();
        }

        
        string WybierzTyp()
        {
            Form f = new Form();
            f.Text = "Typ biletu";
            f.Size = new Size(200, 140);

            ComboBox c = new ComboBox();
            c.Items.AddRange(new string[] { "Normalny", "Ulgowy", "VIP" });
            c.SelectedIndex = 0;
            c.Dock = DockStyle.Top;

            Button ok = new Button();
            ok.Text = "OK";
            ok.Dock = DockStyle.Bottom;
            ok.DialogResult = DialogResult.OK;

            f.Controls.Add(c);
            f.Controls.Add(ok);

            return f.ShowDialog() == DialogResult.OK ? c.Text : null;
        }

        void OdswiezDol()
        {
            labelWybrane.Text = $"Wybrane: {wybraneMiejsca.Count}";

            decimal suma = wybraneMiejsca.Values.Sum(t => ceny[t]);

            labelCena.Text = $"Cena: {suma} z³";
            AktualizujLicznikMiejsc();
        }

        
        void AktualizujLicznikMiejsc()
        {
            int zajeteMiejsca = rezerwacje.Sum(r => r.IloscBiletow);

            labelMiejsca.Text = $"{zajeteMiejsca}/50";
        }

        
        private void buttonRezerwacja_Click(object sender, EventArgs e)
        {
            if (listBoxSeanse.SelectedIndex < 0) return;
            if (wybraneMiejsca.Count == 0)
            {
                MessageBox.Show("Wybierz miejsca!");
                return;
            }

            var s = seanse[listBoxSeanse.SelectedIndex];

            decimal cena = wybraneMiejsca.Sum(x => ceny[x.Value]);

            Rezerwacja r = new Rezerwacja
            {
                Imie = "Klient",
                Seans = s,
                IloscBiletow = wybraneMiejsca.Count,
                NumeryMiejsc = wybraneMiejsca.Keys.ToList(),
                Cena = cena
            };

            foreach (var m in r.NumeryMiejsc)
                s.ZajeteNumeryMiejsc.Add(m);

            rezerwacje.Add(r);
            wybraneMiejsca.Clear();

            AddRezerwacjaToDatabase(r); 

            OdswiezRezerwacje();
            OdswiezSeanse();
            PokazSale(s);
            OdswiezWykres();
            AktualizujLicznikMiejsc();
        }

        void OdswiezRezerwacje()
        {
            listBoxRezerwacje.DataSource = null;
            listBoxRezerwacje.DataSource =
                rezerwacje.Select(r => $"{r.Imie} | {r.Seans.OpisSeansu} | {r.IloscBiletow} miejsc | {r.Cena} z³")
                .ToList();

            OdswiezWykres();
        }

        
        void AddFilmToDatabase(Film f)
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            var cmd = new MySqlCommand(
                "INSERT INTO Filmy (Tytul,Rok,Gatunek,CzasTrwania,Opis,SciezkaPlakatu) VALUES (@t,@r,@g,@c,@o,@s);",
                conn);
            cmd.Parameters.AddWithValue("@t", f.Tytul);
            cmd.Parameters.AddWithValue("@r", f.Rok);
            cmd.Parameters.AddWithValue("@g", f.Gatunek);
            cmd.Parameters.AddWithValue("@c", f.CzasTrwania);
            cmd.Parameters.AddWithValue("@o", f.Opis);
            cmd.Parameters.AddWithValue("@s", f.SciezkaPlakatu);
            cmd.ExecuteNonQuery();
        }

        void DeleteFilmFromDatabase(Film f)
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            var cmd = new MySqlCommand(
                "DELETE FROM Filmy WHERE Tytul=@t;",
                conn);
            cmd.Parameters.AddWithValue("@t", f.Tytul);
            cmd.ExecuteNonQuery();
        }

        void AddSeansToDatabase(Seans s)
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            var cmdFilm = new MySqlCommand("SELECT Id FROM Filmy WHERE Tytul=@t;", conn);
            cmdFilm.Parameters.AddWithValue("@t", s.Film.Tytul);
            int filmId = Convert.ToInt32(cmdFilm.ExecuteScalar());

            var cmd = new MySqlCommand("INSERT INTO Seanse (FilmId, Godzina) VALUES (@f,@g);", conn);
            cmd.Parameters.AddWithValue("@f", filmId);
            cmd.Parameters.AddWithValue("@g", s.Godzina);
            cmd.ExecuteNonQuery();
        }

        void DeleteSeansFromDatabase(Seans s)
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            var cmd = new MySqlCommand(
                "DELETE s FROM Seanse s JOIN Filmy f ON s.FilmId = f.Id WHERE f.Tytul=@t AND s.Godzina=@g;",
                conn);
            cmd.Parameters.AddWithValue("@t", s.Film.Tytul);
            cmd.Parameters.AddWithValue("@g", s.Godzina);
            cmd.ExecuteNonQuery();
        }

        void AddRezerwacjaToDatabase(Rezerwacja r)
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            var cmdSeans = new MySqlCommand(
                "SELECT s.Id FROM Seanse s JOIN Filmy f ON s.FilmId=f.Id WHERE f.Tytul=@t AND s.Godzina=@g;",
                conn);
            cmdSeans.Parameters.AddWithValue("@t", r.Seans.Film.Tytul);
            cmdSeans.Parameters.AddWithValue("@g", r.Seans.Godzina);
            int seansId = Convert.ToInt32(cmdSeans.ExecuteScalar());

            var cmd = new MySqlCommand("INSERT INTO Rezerwacje (SeansId, Imie, IloscBiletow, Cena) VALUES (@s,@i,@b,@c);", conn);
            cmd.Parameters.AddWithValue("@s", seansId);
            cmd.Parameters.AddWithValue("@i", r.Imie);
            cmd.Parameters.AddWithValue("@b", r.IloscBiletow);
            cmd.Parameters.AddWithValue("@c", r.Cena);
            cmd.ExecuteNonQuery();

            int rezerwacjaId = (int)cmd.LastInsertedId;

            foreach (var m in r.NumeryMiejsc)
            {
                var cmdM = new MySqlCommand("INSERT INTO Miejsca (RezerwacjaId, NumerMiejsca, TypBiletu) VALUES (@r,@n,@t);", conn);
                cmdM.Parameters.AddWithValue("@r", rezerwacjaId);
                cmdM.Parameters.AddWithValue("@n", m);
                cmdM.Parameters.AddWithValue("@t", r.Seans.Film.Tytul); 
                cmdM.ExecuteNonQuery();
            }
        }

        void DeleteRezerwacjaFromDatabase(Rezerwacja r)
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            var cmd = new MySqlCommand(
                "DELETE FROM Rezerwacje WHERE Imie=@i AND Cena=@c LIMIT 1;",
                conn);
            cmd.Parameters.AddWithValue("@i", r.Imie);
            cmd.Parameters.AddWithValue("@c", r.Cena);
            cmd.ExecuteNonQuery();
        }

        void LoadDataFromDatabase()
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            
            var cmdFilmy = new MySqlCommand("SELECT * FROM Filmy;", conn);
            using var reader = cmdFilmy.ExecuteReader();
            filmy.Clear();
            while (reader.Read())
            {
                filmy.Add(new Film
                {
                    Tytul = reader["Tytul"].ToString(),
                    Rok = Convert.ToInt32(reader["Rok"]),
                    Gatunek = reader["Gatunek"].ToString(),
                    CzasTrwania = Convert.ToInt32(reader["CzasTrwania"]),
                    Opis = reader["Opis"].ToString(),
                    SciezkaPlakatu = reader["SciezkaPlakatu"].ToString()
                });
            }
            reader.Close();

            
            var cmdSeanse = new MySqlCommand("SELECT s.Id, s.FilmId, s.Godzina, f.Tytul FROM Seanse s JOIN Filmy f ON s.FilmId=f.Id;", conn);
            using var readerSeans = cmdSeanse.ExecuteReader();
            seanse.Clear();
            var seansDict = new Dictionary<int, Seans>();
            while (readerSeans.Read())
            {
                int seansId = Convert.ToInt32(readerSeans["Id"]);
                var film = filmy.FirstOrDefault(f => f.Tytul == readerSeans["Tytul"].ToString());
                if (film != null)
                {
                    var s = new Seans
                    {
                        Film = film,
                        Godzina = readerSeans["Godzina"].ToString(),
                        ZajeteNumeryMiejsc = new List<int>()
                    };
                    seanse.Add(s);
                    seansDict[seansId] = s;
                }
            }
            readerSeans.Close();

           
            var cmdRezerwacje = new MySqlCommand(@"
                SELECT r.Id, r.SeansId, r.Imie, r.IloscBiletow, r.Cena, m.NumerMiejsca, m.TypBiletu
                FROM Rezerwacje r
                LEFT JOIN Miejsca m ON r.Id = m.RezerwacjaId
                ORDER BY r.Id;", conn);
            using var readerR = cmdRezerwacje.ExecuteReader();
            rezerwacje.Clear();
            var rezerwacjaDict = new Dictionary<int, Rezerwacja>();

            while (readerR.Read())
            {
                int rId = Convert.ToInt32(readerR["Id"]);
                if (!rezerwacjaDict.ContainsKey(rId))
                {
                    int seansId = Convert.ToInt32(readerR["SeansId"]);
                    var seans = seansDict[seansId];
                    var r = new Rezerwacja
                    {
                        Imie = readerR["Imie"].ToString(),
                        Seans = seans,
                        IloscBiletow = Convert.ToInt32(readerR["IloscBiletow"]),
                        Cena = Convert.ToDecimal(readerR["Cena"]),
                        NumeryMiejsc = new List<int>()
                    };
                    rezerwacje.Add(r);
                    rezerwacjaDict[rId] = r;
                }
                if (readerR["NumerMiejsca"] != DBNull.Value)
                {
                    int numer = Convert.ToInt32(readerR["NumerMiejsca"]);
                    rezerwacjaDict[rId].NumeryMiejsc.Add(numer);
                    rezerwacjaDict[rId].Seans.ZajeteNumeryMiejsc.Add(numer);
                }
            }
        }

        
        void InicjalizujDolneLabelki()
        {
            labelWybrane = new Label();
            labelWybrane.ForeColor = Color.White;
            labelWybrane.Left = panelSala.Left;
            labelWybrane.Top = panelSala.Bottom + 10;
            labelWybrane.Text = "Wybrane: 0";

            labelCena = new Label();
            labelCena.ForeColor = Color.White;
            labelCena.Left = panelSala.Left + 150;
            labelCena.Top = panelSala.Bottom + 10;
            labelCena.Text = "Cena: 0 z³";

            labelMiejsca = new Label();
            labelMiejsca.ForeColor = Color.White;
            labelMiejsca.Left = panelSala.Left + 300;
            labelMiejsca.Top = panelSala.Bottom + 10;
            labelMiejsca.Text = "0/50";

            Controls.Add(labelWybrane);
            Controls.Add(labelCena);
            Controls.Add(labelMiejsca);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            OdswiezFilmy();
            OdswiezSeanse();
            OdswiezRezerwacje();
        }
         
        private void buttonUsunRezerwacje_Click(object sender, EventArgs e)
        {
            if (listBoxRezerwacje.SelectedIndex < 0) return; 

            var r = rezerwacje[listBoxRezerwacje.SelectedIndex];

            DeleteRezerwacjaFromDatabase(r); 

            foreach (var m in r.NumeryMiejsc)
                r.Seans.ZajeteNumeryMiejsc.Remove(m);

            rezerwacje.Remove(r);
            OdswiezRezerwacje();
            PokazSale(r.Seans);
            OdswiezSeanse();
            OdswiezWykres();
            AktualizujLicznikMiejsc();
        }
    }
}