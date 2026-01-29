using KinoWinForms.modele;

namespace KinoWinForms
{
    partial class SeansForm
    {
        private System.ComponentModel.IContainer components = null;

        private ComboBox comboFilmy;
        private ComboBox comboGodzina;
        private DateTimePicker dateData;
        private NumericUpDown numericSala;
        private NumericUpDown numericMiejsca;
        private Button buttonZapisz;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            comboFilmy = new ComboBox();
            comboGodzina = new ComboBox();
            dateData = new DateTimePicker();
            numericSala = new NumericUpDown();
            numericMiejsca = new NumericUpDown();
            buttonZapisz = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericSala).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMiejsca).BeginInit();
            SuspendLayout();
            
            comboFilmy.Location = new Point(120, 20);
            comboFilmy.Name = "comboFilmy";
            comboFilmy.Size = new Size(200, 28);
            comboFilmy.TabIndex = 0;

                        comboGodzina.Location = new Point(120, 100);
            comboGodzina.Name = "comboGodzina";
            comboGodzina.Size = new Size(200, 28);
            comboGodzina.TabIndex = 1;

            dateData.Location = new Point(120, 60);
            dateData.Name = "dateData";
            dateData.Size = new Size(200, 27);
            dateData.TabIndex = 2;
            
            numericSala.Location = new Point(120, 140);
            numericSala.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericSala.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericSala.Name = "numericSala";
            numericSala.Size = new Size(120, 27);
            numericSala.TabIndex = 3;
            numericSala.Value = new decimal(new int[] { 1, 0, 0, 0 });
            
            numericMiejsca.Location = new Point(120, 180);
            numericMiejsca.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numericMiejsca.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numericMiejsca.Name = "numericMiejsca";
            numericMiejsca.Size = new Size(120, 27);
            numericMiejsca.TabIndex = 4;
            numericMiejsca.Value = new decimal(new int[] { 50, 0, 0, 0 });
            
            buttonZapisz.Location = new Point(120, 230);
            buttonZapisz.Name = "buttonZapisz";
            buttonZapisz.Size = new Size(91, 30);
            buttonZapisz.TabIndex = 5;
            buttonZapisz.Text = "Zapisz";
            buttonZapisz.Click += buttonZapisz_Click;
             
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 6;
            label1.Text = "Film:";
            
            label2.Location = new Point(20, 60);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 7;
            label2.Text = "Data:";
             
            label3.Location = new Point(20, 100);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 8;
            label3.Text = "Godzina:";
            
            label4.Location = new Point(20, 140);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 9;
            label4.Text = "Sala:";
            
            label5.Location = new Point(20, 180);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 10;
            label5.Text = "Miejsca:";
             
            ClientSize = new Size(505, 466);
            Controls.Add(comboFilmy);
            Controls.Add(comboGodzina);
            Controls.Add(dateData);
            Controls.Add(numericSala);
            Controls.Add(numericMiejsca);
            Controls.Add(buttonZapisz);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Name = "SeansForm";
            Text = "Dodaj seans";
            ((System.ComponentModel.ISupportInitialize)numericSala).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMiejsca).EndInit();
            ResumeLayout(false);
            

        }
    }
}