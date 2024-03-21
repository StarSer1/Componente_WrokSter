﻿using System;
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
        private Color _textColor = Color.Black;

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
        public Color TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
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
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Dibujar el arco exterior de la ProgressBar (perímetro curvo)
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1); // Ajustar el rectángulo para que la línea del perímetro no se corte
            e.Graphics.DrawArc(Pens.Black, rect, 180, 180); // Dibujar el arco exterior

            // Calcular el ángulo de la línea central en función del valor actual
            float angle = 180 - ((float)(_value - MinValue) / (MaxValue - MinValue) * 180);

            // Calcular los puntos de inicio y fin de la línea central
            PointF start = new PointF(Width / 2, Height / 2);
            PointF end = GetPointOnCircle(Width / 2, Height / 2, Width / 2, angle);

            // Dibujar la línea central
            e.Graphics.DrawLine(new Pen(LineColor), start, end);

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
