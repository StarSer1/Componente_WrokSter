namespace WrokSter
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.radialgauge4 = new Radialgauge.Radialgauge();
            this.radialgauge3 = new Radialgauge.Radialgauge();
            this.radialgauge2 = new Radialgauge.Radialgauge();
            this.radialgauge1 = new Radialgauge.Radialgauge();
            this.SuspendLayout();
            // 
            // radialgauge4
            // 
            this.radialgauge4.AnchoDelPerimetro = 30;
            this.radialgauge4.ColorDeLineaCentral = System.Drawing.Color.LightSeaGreen;
            this.radialgauge4.ColorDelPerimetro = System.Drawing.Color.Teal;
            this.radialgauge4.ColorDelPuntoCentral = System.Drawing.Color.DarkSlateGray;
            this.radialgauge4.Estilo = Radialgauge.RadialGaugeStyle.Estilo1;
            this.radialgauge4.EstiloDeLineaCentral = Radialgauge.Radialgauge.CentralLineStyle.Triangular;
            this.radialgauge4.EstiloDelPerimetro = System.Drawing.Drawing2D.DashStyle.Custom;
            this.radialgauge4.GrosorDeLineaCentral = 6;
            this.radialgauge4.Location = new System.Drawing.Point(222, 340);
            this.radialgauge4.Name = "radialgauge4";
            this.radialgauge4.Size = new System.Drawing.Size(219, 219);
            this.radialgauge4.TabIndex = 3;
            this.radialgauge4.Text = "radialgauge4";
            this.radialgauge4.Value = 100;
            // 
            // radialgauge3
            // 
            this.radialgauge3.AnchoDelPerimetro = 30;
            this.radialgauge3.ColorDeFondo = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(16)))), ((int)(((byte)(43)))));
            this.radialgauge3.ColorDeLineaCentral = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(196)))), ((int)(((byte)(244)))));
            this.radialgauge3.ColorDelPerimetro = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(141)))), ((int)(((byte)(184)))));
            this.radialgauge3.ColorDelPuntoCentral = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.radialgauge3.Estilo = Radialgauge.RadialGaugeStyle.llantaxd;
            this.radialgauge3.EstiloDeLineaCentral = Radialgauge.Radialgauge.CentralLineStyle.Triangular;
            this.radialgauge3.EstiloDelPerimetro = System.Drawing.Drawing2D.DashStyle.Dash;
            this.radialgauge3.GrosorDeLineaCentral = 5;
            this.radialgauge3.IntervaloAnimacion = 12;
            this.radialgauge3.Location = new System.Drawing.Point(403, 34);
            this.radialgauge3.MaxValue = 1000;
            this.radialgauge3.Name = "radialgauge3";
            this.radialgauge3.PuntoCentral = 10;
            this.radialgauge3.Size = new System.Drawing.Size(252, 252);
            this.radialgauge3.TabIndex = 2;
            this.radialgauge3.Text = "radialgauge3";
            this.radialgauge3.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(16)))), ((int)(((byte)(43)))));
            this.radialgauge3.Value = 999;
            // 
            // radialgauge2
            // 
            this.radialgauge2.AnchoDelPerimetro = 5;
            this.radialgauge2.ColorDeFondo = System.Drawing.Color.Black;
            this.radialgauge2.ColorDeLineaCentral = System.Drawing.Color.MediumOrchid;
            this.radialgauge2.ColorDelPerimetro = System.Drawing.Color.RoyalBlue;
            this.radialgauge2.ColorDelPuntoCentral = System.Drawing.Color.MediumSlateBlue;
            this.radialgauge2.GrosorDeLineaCentral = 5;
            this.radialgauge2.Location = new System.Drawing.Point(60, 34);
            this.radialgauge2.Name = "radialgauge2";
            this.radialgauge2.PuntoCentral = 4;
            this.radialgauge2.Size = new System.Drawing.Size(236, 236);
            this.radialgauge2.TabIndex = 1;
            this.radialgauge2.Text = "radialgauge2";
            this.radialgauge2.Value = 50;
            // 
            // radialgauge1
            // 
            this.radialgauge1.AnchoDelPerimetro = 5;
            this.radialgauge1.ColorDeFondo = System.Drawing.Color.Black;
            this.radialgauge1.ColorDeLineaCentral = System.Drawing.Color.MediumOrchid;
            this.radialgauge1.ColorDelPerimetro = System.Drawing.Color.RoyalBlue;
            this.radialgauge1.ColorDelPuntoCentral = System.Drawing.Color.MediumSlateBlue;
            this.radialgauge1.GrosorDeLineaCentral = 5;
            this.radialgauge1.Location = new System.Drawing.Point(0, 0);
            this.radialgauge1.Name = "radialgauge1";
            this.radialgauge1.PuntoCentral = 4;
            this.radialgauge1.Size = new System.Drawing.Size(0, 0);
            this.radialgauge1.TabIndex = 0;
            this.radialgauge1.TextColor = System.Drawing.Color.Empty;
            this.radialgauge1.Value = 88;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 530);
            this.Controls.Add(this.radialgauge4);
            this.Controls.Add(this.radialgauge3);
            this.Controls.Add(this.radialgauge2);
            this.Controls.Add(this.radialgauge1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Radialgauge.Radialgauge radialgauge1;
        private Radialgauge.Radialgauge radialgauge2;
        private Radialgauge.Radialgauge radialgauge3;
        private Radialgauge.Radialgauge radialgauge4;
    }
}

