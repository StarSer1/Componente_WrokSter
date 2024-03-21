using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace Radialgauge
{
    public partial class Radialgauge : Control
    {
        private int _value = 0;
        private int _minValue = 0;
        private int _maxValue = 100;
        private int _animationStartValue = 0;
        private int _animationEndValue = 0;
        private System.Timers.Timer animationTimer;
        private int animationIncrement = 2; // Incremento para la animación de llenado
        private int animationInterval = 50; // Intervalo para la animación de llenado (en milisegundos)

        // Nuevas propiedades decorativas
        private Color _lineColor = Color.Blue;
        private Color _angleLineColor = Color.Black; // Color predeterminado de la línea del perímetro del ángulo
        private int _angleLineThickness = 1; // Grosor predeterminado de la línea del perímetro del ángulo
        private Font _textFont = SystemFonts.DefaultFont;
        private Color _textColor = Color.Black;
        private int _centralPointRadius = 3; // Radio predeterminado del punto central
        private Color _centralPointColor = Color.Black; // Color predeterminado del punto central
        private int _centralLineThickness = 1; // Grosor predeterminado de la línea central
        private Color _centralLineColor = Color.Black;
        // Nueva propiedad para el color del área dentro del perímetro del ángulo
        private Color _angleFillColor = Color.Transparent;

        [Browsable(true)]
        [DefaultValue(typeof(Color), "Transparent")]
        public Color AngleFillColor
        {
            get { return _angleFillColor; }
            set
            {
                _angleFillColor = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DefaultValue(0)]
        public int Value
        {
            get { return _value; }
            set
            {
                _value = Math.Min(Math.Max(value, MinValue), MaxValue);
                StartAnimation();
            }
        }

        [Browsable(true)]
        [DefaultValue(0)]
        public int MinValue
        {
            get { return _minValue; }
            set
            {
                _minValue = value;
                Invalidate(); // Redibujar el control cuando el valor cambia
            }
        }

        [Browsable(true)]
        [DefaultValue(100)]
        public int MaxValue
        {
            get { return _maxValue; }
            set
            {
                _maxValue = value;
                Invalidate(); // Redibujar el control cuando el valor cambia
            }
        }

        [Browsable(true)]
        [DefaultValue(typeof(Color), "Blue")]
        public Color LineColor
        {
            get { return _lineColor; }
            set
            {
                _lineColor = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DefaultValue(typeof(Color), "Black")]
        public Color AngleLineColor
        {
            get { return _angleLineColor; }
            set
            {
                _angleLineColor = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DefaultValue(1)]
        public int AngleLineThickness
        {
            get { return _angleLineThickness; }
            set
            {
                _angleLineThickness = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DefaultValue(1)]
        public int CentralLineThickness
        {
            get { return _centralLineThickness; }
            set
            {
                _centralLineThickness = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DefaultValue(typeof(Color), "Black")]
        public Color TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DefaultValue(3)]
        public int CentralPointRadius
        {
            get { return _centralPointRadius; }
            set
            {
                _centralPointRadius = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DefaultValue(typeof(Color), "Black")]
        public Color CentralPointColor
        {
            get { return _centralPointColor; }
            set
            {
                _centralPointColor = value;
                Invalidate();
            }
        }



        [Browsable(true)]
        [DefaultValue(typeof(Color), "Black")]
        public Color CentralLineColor
        {
            get { return _centralLineColor; }
            set
            {
                _centralLineColor = value;
                Invalidate();
            }
        }


        public Radialgauge()
        {
            // Establecer estilos para el control
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

            // Inicializar el temporizador de animación
            animationTimer = new System.Timers.Timer(animationInterval);
            animationTimer.Elapsed += AnimationTimerElapsed;

            // Agregar el controlador de eventos para el cambio de tamaño
            this.SizeChanged += Radialgauge_SizeChanged;
        }
        // Controlador de eventos para el cambio de tamaño
        private void Radialgauge_SizeChanged(object sender, EventArgs e)
        {
            // Asegurar que el ancho y el alto sean iguales para mantener un tamaño cuadrado
            int newSize = Math.Max(Width, Height);
            Width = newSize;
            Height = newSize;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Calcular el punto de inicio de la línea central
            PointF start = new PointF(Width / 2, Height / 2);

            // Dibujar el arco exterior de la ProgressBar (perímetro curvo)
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1); // Ajustar el rectángulo para que la línea del perímetro no se corte

            using (SolidBrush angleFillBrush = new SolidBrush(AngleFillColor))
            {
                e.Graphics.FillPie(angleFillBrush, rect, 180, 180);
            }

            // Dibujar la línea del perímetro del ángulo
            using (Pen angleLinePen = new Pen(AngleLineColor, AngleLineThickness))
            {
                e.Graphics.DrawArc(angleLinePen, rect, 180, 180);
            }

            // Calcular el ángulo de la línea central en función del valor actual
            float angle = 180 - ((float)(_value - MinValue) / (MaxValue - MinValue) * 180);

            // Calcular los puntos de inicio y fin de la línea central
            PointF end = GetPointOnCircle(Width / 2, Height / 2, Width / 2, angle);

            // Dibujar la línea central
            using (Pen centralLinePen = new Pen(CentralLineColor, CentralLineThickness))
            {
                e.Graphics.DrawLine(centralLinePen, start, end);
            }

            Rectangle centralPointRect = new Rectangle((int)start.X - CentralPointRadius, (int)start.Y - CentralPointRadius, CentralPointRadius * 2, CentralPointRadius * 2);
            using (SolidBrush centralPointBrush = new SolidBrush(CentralPointColor))
            {
                e.Graphics.FillEllipse(centralPointBrush, centralPointRect);
            }

            // Dibujar el círculo central
            e.Graphics.DrawEllipse(new Pen(CentralPointColor, CentralLineThickness), start.X - CentralPointRadius, start.Y - CentralPointRadius, CentralPointRadius * 2, CentralPointRadius * 2);

            // Dibujar el texto en el extremo izquierdo
            using (SolidBrush textBrush = new SolidBrush(TextColor))
            {
                e.Graphics.DrawString(MinValue.ToString(), Font, textBrush, 0, Height / 2);
            }

            // Dibujar el texto en el extremo derecho
            using (SolidBrush textBrush = new SolidBrush(TextColor))
            {
                SizeF textSize = e.Graphics.MeasureString(MaxValue.ToString(), Font);
                e.Graphics.DrawString(MaxValue.ToString(), Font, textBrush, Width - textSize.Width, Height / 2);
            }

            // Dibujar el texto debajo del punto central
            string valueText = _value.ToString();
            SizeF valueTextSize = e.Graphics.MeasureString(valueText, Font);
            PointF valueTextLocation = new PointF(start.X - valueTextSize.Width / 2, start.Y + CentralPointRadius + 5); // 5 es el espacio entre el punto central y el texto
            using (SolidBrush valueTextBrush = new SolidBrush(TextColor))
            {
                e.Graphics.DrawString(valueText, Font, valueTextBrush, valueTextLocation);
            }
        }



        private PointF GetPointOnCircle(float centerX, float centerY, float radius, float angleDegrees)
        {
            float angleRadians = (float)(angleDegrees * Math.PI / 180.0);
            float x = centerX + (float)(radius * Math.Cos(angleRadians));
            float y = centerY - (float)(radius * Math.Sin(angleRadians)); // Restamos para invertir la dirección vertical
            return new PointF(x, y);
        }

        private void AnimationTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Incrementar el valor de progreso para la animación
            if (_animationStartValue < _animationEndValue)
            {
                _animationStartValue += animationIncrement;
                if (_animationStartValue >= _animationEndValue)
                {
                    _animationStartValue = _animationEndValue;
                    animationTimer.Stop();
                }
            }

            // Actualizar el valor del control
            _value = _animationStartValue;

            // Redibujar el control
            this.Invoke((MethodInvoker)delegate
            {
                Invalidate();
            });
        }

        public void StartAnimation()
        {
            // Establecer los valores de inicio y fin de la animación
            _animationStartValue = MinValue;
            _animationEndValue = Value;

            // Iniciar la animación
            animationTimer.Start();
        }
    }
}
