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
        private Button addListButton;
        private Button quitAddingListButton;
        private Button addCardButton;
        private GroupBox listGroupBox;
        private int _counterLists = 1;

        private int addListPositionX = 5;
        private int quitAddingListPositionX = 57;
        private int titlePositionX = 5;
        private int moveX = 10;
        private int moveGroupBoxX = 120;
        private int moveY = 60;
        private int cardButtonPositionX = 10;
        private int cardButtonPositionY = 45;
        private int listGroupBoxPositionX = 5;
        private int listGroupBoxPositionY = 20;

        private List<GroupBox> groupBoxesLists = new List<GroupBox>();

        public TaskPlannerWindow(MainWindow parent)
        {
            InitializeComponent();
            _parent = parent;
            this.AutoScroll = true;
        }

        private void TaskPlannerWindow_Load(object sender, EventArgs e)
        {
            this.labelWelcome.Text += _parent.Username + "!";
            groupBoxesLists.Add(this.initialListGroupBox);
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            this.btnAddList.Hide();
            if (_counterLists != 1)
            {
                listGroupBox = new GroupBox();
                groupBoxesLists.Add(listGroupBox);
                listGroupBox.Location = new Point(listGroupBoxPositionX + moveGroupBoxX, listGroupBoxPositionY);
                listGroupBox.Width = 150;
                listGroupBox.Height = 230; // TODO: dynamic dupa nr de task uri din lista
                listGroupBox.Controls.Add(btnAddList);
            }
            else
                listGroupBox = initialListGroupBox;

            titleTextBox = new TextBox();
            titleTextBox.Location = _counterLists == 1 ? new Point(titlePositionX, 25) : new Point(titlePositionX, 25);
            titlePositionX = titleTextBox.Location.X;
            _currentTitle = titleTextBox.Text;
            titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            _currentListTextBox = titleTextBox;
            listGroupBox.Controls.Add(titleTextBox);
            labelWelcome.Location = new Point(3, 8);

            addListButton = new Button();
            addListButton.Location = _counterLists == 1 ? new Point(addListPositionX, 55) : new Point(addListPositionX, 55);
            addListPositionX = addListButton.Location.X;
            addListButton.Text = "Add list";
            addListButton.Width = 50;
            addListButton.Font = new Font("Microsoft Sans Serif", 7);
            addListButton.Name = "btnAddAndSaveList";
            addListButton.Click += new System.EventHandler(this.btnAddAndSaveList_Click);
            listGroupBox.Controls.Add(addListButton);

            quitAddingListButton = new Button();
            quitAddingListButton.Location = _counterLists == 1 ? new Point(quitAddingListPositionX, 55) : new Point(quitAddingListPositionX, 55);
            quitAddingListButton.Text = "Quit";
            quitAddingListPositionX = quitAddingListButton.Location.X;
            quitAddingListButton.Width = 50;
            quitAddingListButton.Font = new Font("Microsoft Sans Serif", 7);
            quitAddingListButton.Name = "btnQuitAddingList";
            quitAddingListButton.Click += new System.EventHandler(this.quitAddingListButton_Click);
            listGroupBox.Controls.Add(quitAddingListButton);

            this.groupBoxTasks.Controls.Add(titleTextBox);
            this.groupBoxTasks.Controls.Add(addListButton);
            this.groupBoxTasks.Controls.Add(quitAddingListButton);
            this.groupBoxTasks.Controls.Add(listGroupBox);
        }

        private void btnAddAndSaveList_Click(object sender, EventArgs e)
        {
            _currentListTextBox.Text = _currentTitle;
            // this.btnAddList.Location = new Point(titlePositionX, 25);
            this.btnAddList.Show();
            _counterLists++;

            // add a list -> add card
            addCardButton = new Button();
            addCardButton.Location = new Point(cardButtonPositionX, cardButtonPositionY);
            titleTextBox.Enabled = false;
            addCardButton.Text = "Add card";
            addListButton.Hide();
            addListButton.Text = "Add list";
            quitAddingListButton.Hide();
            
            listGroupBox.Controls.Add(addCardButton);
        }

        private void createNewListGroupBox()
        {

        }

        private void quitAddingListButton_Click(object sender, EventArgs e)
        {
            _currentListTextBox.Text = "";
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            _currentTitle = titleTextBox.Text;
        }

        private void initialListGroupBox_Enter(object sender, EventArgs e)
        {
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
