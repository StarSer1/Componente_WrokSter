﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radialgauge
{
    public partial class Radialgauge:Button
    {

<<<<<<< Updated upstream
=======
        //Propiedades decorativas
        private Color _ColorDelPerimetro = Color.RoyalBlue; 
        private int _AnchoDelPerimetro = 5; 
        private Font _textFont = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
        private Color _textColor = Color.Black;
        private int _PuntoCentral = 4; 
        private Color _ColorDelPuntoCentral = Color.MediumSlateBlue;
        private int _GrosorDeLineaCentral = 5; 
        private Color _ColorDeLineaCentral = Color.MediumOrchid;
        private Color _ColorDeFondo = Color.Black;
        private DashStyle _EstiloDelPerimetro = DashStyle.Solid;

        [Browsable(true)]
        [DefaultValue(DashStyle.Solid)]
        public DashStyle EstiloDelPerimetro
        {
            get { return _EstiloDelPerimetro; }
            set
            {
                _EstiloDelPerimetro = value;
                Invalidate();
            }
        }
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Transparent")]
        public Color ColorDeFondo
        {
            get { return _ColorDeFondo; }
            set
            {
                _ColorDeFondo = value;
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
                IniciarAnimacion();
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
                Invalidate(); 
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
                Invalidate(); 
            }
        }

        [Browsable(true)]
        [DefaultValue(typeof(Color), "Black")]
        public Color ColorDelPerimetro
        {
            get { return _ColorDelPerimetro; }
            set
            {
                _ColorDelPerimetro = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DefaultValue(1)]
        public int AnchoDelPerimetro
        {
            get { return _AnchoDelPerimetro; }
            set
            {
                _AnchoDelPerimetro = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DefaultValue(1)]
        public int GrosorDeLineaCentral
        {
            get { return _GrosorDeLineaCentral; }
            set
            {
                _GrosorDeLineaCentral = value;
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

        public override Font Font
        {
            get { return _textFont; }
            set
            {
                _textFont = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DefaultValue(3)]
        public int PuntoCentral
        {
            get { return _PuntoCentral; }
            set
            {
                _PuntoCentral = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DefaultValue(typeof(Color), "Black")]
        public Color ColorDelPuntoCentral
        {
            get { return _ColorDelPuntoCentral; }
            set
            {
                _ColorDelPuntoCentral = value;
                Invalidate();
            }
        }



        [Browsable(true)]
        [DefaultValue(typeof(Color), "Black")]
        public Color ColorDeLineaCentral
        {
            get { return _ColorDeLineaCentral; }
            set
            {
                _ColorDeLineaCentral = value;
                Invalidate();
            }
        }


        //Actualizacion del Radialgauge
        public Radialgauge()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

            animationTimer = new System.Timers.Timer(IntervaloDeAnimacion);
            animationTimer.Elapsed += TemporizadorDeAnimacion;

            this.SizeChanged += Radialgauge_CambioDeTamaño;
        }

        // Controlador de eventos para el cambio de tamaño
        private void Radialgauge_CambioDeTamaño(object sender, EventArgs e)
        {
            int nuevoTamaño = Math.Max(Width, Height);
            Width = nuevoTamaño;
            Height = nuevoTamaño;
        }

        // Método para dibujar
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Calcular el tamaño del margen (por ejemplo, el 10% del tamaño del componente)
            int margin = Math.Min(Width, Height) / 10;

            // Definir el rectángulo del área de dibujo con el margen
            Rectangle drawingArea = new Rectangle(margin, margin, Width - 2 * margin, Height - 2 * margin);

            PointF inicio = new PointF(Width / 2, Height / 2);

            using (SolidBrush angleFillBrush = new SolidBrush(ColorDeFondo))
            {
                e.Graphics.FillPie(angleFillBrush, drawingArea, 180, 180);
            }

            using (Pen angleLinePen = new Pen(ColorDelPerimetro, AnchoDelPerimetro))
            {
                angleLinePen.DashStyle = EstiloDelPerimetro;
                e.Graphics.DrawArc(angleLinePen, drawingArea, 180, 180);
            }

            float angulo = 180 - ((float)(_value - MinValue) / (MaxValue - MinValue) * 180);

            PointF fina = ObtnerPuntoEnElCirculo(Width / 2, Height / 2, (Width - 2 * margin) / 2, angulo);

            using (Pen centralLinePen = new Pen(ColorDeLineaCentral, GrosorDeLineaCentral))
            {
                e.Graphics.DrawLine(centralLinePen, inicio, fina);
            }

            Rectangle puntocentreal = new Rectangle((int)inicio.X - PuntoCentral, (int)inicio.Y - PuntoCentral, PuntoCentral * 2, PuntoCentral * 2);
            using (SolidBrush centralPointBrush = new SolidBrush(ColorDelPuntoCentral))
            {
                e.Graphics.FillEllipse(centralPointBrush, puntocentreal);
            }

            e.Graphics.DrawEllipse(new Pen(ColorDelPuntoCentral, GrosorDeLineaCentral), inicio.X - PuntoCentral, inicio.Y - PuntoCentral, PuntoCentral * 2, PuntoCentral * 2);

            using (SolidBrush pincel = new SolidBrush(TextColor))
            {
                e.Graphics.DrawString(MinValue.ToString(), Font, pincel, margin, Height / 2);
            }

            using (SolidBrush pincel = new SolidBrush(TextColor))
            {
                SizeF textSize = e.Graphics.MeasureString(MaxValue.ToString(), Font);
                e.Graphics.DrawString(MaxValue.ToString(), Font, pincel, Width - textSize.Width - margin, Height / 2);
            }

            string valorDeTexto = _value.ToString();
            SizeF ValorDeTamaño = e.Graphics.MeasureString(valorDeTexto, Font);
            PointF ValorDeUbicacionDelTexto = new PointF(inicio.X - ValorDeTamaño.Width / 2, inicio.Y + PuntoCentral + 5);
            using (SolidBrush valueTextBrush = new SolidBrush(TextColor))
            {
                e.Graphics.DrawString(valorDeTexto, Font, valueTextBrush, ValorDeUbicacionDelTexto);
            }
        }


        private PointF ObtnerPuntoEnElCirculo(float centroX, float centroY, float radio, float anguloEnGrados)
        {
            float angleRadians = (float)(anguloEnGrados * Math.PI / 180.0);
            float x = centroX + (float)(radio * Math.Cos(angleRadians));
            float y = centroY - (float)(radio * Math.Sin(angleRadians));
            return new PointF(x, y);
        }

        // Incrementar el valor de progreso para la animación
        private void TemporizadorDeAnimacion(object sender, ElapsedEventArgs e)
        {
            if (_animationStartValue < _animationEndValue)
            {
                _animationStartValue += IncrementoDeAnimacion;
                if (_animationStartValue >= _animationEndValue)
                {
                    _animationStartValue = _animationEndValue;
                    animationTimer.Stop();
                }
            }
            _value = _animationStartValue;
            this.Invoke((MethodInvoker)delegate
            {
                Invalidate();
            });
        }

        // Establecer los valores de iniciales y finales de la animación
        public void IniciarAnimacion()
        {
            _animationStartValue = MinValue;
            _animationEndValue = Value;
            animationTimer.Start();
        }
>>>>>>> Stashed changes
    }
}
