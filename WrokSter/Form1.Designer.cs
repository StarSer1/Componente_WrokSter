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
            this.radialgauge3 = new Radialgauge.Radialgauge();
            this.radialgauge2 = new Radialgauge.Radialgauge();
            this.radialgauge1 = new Radialgauge.Radialgauge();
            this.radialgauge5 = new Radialgauge.Radialgauge();
            this.SuspendLayout();
            // 
            // radialgauge3
            // 
            this.radialgauge3.AnchoDelPerimetro = 30;
            this.radialgauge3.ColorDeLineaCentral = System.Drawing.Color.LightSeaGreen;
            this.radialgauge3.ColorDelPerimetro = System.Drawing.Color.Teal;
            this.radialgauge3.ColorDelPuntoCentral = System.Drawing.Color.DarkSlateGray;
            this.radialgauge3.Estilo = Radialgauge.RadialGaugeStyle.Estilo1;
            this.radialgauge3.EstiloDeLineaCentral = Radialgauge.Radialgauge.CentralLineStyle.Triangular;
            this.radialgauge3.EstiloDelPerimetro = System.Drawing.Drawing2D.DashStyle.Custom;
            this.radialgauge3.GrosorDeLineaCentral = 6;
            this.radialgauge3.Location = new System.Drawing.Point(358, -3);
            this.radialgauge3.Name = "radialgauge3";
            this.radialgauge3.Size = new System.Drawing.Size(358, 358);
            this.radialgauge3.TabIndex = 2;
            this.radialgauge3.Text = "radialgauge3";
            this.radialgauge3.Value = 100;
            // 
            // radialgauge2
            // 
            this.radialgauge2.AnchoDelPerimetro = 5;
            this.radialgauge2.ColorDeFondo = System.Drawing.Color.Black;
            this.radialgauge2.ColorDeLineaCentral = System.Drawing.Color.MediumOrchid;
            this.radialgauge2.ColorDelPerimetro = System.Drawing.Color.RoyalBlue;
            this.radialgauge2.ColorDelPuntoCentral = System.Drawing.Color.MediumSlateBlue;
            this.radialgauge2.GrosorDeLineaCentral = 5;
            this.radialgauge2.Location = new System.Drawing.Point(-6, -3);
            this.radialgauge2.Name = "radialgauge2";
            this.radialgauge2.PuntoCentral = 4;
            this.radialgauge2.Size = new System.Drawing.Size(358, 358);
            this.radialgauge2.TabIndex = 1;
            this.radialgauge2.Text = "radialgauge2";
            this.radialgauge2.Value = 100;
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
            // radialgauge5
            // 
            this.radialgauge5.AnchoDelPerimetro = 30;
            this.radialgauge5.ColorDeFondo = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(16)))), ((int)(((byte)(43)))));
            this.radialgauge5.ColorDeLineaCentral = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(196)))), ((int)(((byte)(244)))));
            this.radialgauge5.ColorDelPerimetro = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(141)))), ((int)(((byte)(184)))));
            this.radialgauge5.ColorDelPuntoCentral = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.radialgauge5.Estilo = Radialgauge.RadialGaugeStyle.llantaxd;
            this.radialgauge5.EstiloDeLineaCentral = Radialgauge.Radialgauge.CentralLineStyle.Triangular;
            this.radialgauge5.EstiloDelPerimetro = System.Drawing.Drawing2D.DashStyle.Dash;
            this.radialgauge5.GrosorDeLineaCentral = 5;
            this.radialgauge5.Location = new System.Drawing.Point(100, 258);
            this.radialgauge5.Name = "radialgauge5";
            this.radialgauge5.PuntoCentral = 10;
            this.radialgauge5.Size = new System.Drawing.Size(439, 439);
            this.radialgauge5.TabIndex = 4;
            this.radialgauge5.Text = "radialgauge5";
            this.radialgauge5.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(16)))), ((int)(((byte)(43)))));
            this.radialgauge5.Value = 52;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 530);
            this.Controls.Add(this.radialgauge5);
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
        private Radialgauge.Radialgauge radialgauge5;
    }
}

