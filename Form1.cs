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
        public Form1()
        {
            InitializeComponent();
        }

        Task task;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private void LoadProcesses()
        {
            task = new Task(() => {
                List<Process> processes = Process.GetProcesses().ToList();
                processes.ForEach(item => {
                    if (!this.listView1.InvokeRequired)
                        this.listView1.Items.Add(new ListViewItem(item.Id + '-' + item.ProcessName));
                    else this.listView1.Invoke(new Action(() => {
                        this.listView1.Items.Add(new ListViewItem(item.Id + '-' + item.ProcessName));
                    }));
                });
            });
            task.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }
    }
}
