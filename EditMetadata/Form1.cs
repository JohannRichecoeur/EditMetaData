using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EditMetadata
{
    public sealed partial class Form1 : Form
    {
        private readonly BindingSource _bindingSource = new BindingSource();

        public Form1()
        {
            this.InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += this.Form1DragEnter;
            this.DragDrop += this.Form1DragDrop;
            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


            // Initialize and add a text box column.
            CreateColumn("Path");
            CreateColumn("CurrentDate");
            CreateColumn("ExpectedDate");

            this.status.Text = "";

            void CreateColumn(string label)
            {
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = label;
                column.Name = label;
                this.dataGridView.Columns.Add(column);
            }
        }

        private void FolderButtonClick(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                var folder = this.folderBrowserDialog.SelectedPath;
                var folderName = folder.Split('\\').Last();
                this.FillFiles(Directory.GetFiles(folder), folderName);
            }
        }

        private void ChangeDateTimeButtonClick(object sender, EventArgs e)
        {
            this.status.Text = "Ongoing";
            this.status.ForeColor = Color.Gray;

            var counter = 1;
            foreach (var g in from DataGridViewRow g in this.dataGridView.Rows where g.Cells[0].Value != null && g.Cells[1].Value != null select g)
            {
                ProcessingLabel.Text = counter + " sur " + (this.dataGridView.RowCount - 1);
                ProcessingLabel.Refresh();

                Metadata.ChangeDateTime((string)g.Cells[0].Value, (DateTime)g.Cells[2].Value);
                counter++;
            }

            this.status.Text = "DONE";
            this.status.ForeColor = Color.ForestGreen;
  
            this.ReloadDates();
        }

        private void ClearButtonClick(object sender, EventArgs e)
        {
            _bindingSource.Clear();
            this.status.Text = "";
            this.label1.Text = "";
            this.ProcessingLabel.Text = "";
        }

        private void Form1DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Form1DragDrop(object sender, DragEventArgs e)
        {
            var folders = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var folder in folders)
            {
                if (!folder.ToUpper().EndsWith(".JPG"))
                {
                    this.FillFiles(Directory.GetFiles(folder), folder.Split('\\').Last());
                }
                else
                {
                    this.label1.Text = "Add a folder only, no files alone";
                    break;
                }
            }
        }

        private void FillFiles(string[] filePaths, string folderName)
        {
            this.label1.Text = folderName;

            var counter = 1;
            for (int i = 0; i < _bindingSource.Count; i++)
            {
                if (((Row)_bindingSource[i]).Path == null)
                {
                    _bindingSource.RemoveAt(i);
                }
            }

            foreach (var filePath in filePaths)
            {
                ProcessingLabel.Text = counter + " sur " + filePaths.Length;
                ProcessingLabel.Refresh();

                var date = Metadata.GetDate(filePath);
                var newDate = Metadata.ExtractNewDate(filePath);
                _bindingSource.Add(new Row { Path = filePath, CurrentDate = date, ExpectedDate = newDate });

                counter++;
            }

            this.dataGridView.DataSource = _bindingSource;

            this.status.Text = "Ready";
            this.status.ForeColor = Color.Black;
        }

        private void ReloadDates()
        {
            foreach (Row entry in _bindingSource)
            {
                entry.CurrentDate = Metadata.GetDate(entry.Path);
            }

            _bindingSource.ResetBindings(false);
        }
    }
}