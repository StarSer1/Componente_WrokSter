﻿namespace WrokSter
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
            this.radialgauge2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.radialgauge2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radialgauge2.ForeColor = System.Drawing.Color.Black;
            this.radialgauge2.LineColor = System.Drawing.Color.Fuchsia;
            this.radialgauge2.Location = new System.Drawing.Point(132, 65);
            this.radialgauge2.MinValue = 30;
            this.radialgauge2.Name = "radialgauge2";
            this.radialgauge2.Size = new System.Drawing.Size(452, 302);
            this.radialgauge2.TabIndex = 1;
            this.radialgauge2.Text = "radialgauge2";
            this.radialgauge2.TextColor = System.Drawing.Color.IndianRed;
            this.radialgauge2.Value = 50;
            // 
            // radialgauge1
            // 
            this.radialgauge1.Location = new System.Drawing.Point(0, 0);
            this.radialgauge1.Name = "radialgauge1";
            this.radialgauge1.Size = new System.Drawing.Size(0, 0);
            this.radialgauge1.TabIndex = 0;
            this.radialgauge1.Value = 100;
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

