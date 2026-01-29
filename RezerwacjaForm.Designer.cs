namespace KinoWinForms
{
    partial class RezerwacjaForm
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
            this.comboSeanse = new System.Windows.Forms.ComboBox();
            this.numericBilety = new System.Windows.Forms.NumericUpDown();
            this.buttonZarezerwuj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textImie = new System.Windows.Forms.TextBox();

            ((System.ComponentModel.ISupportInitialize)(this.numericBilety)).BeginInit();
            this.SuspendLayout();

            
            this.comboSeanse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSeanse.Location = new System.Drawing.Point(30, 40);
            this.comboSeanse.Size = new System.Drawing.Size(250, 23);

            
            this.label1.Text = "Wybierz seans:";
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.AutoSize = true;

            
            this.textImie.Location = new System.Drawing.Point(30, 95);
            this.textImie.Size = new System.Drawing.Size(200, 23);

            
            this.label3.Text = "Imię:";
            this.label3.Location = new System.Drawing.Point(30, 75);
            this.label3.AutoSize = true;

            
            this.numericBilety.Location = new System.Drawing.Point(30, 145);
            this.numericBilety.Minimum = 1;
            this.numericBilety.Value = 1;

            
            this.label2.Text = "Liczba biletów:";
            this.label2.Location = new System.Drawing.Point(30, 125);
            this.label2.AutoSize = true;

            this.buttonZarezerwuj.Location = new System.Drawing.Point(30, 190);
            this.buttonZarezerwuj.Size = new System.Drawing.Size(120, 30);
            this.buttonZarezerwuj.Text = "Zarezerwuj";

            
            this.ClientSize = new System.Drawing.Size(320, 250);
            this.Controls.Add(this.comboSeanse);
            this.Controls.Add(this.textImie);
            this.Controls.Add(this.numericBilety);
            this.Controls.Add(this.buttonZarezerwuj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Text = "Rezerwacja";

            ((System.ComponentModel.ISupportInitialize)(this.numericBilety)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboSeanse;
        private System.Windows.Forms.NumericUpDown numericBilety;
        private System.Windows.Forms.Button buttonZarezerwuj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textImie;
    }
}