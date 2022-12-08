using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TaskPlannerPIU
{
    class CustomButton : Button
    {
        private int borderSize = 0;
        private int borderRadius = 40;
        private System.Drawing.Color borderColor = Color.Transparent;

        public CustomButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            //culoare buton - alpha, rosu, galben, albastru (alpha=255 => complet opac, valori intre 0 si 255)
            this.BackColor = Color.FromArgb(255, 187, 10, 33);
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(ButtonResize);
        }
        private void ButtonResize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                borderRadius = this.Height;
        }

        private GraphicsPath GetFigurePath(RectangleF r, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            path.AddArc(r.X, r.Y, radius, radius, 180, 90);
            path.AddArc(r.Width - radius, r.Y, radius, radius, 270, 90);
            path.AddArc(r.Width - radius, r.Height - radius, radius, radius, 0, 90);
            path.AddArc(r.X, r.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
   /*         GraphicsPath gr = new GraphicsPath();
            gr.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(gr);*/


            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface  = new RectangleF(0,0,this.Width,this.Height);
            RectangleF rectBorder = new RectangleF(1,1,this.Width - 0.8F,this.Height - 1);

            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius)) 
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius -1F))
            using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = PenAlignment.Inset;
                this.Region = new Region(pathSurface);
                pevent.Graphics.DrawPath(penBorder, pathBorder);
                pevent.Graphics.DrawPath(penBorder, pathBorder);
            }

        }
       
    }
}
