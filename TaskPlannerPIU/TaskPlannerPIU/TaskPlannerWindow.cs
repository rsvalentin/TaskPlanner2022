﻿using System;
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
        private MainWindow _parent;
        private string _selectedColumnName;
        private EditButton editButton;
        private Button addCardButton;
        private Button saveCardButton;
        private Button quitSavingCardButton;

        int lastX = 0;
        bool clickSave = false;
        private Dictionary<Button, int> adds = new Dictionary<Button, int>();
        private Dictionary<FlowLayoutPanel, int> mp = new Dictionary<FlowLayoutPanel, int>();
        private Dictionary<Button, EditButton> map = new Dictionary<Button, EditButton>();
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
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            this.btnAddList.Location = new Point(this.btnAddList.Location.X + 150, this.btnAddList.Location.Y);
            this.btnAddList.Hide();
            this.saveListButton.Show();
            this.quitAddingListButton.Show();
            this.titleTextBox.Show();

            _selectedColumnName = titleTextBox.Text;
            titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);

            addCardButton = new Button();
            addCardButton.Text = "Add Card";
            FlowLayoutPanel flp = createFlp();
            lastX = saveListButton.Location.X;
            flp.Location = new Point(lastX, saveListButton.Location.Y + 20);
            lastX = flp.Location.X;

            flp.BackColor = Color.LightBlue;
            flp.Name = "flp";
            this.Controls.Add(flp);
            flp.Controls.Add(addCardButton);
            addCardButton.Click += new EventHandler(this.addCard_click);
            counterFlp++;
            addCardButton.Name = "Add" + counterFlp;
            adds.Add(addCardButton, counterFlp);
            mp.Add(flp, counterFlp);
            flps.Add(flp);
           
        }


        private void quitAddingListButton_Click(object sender, EventArgs e)
        {
             titleTextBox.Text = "";
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            _selectedColumnName = titleTextBox.Text;
        }

        private void TaskPlannerWindow_Scroll(object sender, ScrollEventArgs e)
        {
            labelWelcome.Location = new Point(3, 8);
        }

        private void saveListButton_Click(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox();
            textBox.Location = titleTextBox.Location;
            var text = _selectedColumnName;
            textBox.Text = text;
            textBox.ReadOnly = true;

            titleTextBox.Location = new Point(this.titleTextBox.Location.X + 150, this.titleTextBox.Location.Y);
            titleTextBox.Hide();
            titleTextBox.Text = "";

            this.Controls.Add(textBox);
            textBox.Show();

            this.saveListButton.Location = new Point(this.saveListButton.Location.X + 150, this.saveListButton.Location.Y);
            this.saveListButton.Hide();
            this.quitAddingListButton.Location = new Point(this.quitAddingListButton.Location.X + 150, this.quitAddingListButton.Location.Y);
            this.quitAddingListButton.Hide();

            COUNTER_LISTS++;
            textBox.Text = _selectedColumnName;
            this.btnAddList.Show();
            
        }

        private void quitSavingCardButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = "";
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

        private void addCard_click(object sender, EventArgs e)
        {
            Button addCard = (Button)sender;
            FlowLayoutPanel flp = (FlowLayoutPanel)addCard.Parent;

            editButton = new EditButton(flp);
            editButton.cardMessageTextBox.Width = 80;
            editButton.cardMessageTextBox.AutoSize = false;
            editButton.cardMessageTextBox.Height = 40;
            editButton.Show();

            saveCardButton = new Button();
            saveCardButton.Text = "Save Card";
            saveCardButton.Click += new EventHandler(this.saveCard_Click);
            flp.Controls.Add(saveCardButton);
            map.Add(saveCardButton, editButton);
            if (clickSave == true)
            {
                editButton.Enabled = false;
            }
        }

        private void flp_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flp_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)e.Data.GetData(typeof(Button))).Parent = (Panel)sender;
        }

        private void saveCard_Click(object sender, EventArgs e)
        {
            String msg = map[saveCardButton].Text.ToString();
            saveCardButton.Hide();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            _parent.Show();
        }
    }
}