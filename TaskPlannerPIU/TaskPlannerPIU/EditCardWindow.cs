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
    public partial class EditCardWindow : Form
    {
        private TaskPlannerWindow parent;

        public EditCardWindow(TaskPlannerWindow taskPlannerWindow)
        {
            InitializeComponent();
            parent = taskPlannerWindow;
            //this.editCardTitle.Text = parent.currentCard;
            //DE CE  INCA ISI FACE RESIZE formul?
            taskPlannerWindow.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //trb sa pastrez textul din fereastra anterioara in asta
            //this.textBox1_TextChanged = taskPlannerWindow.;
            //this.editCardTitle.Text = new System.EventHandler(taskPlannerWindow.cardMessageTextBox_TextChanged).ToString();

        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            //cand dau click tre sa se salveze info din input in textboxul din interfata TaskPlanner
            //trebuie actualizat si db-ul
            //parent.getEditButton().cardMessageTextBox.Text = this.editCardTitle.Text;
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
