using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KillProcesses
{
    public partial class FormMain : Form
    {
        private bool isRunned = false;
        public bool IsRunned
        {
            get { return isRunned; }
            set { isRunned = value; }
        }

        public FormMain()
        {
            InitializeComponent();
        }

        Task task;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        List<Process> processes;
        List<ServiceController> services;
        private void LoadProcesses()
        {
            this.IsRunned = true;
            this.listView1.Items.Clear();
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

        private void LoadServices()
        {
            this.IsRunned = true;
            this.listView1.Items.Clear();
            task = new Task(() => {
                services = ServiceController.GetServices().ToList();
                services.ForEach(item => {
                    if (!this.listView1.InvokeRequired)
                        this.listView1.Items.Add(new ListViewItem(item.ServiceName));
                    else this.listView1.Invoke(new Action(() => {
                        this.listView1.Items.Add(new ListViewItem(item.ServiceName));
                    }));
                });
                this.IsRunned = false;
            });
            task.Start();
        }

        public static bool IsServiceInstalled(string serviceName)
        {
            // get list of Windows services
            ServiceController[] services = ServiceController.GetServices();

            // try to find service name
            foreach (ServiceController service in services)
                if (service.ServiceName == serviceName)
                    return true;
            return false;
        }

        public static void StartWindowsService(string serviceName)
        {
            ServiceController serviceController = new ServiceController(serviceName);
            TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
            serviceController.Start();
            serviceController.WaitForStatus(ServiceControllerStatus.Running, timeout);
        }

        public static void StopWindowsService(string serviceName)
        {
            ServiceController serviceController = new ServiceController(serviceName);
            TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
            serviceController.Stop();
            serviceController.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
        }

        public static void RestartWindowsService(string serviceName)
        {
            ServiceController serviceController = new ServiceController(serviceName);
            int tickCount1 = Environment.TickCount;
            int tickCount2 = Environment.TickCount;
            TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
            serviceController.Stop();
            serviceController.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

            timeout = TimeSpan.FromMilliseconds(1000 - (tickCount1 - tickCount2));
            serviceController.Start();
            serviceController.WaitForStatus(ServiceControllerStatus.Running, timeout);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!this.IsRunned)
            {
                if (this.rbProcesses.Checked)
                    LoadProcesses();
                else if (this.rbServices.Checked)
                    LoadServices();
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchedText = this.tbSearch.Text;
                this.listView1.Items.Clear();
                if (this.rbProcesses.Checked)
                {
                    var temp = processes.Where(x => x.ProcessName.Contains(searchedText)).ToList();
                    temp.ForEach(item => {
                        if (!this.listView1.InvokeRequired)
                            this.listView1.Items.Add(new ListViewItem(item.Id + '-' + item.ProcessName));
                        else this.listView1.Invoke(new Action(() => {
                            this.listView1.Items.Add(new ListViewItem(item.Id + '-' + item.ProcessName));
                        }));
                    });
                }
                else if (this.rbServices.Checked)
                {
                    var temp = services.Where(x => x.ServiceName.Contains(searchedText)).ToList();
                    temp.ForEach(item => {
                        if (!this.listView1.InvokeRequired)
                            this.listView1.Items.Add(new ListViewItem(item.ServiceName));
                        else this.listView1.Invoke(new Action(() => {
                            this.listView1.Items.Add(new ListViewItem(item.ServiceName));
                        }));
                    });
                }
            }
            catch (Exception ex)
            {
                return;
                throw;
            }
        }
    }
}
