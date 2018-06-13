using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Entities;
using TaskManager.Repository;

namespace TaskManager
{
    /// <summary>
    ///
    /// </summary>
    public partial class MainWindow : Window
    {
        private MonitoredProcessesRepository repository;

        public MainWindow()
        {
            InitializeComponent();
            repository = new MonitoredProcessesRepository();

            theBlock.Text = repository.MonitoredProcesses.Select(x => x.My_ProcessName).Single();
            theBlock1.Text = repository.MonitoredProcesses.Select(x => x.My_ProcessName).Single();
            theBlock2.Text = repository.MonitoredProcesses.Select(x => x.My_ProcessName).Single();
            theBlock3.Text = repository.MonitoredProcesses.Select(x => x.My_ProcessName).Single();
            theBlock4.Text = repository.MonitoredProcesses.Select(x => x.My_ProcessName).Single();
            theBlock5.Text = repository.MonitoredProcesses.Select(x => x.My_ProcessName).Single();
            theBlock6.Text = repository.MonitoredProcesses.Select(x => x.My_ProcessName).Single();
            theBlock7.Text = repository.MonitoredProcesses.Select(x => x.My_ProcessName).Single();
            theBlock8.Text = repository.MonitoredProcesses.Select(x => x.My_ProcessName).Single();
            theBlock9.Text = repository.MonitoredProcesses.Select(x => x.My_ProcessName).Single();
            theBlock10.Text = repository.MonitoredProcesses.Select(x => x.My_ProcessName).Single();
            theBlock11.Text = repository.MonitoredProcesses.Select(x => x.My_ProcessName).Single();
            theBlock12.Text = repository.MonitoredProcesses.Select(x => x.My_ProcessName).Single();

            #region test

            //Process proc = Process.GetProcessesByName("devenv")[0];
            //List<string> vs = new List<string>();
            //string outList = "";

            //System.Diagnostics.Process[] processes;
            //processes = System.Diagnostics.Process.GetProcesses();
            //foreach (System.Diagnostics.Process instance in processes)
            //{
            //    vs.Add(instance.ProcessName);
            //    outList += instance.ProcessName + "\n";
            //}
            //MessageBox.Show(outList);

            #endregion test
        }
    }
}