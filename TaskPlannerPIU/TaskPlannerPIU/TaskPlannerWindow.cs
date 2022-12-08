using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
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
        private GroupBox _listGroupBox;
        private Button _createCardBtn;
        private Dictionary<Button, int> cardButtonIndexList = new Dictionary<Button, int>();


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
            createAddCardButton();

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

        private void createAddCardButton()
        {
            _createCardBtn = new Button();
            _createCardBtn.Text = "Add card";
            this._listGroupBox.Controls.Add(_createCardBtn);
            _createCardBtn.Location = new Point(this.saveListButton.Location.X, this.saveListButton.Location.Y + 5);
            _createCardBtn.Width = 70;
            _createCardBtn.Click += new System.EventHandler(this.addCardButton_Click);

            cardButtonIndexList.Add(_createCardBtn, COUNTER_LISTS - 1 );
        }

        private void addCardButton_Click(object sender, EventArgs e)
        {
            var index = cardButtonIndexList[_createCardBtn];
            var selectedGroupBox = _groupBoxesLists[index];
            var xLocation = 11; 
            var yLocation = selectedGroupBox.Location.Y; 

            _createCardBtn.Hide();
            EditButton cardMessageTextBox = new EditButton();
            cardMessageTextBox.Width = this.titleTextBox.Width;
            cardMessageTextBox.Height = 30;
            selectedGroupBox.Controls.Add(cardMessageTextBox);
            cardMessageTextBox.Location = new Point(xLocation, yLocation + 25);
            cardMessageTextBox.TextChanged += new System.EventHandler(this.cardMessageTextBox_TextChanged);

            Button saveCardButton = new Button();
            selectedGroupBox.Controls.Add(saveCardButton);
            saveCardButton.Text = "Save";
            saveCardButton.BackColor = Color.Red;
            saveCardButton.Location = new Point(xLocation, yLocation + 55);
            saveCardButton.Width = this.saveListButton.Width;
            saveCardButton.Click += new System.EventHandler(this.addCardButton_Click);

            Button quitSavingCardButton = new Button();
            selectedGroupBox.Controls.Add(quitSavingCardButton);
            quitSavingCardButton.Text = "Quit";
            quitSavingCardButton.Location = new Point(xLocation + 52, yLocation + 55);
            quitSavingCardButton.Width = this.saveListButton.Width;
            quitSavingCardButton.Click += new System.EventHandler(this.addCardButton_Click);
        }

        private void cardMessageTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void titleTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void editButton3_Click(object sender, EventArgs e)
        {

        }

        private void editButton2_btnClick(object sender, EventArgs e)
        {
            MessageBox.Show("oare merge?");
        }
    }
}
