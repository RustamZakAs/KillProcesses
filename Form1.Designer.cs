
namespace KillProcesses
{
    partial class FormMain
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "asd",
            "asdfghdf"}, -1);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLoad = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.rbProcesses = new System.Windows.Forms.RadioButton();
            this.rbServices = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(43, 97);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(333, 212);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 257;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(301, 42);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(43, 71);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(333, 20);
            this.tbSearch.TabIndex = 2;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // rbProcesses
            // 
            this.rbProcesses.AutoSize = true;
            this.rbProcesses.Checked = true;
            this.rbProcesses.Location = new System.Drawing.Point(43, 45);
            this.rbProcesses.Name = "rbProcesses";
            this.rbProcesses.Size = new System.Drawing.Size(74, 17);
            this.rbProcesses.TabIndex = 3;
            this.rbProcesses.TabStop = true;
            this.rbProcesses.Text = "Processes";
            this.rbProcesses.UseVisualStyleBackColor = true;
            // 
            // rbServices
            // 
            this.rbServices.AutoSize = true;
            this.rbServices.Location = new System.Drawing.Point(134, 45);
            this.rbServices.Name = "rbServices";
            this.rbServices.Size = new System.Drawing.Size(66, 17);
            this.rbServices.TabIndex = 4;
            this.rbServices.TabStop = true;
            this.rbServices.Text = "Services";
            this.rbServices.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 348);
            this.Controls.Add(this.rbServices);
            this.Controls.Add(this.rbProcesses);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.listView1);
            this.Name = "FormMain";
            this.Text = "Processes & Services";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.RadioButton rbProcesses;
        private System.Windows.Forms.RadioButton rbServices;
    }
}

