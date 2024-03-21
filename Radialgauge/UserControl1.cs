using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Timers;

namespace Radialgauge
{
    public partial class Radialgauge : Control
    {
        private int _progressValue = 0;
        private System.Timers.Timer animationTimer;
        private int animationIncrement = 2; // Incremento para la animación de llenado
        private int animationInterval = 50; // Intervalo para la animación de llenado (en milisegundos)

        public int ProgressValue
        {
            get { return _progressValue; }
            set
            {
                _progressValue = value;
                Invalidate(); // Redibujar el control cuando el valor cambia
            }
        }

        public Radialgauge()
        {
            // Establecer estilos para el control
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

            // Iniciar la animación de llenado
            animationTimer = new System.Timers.Timer(animationInterval);
            animationTimer.Elapsed += AnimationTimerElapsed;
            animationTimer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Dibujar el arco de la ProgressBar
            int progressAngle = (int)(_progressValue / 100.0 * 180); // Calcula el ángulo basado en el valor de progreso
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            e.Graphics.FillPie(Brushes.Blue, rect, 180, progressAngle); // Iniciamos el arco desde la parte inferior (ángulo 180)

            // Dibujar el borde del arco
            e.Graphics.DrawArc(Pens.Black, rect, 180, 180);
        }

        private void AnimationTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Incrementar el valor de progreso para la animación
            _progressValue += animationIncrement;
            if (_progressValue > 100)
                _progressValue = 0;

            // Redibujar el control
            this.Invoke((MethodInvoker)delegate
            {
                Invalidate();
            });
        }
    }
}
