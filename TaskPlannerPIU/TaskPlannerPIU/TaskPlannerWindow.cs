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
    public partial class TaskPlannerWindow : Form
    {
        private MainWindow _mainWindow;

        public TaskPlannerWindow(MainWindow other)
        {
            _mainWindow = other;
            InitializeComponent();
        }
        public TaskPlannerWindow()
        {
            InitializeComponent();

        }

        private void TaskPlannerWindow_Load(object sender, EventArgs e)
        {
            string username = _mainWindow.getUsername();
            this.labelWelcome.Text += username;
        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}
