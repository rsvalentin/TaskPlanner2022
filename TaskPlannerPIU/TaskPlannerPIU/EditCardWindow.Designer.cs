namespace TaskPlannerPIU
{
    partial class EditCardWindow
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveChangesButton = new TaskPlannerPIU.CustomButton();
            this.editCardTitle = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(196)))));
            this.groupBox1.Controls.Add(this.saveChangesButton);
            this.groupBox1.Controls.Add(this.editCardTitle);
            this.groupBox1.Location = new System.Drawing.Point(45, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(10)))), ((int)(((byte)(33)))));
            this.saveChangesButton.FlatAppearance.BorderSize = 0;
            this.saveChangesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveChangesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.saveChangesButton.ForeColor = System.Drawing.Color.Black;
            this.saveChangesButton.Location = new System.Drawing.Point(147, 97);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(134, 28);
            this.saveChangesButton.TabIndex = 1;
            this.saveChangesButton.Text = "Save changes";
            this.saveChangesButton.UseVisualStyleBackColor = false;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // editCardTitle
            // 
            this.editCardTitle.Location = new System.Drawing.Point(21, 45);
            this.editCardTitle.Name = "editCardTitle";
            this.editCardTitle.Size = new System.Drawing.Size(392, 22);
            this.editCardTitle.TabIndex = 0;
            this.editCardTitle.TextChanged += new System.EventHandler(this.editCardTitle_TextChanged);
            // 
            // EditCardWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TaskPlannerPIU.Properties.Resources.piu_copy;
            this.ClientSize = new System.Drawing.Size(532, 303);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditCardWindow";
            this.Text = "Edit Card";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox editCardTitle;
        private CustomButton saveChangesButton;
    }
}