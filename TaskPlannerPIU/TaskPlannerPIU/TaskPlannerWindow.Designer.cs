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
            this.saveListButton = new System.Windows.Forms.Button();
            this.quitAddingListButton = new System.Windows.Forms.Button();
            this.btnAddList = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.titleTextBox = new TaskPlannerPIU.CustomTextBox();
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
            // saveListButton
            // 
            this.saveListButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(10)))), ((int)(((byte)(33)))));
            this.saveListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveListButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saveListButton.Location = new System.Drawing.Point(106, 159);
            this.saveListButton.Name = "saveListButton";
            this.saveListButton.Size = new System.Drawing.Size(60, 35);
            this.saveListButton.TabIndex = 3;
            this.saveListButton.Text = "Save";
            this.saveListButton.UseVisualStyleBackColor = false;
            this.saveListButton.Click += new System.EventHandler(this.saveListButton_Click);
            // 
            // quitAddingListButton
            // 
            this.quitAddingListButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(10)))), ((int)(((byte)(33)))));
            this.quitAddingListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitAddingListButton.ForeColor = System.Drawing.Color.White;
            this.quitAddingListButton.Location = new System.Drawing.Point(172, 159);
            this.quitAddingListButton.Name = "quitAddingListButton";
            this.quitAddingListButton.Size = new System.Drawing.Size(65, 35);
            this.quitAddingListButton.TabIndex = 4;
            this.quitAddingListButton.Text = "Quit";
            this.quitAddingListButton.UseVisualStyleBackColor = false;
            this.quitAddingListButton.Click += new System.EventHandler(this.quitAddingListButton_Click);
            // 
            // btnAddList
            // 
            this.btnAddList.AllowDrop = true;
            this.btnAddList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(10)))), ((int)(((byte)(33)))));
            this.btnAddList.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddList.ForeColor = System.Drawing.Color.Black;
            this.btnAddList.Location = new System.Drawing.Point(97, 74);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(97, 32);
            this.btnAddList.TabIndex = 1;
            this.btnAddList.Text = "Add a list";
            this.btnAddList.UseMnemonic = false;
            this.btnAddList.UseVisualStyleBackColor = false;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(10)))), ((int)(((byte)(33)))));
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(814, 478);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(132, 45);
            this.buttonBack.TabIndex = 5;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // titleTextBox
            // 
            this.titleTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.titleTextBox.BorderColor = System.Drawing.Color.DarkGray;
            this.titleTextBox.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(10)))), ((int)(((byte)(33)))));
            this.titleTextBox.BorderSize = 3;
            this.titleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.ForeColor = System.Drawing.Color.Black;
            this.titleTextBox.IsPassswordText = false;
            this.titleTextBox.Location = new System.Drawing.Point(97, 122);
            this.titleTextBox.Multiline = true;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Padding = new System.Windows.Forms.Padding(7);
            this.titleTextBox.Size = new System.Drawing.Size(164, 31);
            this.titleTextBox.TabIndex = 6;
            this.titleTextBox.Texts = "";
            // 
            // TaskPlannerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TaskPlannerPIU.Properties.Resources.piu_copy;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.btnAddList);
            this.Controls.Add(this.quitAddingListButton);
            this.Controls.Add(this.saveListButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskPlannerWindow";
            this.Text = "Task Planner";
            this.Load += new System.EventHandler(this.TaskPlannerWindow_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TaskPlannerWindow_Scroll);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button saveListButton;
        private System.Windows.Forms.Button quitAddingListButton;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.Button buttonBack;
        private CustomTextBox titleTextBox;
    }
}