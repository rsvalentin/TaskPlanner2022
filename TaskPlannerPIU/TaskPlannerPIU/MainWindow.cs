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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
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

    }
}
