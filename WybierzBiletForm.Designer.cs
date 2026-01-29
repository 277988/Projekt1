namespace KinoWinForms
{
    partial class WybierzBiletForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBilety;
        private Button buttonOK;
        private Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            comboBilety = new ComboBox();
            buttonOK = new Button();
            label1 = new Label();
            SuspendLayout();

            label1.Text = "Wybierz rodzaj biletu:";
            label1.Location = new System.Drawing.Point(20, 20);
            label1.AutoSize = true;

            comboBilety.Location = new System.Drawing.Point(20, 50);
            comboBilety.Size = new System.Drawing.Size(200, 23);

            buttonOK.Text = "OK";
            buttonOK.Location = new System.Drawing.Point(20, 90);
            buttonOK.Click += buttonOK_Click;

            ClientSize = new System.Drawing.Size(250, 150);
            Controls.Add(label1);
            Controls.Add(comboBilety);
            Controls.Add(buttonOK);
            Text = "Bilet";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}