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
        public TaskPlannerWindow()
        {
            InitializeComponent();

        }

        private void TaskPlannerWindow_Load(object sender, EventArgs e)
        {
            this.labelWelcome.Text += "Piu, Piu";
        }


    }
}
