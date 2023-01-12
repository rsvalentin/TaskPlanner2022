using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskPlannerPIU
{
    public partial class CustomTextBox : UserControl
    {
        private Color borderColor = Color.FromArgb(153, 153, 153);
        private int borderSize = 3;
        private Color borderFocusColor = Color.FromArgb(52, 159, 153);
        private bool isFocused = false;
        public CustomTextBox()
        {
            InitializeComponent();
            this.AutoSize = false;
        }

        [Category("TaskPlannerCustomized")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        [Category("TaskPlannerCustomized")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("TaskPlannerCustomized")]
        public bool Multiline
        {
            get { return myTextBox.Multiline; }
            set { myTextBox.Multiline = value; }
        }

        [Category("TaskPlannerCustomized")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                myTextBox.BackColor = value;
            }
        }

        [Category("TaskPlannerCustomized")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                myTextBox.ForeColor = value;
            }
        }

        [Category("TaskPlannerCustomized")]
        public string Texts
        {
            get 
            { 
                return myTextBox.Text; 
            }
            set
            { 
                myTextBox.Text = value; 
            }
        }
        [Category("TaskPlannerCustomized")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }
        [Category("TaskPlannerCustomized")]
        public bool IsPassswordText
        {
            get
            {
                return myTextBox.UseSystemPasswordChar;
            }
            set 
            { 
                myTextBox.UseSystemPasswordChar = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            //Draw border
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                if (!isFocused)//normal border color 
                { 
                    graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
                else
                {
                    penBorder.Color = borderFocusColor; //Set Border color in focus
                    graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
            
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void CustomTextBox_Load(object sender, EventArgs e)
        {

        }

        private void myTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        //pt a schimba culorile bordurii
        private void myTextBox_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
        }

        private void myTextBox_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
        }

      
    }
}
