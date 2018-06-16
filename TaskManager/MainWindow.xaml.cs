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
using System.Threading;
using System.Windows.Threading;
using System.Data;

namespace TaskManager
{
    /// <summary>
    ///
    /// </summary>
    public partial class MainWindow : Window
    {
        private MonitoredProcessesRepository repository;
        private DispatcherTimer dt = new DispatcherTimer();
        public int selectedIndx = 0;

        public MainWindow()
        {
            InitializeComponent();
            repository = new MonitoredProcessesRepository();

            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 1);
            dt.Start();
        }

        private void dt_Tick(object sender, EventArgs e)
        {
            Wind_Reload();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region test_load

            //theBlock.Text = repository.MonitoredProcesses.Select(x => x.My_ProcessName).Single();
            //theBlock1.Text = repository.MonitoredProcesses.Select(x => x.My_PagedMemorySize64).Single().ToString();
            //theBlock2.Text = repository.MonitoredProcesses.Select(x => x.My_BaisePriority).Single().ToString();
            //theBlock3.Text = repository.MonitoredProcesses.Select(x => x.My_SessionId).Single().ToString();
            //theBlock4.Text = repository.MonitoredProcesses.Select(x => x.My_PagedSystemMemorySize64).Single().ToString();
            //theBlock5.Text = repository.MonitoredProcesses.Select(x => x.My_NonpagedSystemMemorySize64).Single().ToString();
            //theBlock6.Text = repository.MonitoredProcesses.Select(x => x.My_PeakPagedMemorySize64).Single().ToString();
            //theBlock7.Text = repository.MonitoredProcesses.Select(x => x.My_PeakVirtualMemorySize64).Single().ToString();
            //theBlock8.Text = repository.MonitoredProcesses.Select(x => x.My_PeakWorkingSet64).Single().ToString();
            //theBlock9.Text = repository.MonitoredProcesses.Select(x => x.My_PrivateMemorySize64).Single().ToString();
            //theBlock10.Text = repository.MonitoredProcesses.Select(x => x.My_StartTime).Single().ToString();
            //theBlock11.Text = repository.MonitoredProcesses.Select(x => x.My_TotalProcessorTime).Single().ToString();
            //theBlock12.Text = repository.MonitoredProcesses.Select(x => x.My_UserProcessorTime).Single().ToString();

            #endregion test_load

            Wind_Reload();
        }

        private void RibbonHelpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Helper text");
        }

        private void RibbonApplicationMenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Wind_Reload()
        {
            repository.MonitoredProcesses.Clear();
            System.Diagnostics.Process[] processes;
            processes = System.Diagnostics.Process.GetProcesses();
            foreach (Process instance in processes)
            {
                try
                {
                    repository.Add((new MonitoredProcess()
                    {
                        My_BaisePriority = instance.BasePriority,
                        My_Id = instance.Id,
                        My_NonpagedSystemMemorySize64 = instance.NonpagedSystemMemorySize64,
                        My_PagedMemorySize64 = instance.PagedMemorySize64,
                        My_PagedSystemMemorySize64 = instance.PagedSystemMemorySize64,
                        My_PeakPagedMemorySize64 = instance.PeakPagedMemorySize64,
                        My_PeakVirtualMemorySize64 = instance.PeakVirtualMemorySize64,
                        My_PeakWorkingSet64 = instance.PeakWorkingSet64,
                        My_PrivateMemorySize64 = instance.PrivateMemorySize64,
                        My_ProcessName = instance.ProcessName,
                        My_SessionId = instance.SessionId,
                        My_StartTime = instance.StartTime,
                        My_TotalProcessorTime = instance.TotalProcessorTime,
                        My_UserProcessorTime = instance.UserProcessorTime
                    }));
                }
                catch
                {
                }
            }
            dgProcess.ItemsSource = repository.MonitoredProcesses;
            dgProcess.SelectedIndex = selectedIndx;
            //dgProcess.Focus();
        }

        private void dgProcess_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProcess.Items.Count != 0) selectedIndx = dgProcess.SelectedIndex;
        }

        private void rbTextFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var find = dgProcess.ItemsSource.Cast<MonitoredProcess>().Where(
                    x => x.My_ProcessName.StartsWith(rbTextFind.Text.Trim())).Single();
                dgProcess.SelectedIndex = dgProcess.Items.IndexOf(find);
            }
        }
    };
}