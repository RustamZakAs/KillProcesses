using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KillProcesses
{
    public partial class Form1 : Form
    {
        private bool isRunned = false;
        public bool IsRunned
        {
            get { return isRunned; }
            set { isRunned = value; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        Task task;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        List<Process> processes;
        private void LoadProcesses()
        {
            this.IsRunned = true;
            task = new Task(() => {
                processes = Process.GetProcesses().ToList();
                processes.ForEach(item => {
                    if (!this.listView1.InvokeRequired)
                        this.listView1.Items.Add(new ListViewItem(item.Id + '-' + item.ProcessName));
                    else this.listView1.Invoke(new Action(() => {
                        this.listView1.Items.Add(new ListViewItem(item.Id + '-' + item.ProcessName));
                    }));
                });
                this.IsRunned = false;
            });
            task.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.IsRunned)
                LoadProcesses();
        }
    }
}
