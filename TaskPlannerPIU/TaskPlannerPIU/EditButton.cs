﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskPlannerPIU
{
    public class EditButton : Control
    {
        //vreau sa creez un textbox personalizat, cu buton de edit in interiorul lui
        public TextBox cardMessageTextBox;
        private Button btn;
        private EditCardWindow editWindow;
        private FlowLayoutPanel flp;

        public EditButton(FlowLayoutPanel flp)
        {
            this.flp = flp;
            cardMessageTextBox = new TextBox();
            btn = new Button();
            // this.cardMessageTextBox.Parent = this;
            flp.Controls.Add(cardMessageTextBox);
            cardMessageTextBox.Multiline = true;

            btn.Size = new Size(30, cardMessageTextBox.ClientSize.Height);
            btn.Dock = DockStyle.Right;
            btn.Cursor = Cursors.Default;
            btn.Image = Properties.Resources.edit_20x20;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.White;
            btn.BackColor = Color.White;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.Click += new EventHandler(this.EditButton_Click);

            cardMessageTextBox.Controls.Add(btn);
            SendMessage(cardMessageTextBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn.Width << 16));
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void EditButton_Click(object sender, EventArgs e)
        {
            //pt un parent, ar trbui sa am mai multe EditButton uri!!!
            EditCardWindow editCardWindow = new EditCardWindow(cardMessageTextBox);
            editCardWindow.Show();

        }
    }
}
