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
        private MainWindow _parent;
        private TextBox _currentListTextBox;
        private string _currentTitle;
        private TextBox titleTextBox;
        private int _counterLists = 1;

        private int addListPositionX = 40;
        private int quitAddingListPositionX = 90;
        private int titlePositionX = 40;
        private int moveX = 120;

        public TaskPlannerWindow(MainWindow parent)
        {
            InitializeComponent();
            _parent = parent;
            this.AutoScroll = true;
        }

        private void TaskPlannerWindow_Load(object sender, EventArgs e)
        {
            this.labelWelcome.Text += _parent.Username + "!";

        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            this.btnAddList.Hide();
            titleTextBox = new TextBox();
            titleTextBox.Location = _counterLists == 1 ? new Point(titlePositionX, 50) : new Point(titlePositionX + moveX, 50);
            titlePositionX = titleTextBox.Location.X;
            _currentTitle = titleTextBox.Text;
            titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            _currentListTextBox = titleTextBox;
            labelWelcome.Location = new Point(3, 8);


            Button addListButton = new Button();
            addListButton.Location = _counterLists == 1 ? new Point(addListPositionX, 70) : new Point(addListPositionX + moveX, 70);
            addListPositionX = addListButton.Location.X;
            addListButton.Text = "Add list";
            addListButton.Width = 50;
            addListButton.Font = new Font("Microsoft Sans Serif", 7);
            addListButton.Name = "btnAddAndSaveList";
            addListButton.Click += new System.EventHandler(this.btnAddAndSaveList_Click);

            Button quitAddingListButton = new Button();
            quitAddingListButton.Location = _counterLists == 1 ? new Point(quitAddingListPositionX, 70) : new Point(quitAddingListPositionX + moveX, 70);
            quitAddingListButton.Text = "Quit";
            quitAddingListPositionX = quitAddingListButton.Location.X;
            quitAddingListButton.Width = 50;
            quitAddingListButton.Font = new Font("Microsoft Sans Serif", 7);
            quitAddingListButton.Name = "btnQuitAddingList";
            quitAddingListButton.Click += new System.EventHandler(this.quitAddingListButton_Click);

            this.groupBoxTasks.Controls.Add(titleTextBox);
            this.groupBoxTasks.Controls.Add(addListButton);
            this.groupBoxTasks.Controls.Add(quitAddingListButton);

        }

        private void btnAddAndSaveList_Click(object sender, EventArgs e)
        {
            _currentListTextBox.Text = _currentTitle;
            this.btnAddList.Location = new Point(titlePositionX + moveX, 50);
            this.btnAddList.Show();
            _counterLists++;
        }

        private void quitAddingListButton_Click(object sender, EventArgs e)
        {
            _currentListTextBox.Text = "";
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            _currentTitle = titleTextBox.Text;
        }

        private void groupBoxTasks_Enter(object sender, EventArgs e)
        {

        }

        private void TaskPlannerWindow_Paint(object sender, PaintEventArgs e)
        {
           // labelWelcome.Location = new Point(-this.AutoScrollPosition.X, this.Location.Y);
        }

        private void TaskPlannerWindow_Scroll(object sender, ScrollEventArgs e)
        {
            labelWelcome.Location = new Point(3,8);
        }
    }
}
