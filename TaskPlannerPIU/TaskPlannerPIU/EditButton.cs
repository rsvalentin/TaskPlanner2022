using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskPlannerPIU
{
    class EditButton : Control
    {
        //vreau sa creez un textbox personalizat, cu buton de edit in interiorul lui
        public TextBox cardMessageTextBox = new TextBox();
        private Button editButton = new Button();
        private GroupBox _parent;

        public EditButton(GroupBox parent)
        {
            var xLocation = 11;
            _parent = parent;
            this.cardMessageTextBox.Parent = this;
            _parent.Controls.Add(cardMessageTextBox);
            cardMessageTextBox.Multiline = true;
            editButton.Size = new Size(30, cardMessageTextBox.ClientSize.Height);
            editButton.Dock = DockStyle.Right;
            editButton.Cursor = Cursors.Default;
            editButton.Image = Properties.Resources.edit_20x20;
            editButton.ImageAlign = ContentAlignment.MiddleCenter;
            editButton.FlatStyle = FlatStyle.Flat;
            editButton.ForeColor = Color.White;
            editButton.BackColor = Color.White;
            editButton.FlatAppearance.BorderSize = 1;
            editButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            editButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            editButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            editButton.Click += new EventHandler(this.editButton_Click);

            cardMessageTextBox.Controls.Add(editButton);
            SendMessage(cardMessageTextBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(editButton.Width << 16));

        }

        public void EnableDraggable()
        {
            ControlExtension.Draggable(cardMessageTextBox, true);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void editButton_Click(object sender, EventArgs e)
        {
            EditCardWindow editCardWindow = new EditCardWindow();
            editCardWindow.Show();
        }
    }
}
