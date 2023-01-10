using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using TaskPlannerPIU.Card;
using static TaskPlannerPIU.Helpers.Constants;

namespace TaskPlannerPIU
{
    public partial class TaskPlannerWindow : Form
    {
        private List<GroupBox> _groupBoxesLists = new List<GroupBox>();
        private MainWindow _parent;
        private TextBox _currentListTextBox;
        private string _selectedColumnName;
        private string _selectedTaskContent;
        private GroupBox _listGroupBox;
        private Button _createCardBtn;
        private Dictionary<Button, int> cardButtonIndexList = new Dictionary<Button, int>();
        private EditButton editButton;
        private Button saveCardButton;
        private Button quitSavingCardButton;
        private Dictionary<Button, LastCardOfList> lastCardsOfLists = new Dictionary<Button, LastCardOfList>();
        public string currentCard;

        //PENTRU FIECARE CARD EU AM NEVOIE DE O INSTANTA DE EditCardWindow
        private EditCardWindow editCardWindow;

        public TaskPlannerWindow(MainWindow parent)
        {
            InitializeComponent();
            _parent = parent;
            this.AutoScroll = true;
            this.saveListButton.Hide();
            this.quitAddingListButton.Hide();
            this.titleTextBox.Hide();
        }
        public EditButton getEditButton()
        {
            return editButton;
        }

        private void TaskPlannerWindow_Load(object sender, EventArgs e)
        {
            this.labelWelcome.Text += _parent.Username + "!";
            this.labelWelcome.Font = new System.Drawing.Font("Lucida Handwriting", 10.2F, System.Drawing.FontStyle.Bold);
            this.labelWelcome.BackColor = Color.Transparent;
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
            this._listGroupBox.BackColor = Color.FromArgb(255, 52, 159, 153);
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
            _createCardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);

            _createCardBtn.BackColor = Color.FromArgb(255, 187, 10, 33);
            this._listGroupBox.Controls.Add(_createCardBtn);
            _createCardBtn.Location = new Point(this.saveListButton.Location.X, this.saveListButton.Location.Y + 5);
            _createCardBtn.Width = 70;
            _createCardBtn.Click += new System.EventHandler(this.addCardButton_Click);

            cardButtonIndexList.Add(_createCardBtn, COUNTER_LISTS - 1);
            lastCardsOfLists.Add(_createCardBtn, new LastCardOfList { ListNumber = cardButtonIndexList[_createCardBtn], TaskNumberFromList = COUNTER_TASKS, YLocation = this.saveListButton.Location.Y + 5 - 16 });
        }

        private void addCardButton_Click(object sender, EventArgs e)
        {
            var index = cardButtonIndexList[_createCardBtn];
            var selectedGroupBox = _groupBoxesLists[index];
            var xLocation = 11;
            var lastTaskFromList = lastCardsOfLists[_createCardBtn];

            _createCardBtn.Hide();
            editButton = new EditButton(this);
            editButton.Width = this.titleTextBox.Width;
            editButton.Height = 30;
            selectedGroupBox.Controls.Add(editButton);
            editButton.Location = COUNTER_TASKS == 1 ? new Point(xLocation, CARD_LOCATION_Y) : new Point(xLocation, CARD_LOCATION_Y + MOVE_TASK_Y);
            CARD_LOCATION_Y = editButton.Location.Y;
            editButton.cardMessageTextBox.TextChanged += new System.EventHandler(this.cardMessageTextBox_TextChanged);


            saveCardButton = new Button();
            selectedGroupBox.Controls.Add(saveCardButton);
            saveCardButton.Text = "Save";
            saveCardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);

            saveCardButton.BackColor = Color.FromArgb(255, 187, 10, 33);

            saveCardButton.Location = COUNTER_TASKS == 1 ? new Point(xLocation, QUIT_SAVE_CARD_LOCATION_Y) : new Point(xLocation, QUIT_SAVE_CARD_LOCATION_Y + MOVE_TASK_Y);
            saveCardButton.Width = this.saveListButton.Width;
            saveCardButton.Click += new System.EventHandler(this.saveCardButton_Click);

            quitSavingCardButton = new Button();
            selectedGroupBox.Controls.Add(quitSavingCardButton);
            quitSavingCardButton.Text = "Quit";
            quitSavingCardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            quitSavingCardButton.ForeColor = System.Drawing.Color.White;
            quitSavingCardButton.BackColor = Color.FromArgb(255, 187, 10, 33);
            quitSavingCardButton.Location = COUNTER_TASKS == 1 ? new Point(xLocation + 52, QUIT_SAVE_CARD_LOCATION_Y) : new Point(xLocation + 52, QUIT_SAVE_CARD_LOCATION_Y + MOVE_TASK_Y);
            quitSavingCardButton.Width = this.saveListButton.Width;
            quitSavingCardButton.Click += new System.EventHandler(this.quitSavingCardButton_Click);

            QUIT_SAVE_CARD_LOCATION_Y = saveCardButton.Location.Y;
        }

        public void cardMessageTextBox_TextChanged(object sender, EventArgs e)
        {
            currentCard = editButton.cardMessageTextBox.Text;
        }

        private void saveCardButton_Click(object sender, EventArgs e)
        {
            this.saveCardButton.Hide();
            this.quitSavingCardButton.Hide();
            this._createCardBtn.Location = COUNTER_TASKS == 1 ? new Point(this._createCardBtn.Location.X, CREATE_CARD_LOCATION_Y) : new Point(this._createCardBtn.Location.X, CREATE_CARD_LOCATION_Y + MOVE_TASK_Y);
            CREATE_CARD_LOCATION_Y = this._createCardBtn.Location.Y;
            this.editButton.cardMessageTextBox.ReadOnly = true; //????????
            this._createCardBtn.Show();
            COUNTER_TASKS++;
        }

        private void quitSavingCardButton_Click(object sender, EventArgs e)
        {
            _currentListTextBox.Text = "";
        }

        private void groupBoxTasks_Enter(object sender, EventArgs e)
        {
            string username = _parent.Username;

        }
    }
}