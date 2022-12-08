namespace TaskPlannerPIU
{
    partial class TaskPlannerWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelWelcome = new System.Windows.Forms.Label();
            this.btnAddList = new System.Windows.Forms.Button();
            this.groupBoxTasks = new System.Windows.Forms.GroupBox();
            this.initialListGroupBox = new System.Windows.Forms.GroupBox();
            this.quitAddingListButton = new System.Windows.Forms.Button();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.saveListButton = new System.Windows.Forms.Button();
            this.groupBoxTasks.SuspendLayout();
            this.initialListGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Lucida Handwriting", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(11, 7);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(104, 23);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome, ";
            // 
            // btnAddList
            // 
            this.btnAddList.AllowDrop = true;
            this.btnAddList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(10)))), ((int)(((byte)(33)))));
            this.btnAddList.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddList.ForeColor = System.Drawing.Color.Black;
            this.btnAddList.Location = new System.Drawing.Point(25, 40);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(91, 28);
            this.btnAddList.TabIndex = 1;
            this.btnAddList.Text = "Add a list";
            this.btnAddList.UseMnemonic = false;
            this.btnAddList.UseVisualStyleBackColor = false;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // groupBoxTasks
            // 
            this.groupBoxTasks.AutoSize = true;
            this.groupBoxTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(196)))));
            this.groupBoxTasks.Controls.Add(this.initialListGroupBox);
            this.groupBoxTasks.Location = new System.Drawing.Point(25, 59);
            this.groupBoxTasks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxTasks.Name = "groupBoxTasks";
            this.groupBoxTasks.Size = new System.Drawing.Size(922, 448);
            this.groupBoxTasks.TabIndex = 2;
            this.groupBoxTasks.TabStop = false;
            this.groupBoxTasks.Enter += new System.EventHandler(this.groupBoxTasks_Enter);
            // 
            // initialListGroupBox
            // 
            this.initialListGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(159)))), ((int)(((byte)(153)))));
            this.initialListGroupBox.Controls.Add(this.quitAddingListButton);
            this.initialListGroupBox.Controls.Add(this.titleTextBox);
            this.initialListGroupBox.Controls.Add(this.saveListButton);
            this.initialListGroupBox.Controls.Add(this.btnAddList);
            this.initialListGroupBox.Location = new System.Drawing.Point(15, 20);
            this.initialListGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.initialListGroupBox.Name = "initialListGroupBox";
            this.initialListGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.initialListGroupBox.Size = new System.Drawing.Size(146, 404);
            this.initialListGroupBox.TabIndex = 2;
            this.initialListGroupBox.TabStop = false;
            // 
            // quitAddingListButton
            // 
            this.quitAddingListButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(10)))), ((int)(((byte)(33)))));
            this.quitAddingListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitAddingListButton.ForeColor = System.Drawing.Color.White;
            this.quitAddingListButton.Location = new System.Drawing.Point(78, 40);
            this.quitAddingListButton.Name = "quitAddingListButton";
            this.quitAddingListButton.Size = new System.Drawing.Size(58, 23);
            this.quitAddingListButton.TabIndex = 4;
            this.quitAddingListButton.Text = "Quit";
            this.quitAddingListButton.UseVisualStyleBackColor = false;
            this.quitAddingListButton.Click += new System.EventHandler(this.quitAddingListButton_Click_1);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(15, 12);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(121, 22);
            this.titleTextBox.TabIndex = 3;
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged_1);
            // 
            // saveListButton
            // 
            this.saveListButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(10)))), ((int)(((byte)(33)))));
            this.saveListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveListButton.ForeColor = System.Drawing.Color.Black;
            this.saveListButton.Location = new System.Drawing.Point(15, 40);
            this.saveListButton.Name = "saveListButton";
            this.saveListButton.Size = new System.Drawing.Size(58, 23);
            this.saveListButton.TabIndex = 3;
            this.saveListButton.Text = "Save";
            this.saveListButton.UseVisualStyleBackColor = false;
            this.saveListButton.Click += new System.EventHandler(this.addListButton_Click);
            // 
            // TaskPlannerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TaskPlannerPIU.Properties.Resources.piu_copy;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.groupBoxTasks);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TaskPlannerWindow";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.TaskPlannerWindow_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TaskPlannerWindow_Scroll);
            this.groupBoxTasks.ResumeLayout(false);
            this.initialListGroupBox.ResumeLayout(false);
            this.initialListGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.GroupBox groupBoxTasks;
        private System.Windows.Forms.GroupBox initialListGroupBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Button saveListButton;
        private System.Windows.Forms.Button quitAddingListButton;

    }
}