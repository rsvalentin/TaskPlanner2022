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
            this.groupBoxTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(12, 9);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(105, 25);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome, ";
            // 
            // btnAddList
            // 
            this.btnAddList.AllowDrop = true;
            this.btnAddList.Location = new System.Drawing.Point(45, 62);
            this.btnAddList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(102, 35);
            this.btnAddList.TabIndex = 1;
            this.btnAddList.Text = "Add a list";
            this.btnAddList.UseMnemonic = false;
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // groupBoxTasks
            // 
            this.groupBoxTasks.AutoSize = true;
            this.groupBoxTasks.Controls.Add(this.btnAddList);
            this.groupBoxTasks.Location = new System.Drawing.Point(32, 92);
            this.groupBoxTasks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxTasks.Name = "groupBoxTasks";
            this.groupBoxTasks.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxTasks.Size = new System.Drawing.Size(1037, 560);
            this.groupBoxTasks.TabIndex = 2;
            this.groupBoxTasks.TabStop = false;
            this.groupBoxTasks.Enter += new System.EventHandler(this.groupBoxTasks_Enter);
            // 
            // TaskPlannerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 691);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.groupBoxTasks);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TaskPlannerWindow";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.TaskPlannerWindow_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TaskPlannerWindow_Scroll);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TaskPlannerWindow_Paint);
            this.groupBoxTasks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.GroupBox groupBoxTasks;
    }
}