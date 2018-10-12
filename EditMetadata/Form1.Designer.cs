namespace EditMetadata
{
    public sealed partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button folderButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button clearButton;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.folderButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.renameButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.ProcessingLabel = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // folderButton
            // 
            this.folderButton.Location = new System.Drawing.Point(12, 12);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(75, 23);
            this.folderButton.TabIndex = 0;
            this.folderButton.Text = "Select folder";
            this.folderButton.UseVisualStyleBackColor = true;
            this.folderButton.Click += new System.EventHandler(this.FolderButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "selected folder";
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(15, 90);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(888, 181);
            this.dataGridView.TabIndex = 2;
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(790, 12);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(113, 50);
            this.renameButton.TabIndex = 3;
            this.renameButton.Text = "Change DateTime";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.ChangeDateTimeButtonClick);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(15, 277);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButtonClick);
            // 
            // ProcessingLabel
            // 
            this.ProcessingLabel.AutoSize = true;
            this.ProcessingLabel.Location = new System.Drawing.Point(340, 20);
            this.ProcessingLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProcessingLabel.Name = "ProcessingLabel";
            this.ProcessingLabel.Size = new System.Drawing.Size(35, 13);
            this.ProcessingLabel.TabIndex = 5;
            this.ProcessingLabel.Text = "label2";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(390, 282);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 13);
            this.status.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(915, 312);
            this.Controls.Add(this.status);
            this.Controls.Add(this.ProcessingLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.folderButton);
            this.Name = "Form1";
            this.Text = "Edit Metadata";
            //this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProcessingLabel;
        private System.Windows.Forms.Label status;
    }
}

