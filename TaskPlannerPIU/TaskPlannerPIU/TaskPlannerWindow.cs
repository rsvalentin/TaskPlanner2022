using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TaskPlannerPIU.database;

namespace TaskPlannerPIU
{
    public partial class TaskPlannerWindow : Form
    {
        private MainWindow _parent;
        private EditButton _editButton;
        private Button _addCardButton;
        private Button _saveCardButton;

        private Dictionary<Button, int> _addCardButtonIndex = new Dictionary<Button, int>();
        private Dictionary<Button, EditButton> _saveCardButtonEditButton = new Dictionary<Button, EditButton>();
        private string _selectedColumnName;
        private int _counterFlp = 0;
        private int _lastX = 0;


        public TaskPlannerWindow(MainWindow parent, DatabaseConnection connection)
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
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            this.btnAddList.Location = new Point(this.btnAddList.Location.X + 150, this.btnAddList.Location.Y);
            this.btnAddList.Hide();
            this.saveListButton.Show();
            this.quitAddingListButton.Show();
            this.titleTextBox.Show();

            FlowLayoutPanel flp = createFlp();
            _lastX = saveListButton.Location.X;
            flp.Location = new Point(_lastX - 12, saveListButton.Location.Y + 35);
            _lastX = flp.Location.X;

            titleTextBox.Width = 121;
            titleTextBox.IsPassswordText = true;

            _addCardButton = new Button();
            _addCardButton.Text = "Add Card";
            _addCardButton.BackColor = Color.FromArgb(255, 187, 10, 33);
            _addCardButton.Width = 100;
            _addCardButton.Height = 28;

            this.Controls.Add(flp);
            flp.Controls.Add(_addCardButton);

            _addCardButton.Click += new EventHandler(this.addCard_click);
            _counterFlp++;
            _addCardButton.Name = "Add" + _counterFlp;
            _addCardButtonIndex.Add(_addCardButton, _counterFlp);
        }

        private void quitAddingListButton_Click(object sender, EventArgs e)
        {
            titleTextBox.myTextBox.Text = "";
        }


        private void TaskPlannerWindow_Scroll(object sender, ScrollEventArgs e)
        {
            labelWelcome.Location = new Point(3, 8);
        }

        private void saveListButton_Click(object sender, EventArgs e)
        {
            _selectedColumnName = titleTextBox.Text;
            if (_selectedColumnName == null || _selectedColumnName == "")
            {
                MessageBox.Show("You didn't enter a title!");
                return;
            }

            CustomTextBox textBox = new CustomTextBox();
            textBox.Location = titleTextBox.Location;
            textBox.Width = 121;
            textBox.Height = 26;
            this.Controls.Add(textBox);
            textBox.Show();
            textBox.Focus();
            titleTextBox.Location = new Point(this.titleTextBox.Location.X + 150, this.titleTextBox.Location.Y);
            titleTextBox.Hide();

            textBox.myTextBox.Text = _selectedColumnName;
            textBox.myTextBox.ReadOnly = true;
            textBox.IsPassswordText = true;
            titleTextBox.myTextBox.Text = String.Empty;

            this.saveListButton.Location = new Point(this.saveListButton.Location.X + 150, this.saveListButton.Location.Y);
            this.saveListButton.Hide();
            this.quitAddingListButton.Location = new Point(this.quitAddingListButton.Location.X + 150, this.quitAddingListButton.Location.Y);
            this.quitAddingListButton.Hide();
            this.btnAddList.Show();
            _selectedColumnName = "";
        }

        private void quitSavingCardButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = "";
        }

        private FlowLayoutPanel createFlp()
        {
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.BackColor = Color.FromArgb(100, 0, 102, 77);
            flp.AllowDrop = true;
            flp.DragEnter += new DragEventHandler(flp_DragEnter);
            flp.MouseDown += new MouseEventHandler(EditButton.CardMessageTextBox_MouseDown);
            flp.DragDrop += new DragEventHandler(flp_DragDrop);
            flp.DragEnter += flp_DragEnter;
            flp.DragDrop += flp_DragDrop;
            flp.WrapContents = false;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.AutoScroll = true;
            flp.Size = new Size(140, 250);
            flp.Name = "flp";
            flp.Padding = new Padding(17, 17, 17, 17);
            return flp;
        }

        private void addCard_click(object sender, EventArgs e)
        {
            Button addCard = (Button)sender;
            FlowLayoutPanel flp = (FlowLayoutPanel)addCard.Parent;

            _editButton = new EditButton(flp);
            _editButton.Show();

            _saveCardButton = new Button();
            _saveCardButton.BackColor = Color.FromArgb(255, 52, 159, 153);
            _saveCardButton.Text = "Save Card";
            _saveCardButton.Click += new EventHandler(this.saveCard_Click);
            flp.Controls.Add(_saveCardButton);
            _saveCardButtonEditButton.Add(_saveCardButton, _editButton);
        }

        private void flp_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void flp_DragDrop(object sender, DragEventArgs e)
        {
            ((TextBox)e.Data.GetData(typeof(TextBox))).Parent = (FlowLayoutPanel)sender;
        }

        private void saveCard_Click(object sender, EventArgs e)
        {
            string msg = _saveCardButtonEditButton[_saveCardButton].cardMessageTextBox.Text.ToString();
            if (msg != String.Empty)
            {
                _editButton.cardMessageTextBox.ReadOnly = true;
                _saveCardButton.Hide();
            }
            else
            {
                MessageBox.Show("Please enter some text!");
                return;
            }

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            _parent.Show();
        }
    }
}