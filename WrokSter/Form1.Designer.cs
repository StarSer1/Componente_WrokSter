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
            this.radialgauge2 = new Radialgauge.Radialgauge();
            this.radialgauge1 = new Radialgauge.Radialgauge();
            this.SuspendLayout();
            // 
            // radialgauge2
            // 
            this.radialgauge2.AnchoDelPerimetro = 5;
            this.radialgauge2.ColorDeFondo = System.Drawing.Color.Black;
            this.radialgauge2.ColorDeLineaCentral = System.Drawing.Color.MediumOrchid;
            this.radialgauge2.ColorDelPerimetro = System.Drawing.Color.Red;
            this.radialgauge2.ColorDelPuntoCentral = System.Drawing.Color.MediumSlateBlue;
            this.radialgauge2.Estilo = Radialgauge.RadialGaugeStyle.Estilo1;
            this.radialgauge2.GrosorDeLineaCentral = 5;
            this.radialgauge2.Location = new System.Drawing.Point(188, 96);
            this.radialgauge2.Name = "radialgauge2";
            this.radialgauge2.PuntoCentral = 4;
            this.radialgauge2.Size = new System.Drawing.Size(302, 302);
            this.radialgauge2.TabIndex = 1;
            this.radialgauge2.Text = "radialgauge2";
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
            this.ClientSize = new System.Drawing.Size(714, 408);
            this.Controls.Add(this.radialgauge2);
            this.Controls.Add(this.radialgauge1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Radialgauge.Radialgauge radialgauge1;
        private Radialgauge.Radialgauge radialgauge2;
    }
}

