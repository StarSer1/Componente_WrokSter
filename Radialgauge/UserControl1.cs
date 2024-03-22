using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.Drawing.Drawing2D;

namespace Radialgauge
{
    //Agregar estilos al radial gauge
    public enum RadialGaugeStyle
    {
        Moderno,
        Clasico,
        Rustico,
    }

    public partial class Radialgauge : Control
    {
        private RadialGaugeStyle _Estilos = RadialGaugeStyle.Moderno;

        private int _value = 0;
        private int _minValue = 0;
        private int _maxValue = 100;
        private int _animationStartValue = 0;
        private int _animationEndValue = 0;
        private System.Timers.Timer animationTimer;
        private int IncrementoDeAnimacion = 2;
        private int IntervaloDeAnimacion = 50; // Intervalo para la animación de llenado (en milisegundos)

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
        [DefaultValue(RadialGaugeStyle.Moderno)]
        public RadialGaugeStyle Estilo
        {
            get { return _Estilos; }
            set
            {
                _Estilos = value;
                CasosDeEstilos();
                Invalidate();
            }
        }
        [Browsable(true)]
        [DefaultValue(50)] // Valor predeterminado del intervalo de animación en milisegundos
        public int IntervaloAnimacion
        {
            get { return IntervaloDeAnimacion; }
            set
            {
                IntervaloDeAnimacion = value;
                animationTimer.Interval = IntervaloDeAnimacion;
            }
        }

        // Método para establecer el estilo según el valor del enumerador
        private void CasosDeEstilos()
        {
            switch (_Estilos)
            {
                case RadialGaugeStyle.Moderno:
                    _ColorDelPerimetro = Color.RoyalBlue;
                    _AnchoDelPerimetro = 5;
                    _textColor = Color.Black;
                    _PuntoCentral = 4;
                    _ColorDelPuntoCentral = Color.MediumSlateBlue;
                    _GrosorDeLineaCentral = 5;
                    _ColorDeLineaCentral = Color.MediumOrchid;
                    _ColorDeFondo = Color.Black;
                    _EstiloDelPerimetro = DashStyle.Solid;
                    break;
                case RadialGaugeStyle.Clasico:

                    _ColorDelPerimetro = Color.Teal;
                    _AnchoDelPerimetro = 30;
                    _textColor = Color.Black;
                    _PuntoCentral = 3;
                    _ColorDelPuntoCentral = Color.DarkSlateGray;
                    _GrosorDeLineaCentral = 6;
                    _ColorDeLineaCentral = Color.LightSeaGreen;
                    _ColorDeFondo = Color.Transparent;
                    _EstiloDelPerimetro = DashStyle.Custom;
                    _EstiloDeLineaCentral = CentralLineStyle.Triangular;
                    break;
                case RadialGaugeStyle.Rustico:
                    _ColorDelPerimetro = Color.FromArgb(34, 141, 184);
                    _AnchoDelPerimetro = 30;
                    _textColor = Color.FromArgb(25, 16, 43);
                    _PuntoCentral = 10;
                    _ColorDelPuntoCentral = Color.FromArgb(236, 242, 242);
                    _GrosorDeLineaCentral = 5;
                    _ColorDeLineaCentral = Color.FromArgb(38, 196, 244);
                    _ColorDeFondo = Color.FromArgb(25, 16, 43);
                    _EstiloDelPerimetro = DashStyle.Dash;
                    _EstiloDeLineaCentral = CentralLineStyle.Triangular;
                    break;
            }
        }
        public enum CentralLineStyle
        {
            Rectangular,
            Triangular
        }

        private CentralLineStyle _EstiloDeLineaCentral = CentralLineStyle.Rectangular;

        [Browsable(true)]
        [DefaultValue(CentralLineStyle.Rectangular)]
        public CentralLineStyle EstiloDeLineaCentral
        {
            get { return _EstiloDeLineaCentral; }
            set
            {
                _EstiloDeLineaCentral = value;
                Invalidate();
            }
        }

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

            int margin = Math.Min(Width, Height) / 10;
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
                if (EstiloDeLineaCentral == CentralLineStyle.Rectangular)
                {
                    e.Graphics.DrawLine(centralLinePen, inicio, fina);
                }
                else if (EstiloDeLineaCentral == CentralLineStyle.Triangular)
                {
                    PointF p1 = fina;
                    PointF p2 = inicio;
                    float angleInRadians = (float)((180 - angulo) * Math.PI / 180.0);
                    float triangleSize = GrosorDeLineaCentral * 2;

                    float widestPointX = p2.X + triangleSize * (float)Math.Cos(angleInRadians);
                    float widestPointY = p2.Y + triangleSize * (float)Math.Sin(angleInRadians);

                    PointF startTrianglePoint = new PointF(widestPointX, widestPointY);

                    PointF p3 = new PointF(p2.X + triangleSize * (float)Math.Cos(angleInRadians + Math.PI / 2), p2.Y + triangleSize * (float)Math.Sin(angleInRadians + Math.PI / 2));
                    PointF p4 = new PointF(p2.X + triangleSize * (float)Math.Cos(angleInRadians - Math.PI / 2), p2.Y + triangleSize * (float)Math.Sin(angleInRadians - Math.PI / 2));

                    PointF[] trianglePoints = { p1, p3, p4 };
                    e.Graphics.FillPolygon(new SolidBrush(ColorDeLineaCentral), trianglePoints);
                }
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

    }
}