using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TicketsHub
{
    public class CustomPanel : Panel
    {
        private Color borderColor = Color.MediumSlateBlue;
        private Color borderFocusColor = Color.HotPink;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private bool isFocused = false;
        private int borderRadius = 0;
        private int shadowDepth = 5;
        private Color shadowColor = Color.Gray;
        private int shadowOpacity = 180;

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }

        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                if (value >= 1)
                {
                    borderSize = value;
                    this.Invalidate();
                }
            }
        }

        public bool UnderlinedStyle
        {
            get { return underlinedStyle; }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }

        public int ShadowDepth
        {
            get { return shadowDepth; }
            set
            {
                if (value >= 0)
                {
                    shadowDepth = value;
                    this.Invalidate();
                }
            }
        }

        public Color ShadowColor
        {
            get { return shadowColor; }
            set
            {
                shadowColor = value;
                this.Invalidate();
            }
        }

        public int ShadowOpacity
        {
            get { return shadowOpacity; }
            set
            {
                if (value >= 0 && value <= 255)
                {
                    shadowOpacity = value;
                    this.Invalidate();
                }
            }
        }

        public void SetShadowProperties(Color newShadowColor, int newShadowDepth, int newShadowOpacity)
        {
            ShadowColor = newShadowColor;
            ShadowDepth = newShadowDepth;
            ShadowOpacity = newShadowOpacity;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (borderRadius > 1)
            {
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(pathBorderSmooth);
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = PenAlignment.Center;
                    if (isFocused) penBorder.Color = borderFocusColor;

                    DrawOuterShadow(graph, pathBorderSmooth);

                    if (underlinedStyle)
                    {
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        graph.SmoothingMode = SmoothingMode.None;
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        graph.DrawPath(penBorder, pathBorder);
                    }
                }
            }
        }

        private void DrawOuterShadow(Graphics graph, GraphicsPath path)
        {
            using (PathGradientBrush brush = new PathGradientBrush(path))
            {
                brush.CenterColor = Color.Transparent;
                brush.SurroundColors = new Color[] { Color.FromArgb(shadowOpacity, shadowColor) };
                brush.FocusScales = new PointF(1.0f + (float)shadowDepth / 100, 1.0f + (float)shadowDepth / 100);

                graph.FillPath(brush, path);
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
