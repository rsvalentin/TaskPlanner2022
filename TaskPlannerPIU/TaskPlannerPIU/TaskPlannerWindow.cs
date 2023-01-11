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
        //private List<GroupBox> _groupBoxesLists = new List<GroupBox>();
        private MainWindow _parent;
        private TextBox _currentListTextBox;
        private string _selectedColumnName;
        private string _selectedTaskContent;
        private FlowLayoutPanel _listGroupBox;
        private Button _createCardBtn;
        private Dictionary<Button, int> cardButtonIndexList = new Dictionary<Button, int>();
        private EditButton cardMessageTextBox;
        private Button saveCardButton;
        private Button quitSavingCardButton;
        private Dictionary<Button, LastCardOfList> lastCardsOfLists = new Dictionary<Button, LastCardOfList>();

        int lastX = 0;
        Button addCard;
        TextBox cardMsg;
        Button saveCard;
        bool clickSave = false;
        private Dictionary<Button, int> saves = new Dictionary<Button, int>();
        private Dictionary<Button, int> adds = new Dictionary<Button, int>();
        private Dictionary<FlowLayoutPanel, int> mp = new Dictionary<FlowLayoutPanel, int>();
        private Dictionary<Button, TextBox> map = new Dictionary<Button, TextBox>();
        List<FlowLayoutPanel> flps = new List<FlowLayoutPanel>();
        int counterFlp = 0;

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
            this.labelWelcome.Font = new System.Drawing.Font("Lucida Handwriting", 10.2F, System.Drawing.FontStyle.Bold);
            this.labelWelcome.BackColor = Color.Transparent;
            // _groupBoxesLists.Add(this.initialListGroupBox);
        }
        // BUTONUL ADD LIST 
        private void btnAddList_Click(object sender, EventArgs e)
        {
            this.btnAddList.Location = new Point(this.btnAddList.Location.X + 150, this.btnAddList.Location.Y);
            this.btnAddList.Hide();
            this.saveListButton.Show();
            this.quitAddingListButton.Show();
            this.titleTextBox.Show();

            _selectedColumnName = titleTextBox.Text;
            titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            _currentListTextBox = titleTextBox;
            addCard = new Button();
            addCard.Text = "Add Card";
            FlowLayoutPanel flp = createFlp();
            lastX = saveListButton.Location.X;
            flp.Location = new Point(lastX, saveListButton.Location.Y + 20);
            lastX = flp.Location.X;



            flp.BackColor = Color.LightBlue;
            flp.Name = "flp";
            this.Controls.Add(flp);
            flp.Controls.Add(addCard);
            addCard.Click += new EventHandler(this.test);
            counterFlp++;
            addCard.Name = "Add" + counterFlp;
            adds.Add(addCard, counterFlp);
            mp.Add(flp, counterFlp);
            flps.Add(flp);
            setColumnTitle();
            //groupBoxTasks.Controls.Add(flp);
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
            //createAddCardButton();
            bool clickSaved = false;
            _createCardBtn = new Button();
            _createCardBtn.Text = "Add card";
            _createCardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);

            _createCardBtn.BackColor = Color.FromArgb(255, 187, 10, 33);
            // this._listGroupBox.Controls.Add(_createCardBtn);
            _createCardBtn.Location = new Point(this.saveListButton.Location.X, this.saveListButton.Location.Y + 5);
            _createCardBtn.Width = 70;
            // _createCardBtn.Click += new System.EventHandler(this.addCardButton_Click);
            this.saveListButton.Location = new Point(this.saveListButton.Location.X + 150, this.saveListButton.Location.Y);
            this.saveListButton.Hide();
            this.quitAddingListButton.Location = new Point(this.quitAddingListButton.Location.X + 150, this.quitAddingListButton.Location.Y);
            this.quitAddingListButton.Hide();
            //this.titleTextBox.Location = new Point(this.titleTextBox.Location.X + 150, this.titleTextBox.Location.Y);
            //this.titleTextBox.Hide();

            COUNTER_LISTS++;
            _currentListTextBox.Text = _selectedColumnName;
            this.btnAddList.Show();
            TextBox title = new TextBox();

            //setColumnTitle();
            //createNewGroupBoxForColumn();
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
            //this._listGroupBox.Controls.Add(textbox);
            this.titleTextBox.Text = "";
        }

        private void createNewGroupBoxForColumn()
        {
            this._listGroupBox = new FlowLayoutPanel();
            this._listGroupBox.BackColor = Color.FromArgb(255, 52, 159, 153);
            //this._listGroupBox.Location = new Point(LIST_GROUPBOX_POSITION_X + MOVE_GROUPBOX_X, this.initialFlp.Location.Y);
            LIST_GROUPBOX_POSITION_X = _listGroupBox.Location.X;
            //this._listGroupBox.Width = initialFlp.Width;
            //this._listGroupBox.Height = initialFlp.Height; // TODO: dynamic dupa nr de task uri din lista
            this._listGroupBox.Controls.Add(btnAddList);
            // this.groupBoxTasks.Controls.Add(_listGroupBox);
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
            //_createCardBtn.Click += new System.EventHandler(this.addCardButton_Click);

            cardButtonIndexList.Add(_createCardBtn, COUNTER_LISTS - 1);
            lastCardsOfLists.Add(_createCardBtn, new LastCardOfList { ListNumber = cardButtonIndexList[_createCardBtn], TaskNumberFromList = COUNTER_TASKS, YLocation = this.saveListButton.Location.Y + 5 - 16 });
        }

        /*
        private void addCardButton_Click(object sender, EventArgs e)
        {
            var index = cardButtonIndexList[_createCardBtn];
            var selectedGroupBox = _groupBoxesLists[index];
            var xLocation = 11;
            var lastTaskFromList = lastCardsOfLists[_createCardBtn];

            _createCardBtn.Hide();
            cardMessageTextBox = new EditButton();
            cardMessageTextBox.Width = this.titleTextBox.Width;
            cardMessageTextBox.Height = 30;
            selectedGroupBox.Controls.Add(cardMessageTextBox);
            cardMessageTextBox.Location = COUNTER_TASKS == 1 ? new Point(xLocation, CARD_LOCATION_Y) : new Point(xLocation, CARD_LOCATION_Y + MOVE_TASK_Y);
            CARD_LOCATION_Y = cardMessageTextBox.Location.Y;
            cardMessageTextBox.TextChanged += new System.EventHandler(this.cardMessageTextBox_TextChanged);

            saveCardButton = new Button();
            selectedGroupBox.Controls.Add(saveCardButton);
            saveCardButton.Text = "Save";
            saveCardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);

            saveCardButton.BackColor = Color.FromArgb(255, 187, 10, 33);

            saveCardButton.Location = COUNTER_TASKS == 1 ? new Point(xLocation, QUIT_SAVE_CARD_LOCATION_Y) : new Point(xLocation,QUIT_SAVE_CARD_LOCATION_Y + MOVE_TASK_Y);
            saveCardButton.Width = this.saveListButton.Width;
            saveCardButton.Click += new System.EventHandler(this.saveCardButton_Click);

            quitSavingCardButton = new Button();
            selectedGroupBox.Controls.Add(quitSavingCardButton);
            quitSavingCardButton.Text = "Quit";
            quitSavingCardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F,System.Drawing.FontStyle.Bold);
            quitSavingCardButton.ForeColor = System.Drawing.Color.White;
            quitSavingCardButton.BackColor = Color.FromArgb(255, 187, 10, 33);
            quitSavingCardButton.Location = COUNTER_TASKS == 1 ? new Point(xLocation + 52, QUIT_SAVE_CARD_LOCATION_Y) : new Point(xLocation + 52, QUIT_SAVE_CARD_LOCATION_Y + MOVE_TASK_Y);
            quitSavingCardButton.Width = this.saveListButton.Width;
            quitSavingCardButton.Click += new System.EventHandler(this.quitSavingCardButton_Click);

            QUIT_SAVE_CARD_LOCATION_Y = saveCardButton.Location.Y;
        }
        */
        private void cardMessageTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveCardButton_Click(object sender, EventArgs e)
        {
            this.saveCardButton.Hide();
            this.quitSavingCardButton.Hide();
            this._createCardBtn.Location = COUNTER_TASKS == 1 ? new Point(this._createCardBtn.Location.X, CREATE_CARD_LOCATION_Y) : new Point(this._createCardBtn.Location.X, CREATE_CARD_LOCATION_Y + MOVE_TASK_Y);
            CREATE_CARD_LOCATION_Y = this._createCardBtn.Location.Y;
            this.cardMessageTextBox.cardMessageTextBox.ReadOnly = true;
            this._createCardBtn.Show();
            COUNTER_TASKS++;
        }

        private void quitSavingCardButton_Click(object sender, EventArgs e)
        {
            _currentListTextBox.Text = "";
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

        private void groupBoxTasks_Enter(object sender, EventArgs e)
        {
            string username = _parent.Username;

        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {

        }
        private void initialListGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void labelWelcome_Click_1(object sender, EventArgs e)
        {

        }

        private FlowLayoutPanel createFlp()
        {
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.AllowDrop = true;
            flp.DragEnter += flp_DragEnter;
            flp.DragDrop += flp_DragDrop;
            flp.WrapContents = false;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.AutoScroll = true;
            flp.Size = new Size(100, 200);
            flp.BackColor = Color.LightBlue;
            flp.Name = "flp";
            return flp;
        }

        private void test(object sender, EventArgs e)
        {
            Button addCard = (Button)sender;
            FlowLayoutPanel flp = (FlowLayoutPanel)addCard.Parent;
            TextBox cardMsg = new TextBox();
            cardMsg.AutoSize = false;
            cardMsg.Name = "card";
            cardMsg.Height = 40;
            cardMsg.Show();

            saveCard = new Button();
            saveCard.Name = "Save";
            saveCard.Text = "Save Card";
            saveCard2();
            flp.Controls.Add(cardMsg);
            flp.Controls.Add(saveCard);
            map.Add(saveCard, cardMsg);
            if (clickSave == true)
            {
                cardMsg.Enabled = false;
            }
        }

        private void saveCard2()
        {
            saveCard.Click += new EventHandler(this.test2);
        }

        private void flp_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flp_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)e.Data.GetData(typeof(Button))).Parent = (Panel)sender;
        }

        private void test2(object sender, EventArgs e)
        {
            String msg = map[saveCard].Text.ToString();
            MessageBox.Show("sds = " + msg);
            saveCard.Hide();

        }

    }
}