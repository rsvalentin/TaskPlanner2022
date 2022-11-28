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
            this.groupBoxTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(807, 31);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(88, 20);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome, ";
            // 
            // btnAddList
            // 
            this.btnAddList.AllowDrop = true;
            this.btnAddList.Location = new System.Drawing.Point(40, 50);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(91, 28);
            this.btnAddList.TabIndex = 1;
            this.btnAddList.Text = "Add a list";
            this.btnAddList.UseMnemonic = false;
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // groupBoxTasks
            // 
            this.groupBoxTasks.Controls.Add(this.btnAddList);
            this.groupBoxTasks.Controls.Add(this.initialListGroupBox);
            this.groupBoxTasks.Location = new System.Drawing.Point(28, 74);
            this.groupBoxTasks.Name = "groupBoxTasks";
            this.groupBoxTasks.Size = new System.Drawing.Size(922, 448);
            this.groupBoxTasks.TabIndex = 2;
            this.groupBoxTasks.TabStop = false;
            // 
            // initialListGroupBox
            // 
            this.initialListGroupBox.Location = new System.Drawing.Point(5, 20);
            this.initialListGroupBox.Name = "initialListGroupBox";
            this.initialListGroupBox.Size = new System.Drawing.Size(150, 230);
            this.initialListGroupBox.TabIndex = 2;
            this.initialListGroupBox.TabStop = false;
            this.initialListGroupBox.Enter += new System.EventHandler(this.initialListGroupBox_Enter);
            // 
            // TaskPlannerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.groupBoxTasks);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TaskPlannerWindow";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.TaskPlannerWindow_Load);
            this.groupBoxTasks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.GroupBox groupBoxTasks;
        private System.Windows.Forms.GroupBox initialListGroupBox;
    }
}