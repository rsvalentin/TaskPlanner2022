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
        private TextBox textBox;
        private string text;

        public EditCardWindow(TextBox textBox)
        {
            InitializeComponent();
            this.textBox = textBox;
            this.editCardTitle.Text = textBox.Text;
            //this.editCardTitle.Text = parent.currentCard;
            //DE CE  INCA ISI FACE RESIZE formul?
        }

        private void editCardTitle_TextChanged(object sender, EventArgs e)
        {
            text = this.editCardTitle.Text;
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            //cand dau click tre sa se salveze info din input in textboxul din interfata TaskPlanner
            //trebuie actualizat si db-ul
            //parent.getEditButton().cardMessageTextBox.Text = this.editCardTitle.Text;
            textBox.Text = text;
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
