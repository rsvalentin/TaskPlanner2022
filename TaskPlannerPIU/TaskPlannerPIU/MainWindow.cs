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
    public partial class MainWindow : Form
    {
        private string _username;
        private Rectangle _initialFormSize;//size pt intregul form
        private Rectangle _initialNextRect;
        private Rectangle _initialUsernameRect;
        private Rectangle _initialPasswordRect;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void customButton1_Click(object sender, EventArgs e)
        {
            TaskPlannerWindow taskPlannerWindow = new TaskPlannerWindow(this);
            taskPlannerWindow.Show();
            this.Hide();
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            _username = textBoxUsername.Text;
        }

        public string Username { get { return _username; } }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            _initialFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);

            _initialNextRect = new Rectangle(customButton1.Location.X, customButton1.Location.Y,customButton1.Width, customButton1.Height);
            _initialUsernameRect = new Rectangle(textBoxUsername.Location.X, textBoxUsername.Location.Y, textBoxUsername.Width, textBoxUsername.Height);
            _initialPasswordRect = new Rectangle(textBoxPassword.Location.X, textBoxPassword.Location.Y, textBoxPassword.Width, textBoxPassword.Height);
        }    

        /* functie de resize pt elementele din primul window, conform actionarii mouseului utilizatorului*/
        private void ResizeControl(Control control, Rectangle initialControlRect)
        {
            float xRatio = (float)(this.Width) / (float)(_initialFormSize.Width);
            float yRatio =  (float)(this.Height) / (float)(_initialFormSize.Height);

            int newX = (int)(initialControlRect.Width * xRatio);
            int newY = (int)(initialControlRect.Height * yRatio);

            int newWidth = (int)(initialControlRect.Width * xRatio);
            int newHeight = (int)(initialControlRect.Height * yRatio);


            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);
           /* control.Width = (int)(initialControlRect.Width * xRatio);
            control.Height = (int)(initialControlRect.Height * yRatio);*/

        }
        private void ResizeChildrenControls()
        {
            ResizeControl(customButton1, _initialNextRect);
            ResizeControl(textBoxUsername, _initialUsernameRect);
            ResizeControl(textBoxPassword, _initialPasswordRect);

        }
        private void MainWindow_Resize(object sender, EventArgs e)
        {
            //ResizeChildrenControls();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string getUsername()
        {
            return _username;
        }
    }
}
