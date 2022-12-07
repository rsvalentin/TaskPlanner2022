using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static TaskPlannerPIU.Helpers.Constants;

namespace TaskPlannerPIU
{
    public partial class TaskPlannerWindow : Form
    {
        private List<GroupBox> _groupBoxesLists = new List<GroupBox>();
        private MainWindow _parent;
        private TextBox _currentListTextBox;
        private string _selectedColumnName;
        private Button addCardButton;
        private GroupBox _listGroupBox;

        public TaskPlannerWindow(MainWindow parent)
        {
            InitializeComponent();
            _parent = parent;
            this.AutoScroll = true;
            this.saveListButton.Hide();
            this.quitAddingListButton.Hide();
            this.titleTextBox.Hide();
        }

        private void TaskPlannerWindow_Load(object sender, EventArgs e)
        {
            this.labelWelcome.Text += _parent.Username + "!";
            _groupBoxesLists.Add(this.initialListGroupBox);
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            this.btnAddList.Hide();
            this.saveListButton.Show();
            this.quitAddingListButton.Show();
            this.titleTextBox.Show();

            if (COUNTER_LISTS == 1)
            {
                _listGroupBox = initialListGroupBox;
                this.groupBoxTasks.Controls.Add(_listGroupBox);
            }
            _listGroupBox.Controls.Add(titleTextBox);
            _listGroupBox.Controls.Add(saveListButton);
            _listGroupBox.Controls.Add(quitAddingListButton);
            _selectedColumnName = titleTextBox.Text;
            titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            _currentListTextBox = titleTextBox;
        }


        private void quitAddingListButton_Click(object sender, EventArgs e)
        {
            _currentListTextBox.Text = "";
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            _selectedColumnName = titleTextBox.Text;
        }

        private void TaskPlannerWindow_Scroll(object sender, ScrollEventArgs e)
        {
            labelWelcome.Location = new Point(3, 8);
        }

        private void addListButton_Click(object sender, EventArgs e)
        {
            this.saveListButton.Hide();
            this.quitAddingListButton.Hide();
            this.titleTextBox.Hide();

            COUNTER_LISTS++;
            _currentListTextBox.Text = _selectedColumnName;
            this.btnAddList.Show();

            setColumnTitle();
            createNewGroupBoxForColumn();
        }

        private void quitAddingListButton_Click_1(object sender, EventArgs e)
        {
            _currentListTextBox.Text = "";
        }

        private void setColumnTitle()
        {
            var textbox = new TextBox();
            textbox.Location = this.titleTextBox.Location;
            textbox.Width = this.titleTextBox.Width;
            textbox.ReadOnly = true;
            textbox.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            textbox.BorderStyle = BorderStyle.FixedSingle;
            textbox.Text = this.titleTextBox.Text;
            this._listGroupBox.Controls.Add(textbox);
            this.titleTextBox.Text = "";
        }

        private void createNewGroupBoxForColumn()
        {
            this._listGroupBox = new GroupBox();
            this._groupBoxesLists.Add(_listGroupBox);
            this._listGroupBox.Location = new Point(LIST_GROUPBOX_POSITION_X + MOVE_GROUPBOX_X, this.initialListGroupBox.Location.Y);
            LIST_GROUPBOX_POSITION_X = _listGroupBox.Location.X;
            this._listGroupBox.Width = initialListGroupBox.Width;
            this._listGroupBox.Height = initialListGroupBox.Height; // TODO: dynamic dupa nr de task uri din lista
            this._listGroupBox.Controls.Add(btnAddList);
            this.groupBoxTasks.Controls.Add(_listGroupBox);
        }
    }
}
