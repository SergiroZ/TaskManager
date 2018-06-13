﻿using System;
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
            theBlock1.Text = repository.MonitoredProcesses.Select(x => x.My_PagedMemorySize64).Single().ToString();
            theBlock2.Text = repository.MonitoredProcesses.Select(x => x.My_BaisePriority).Single().ToString();
            theBlock3.Text = repository.MonitoredProcesses.Select(x => x.My_SessionId).Single().ToString();
            theBlock4.Text = repository.MonitoredProcesses.Select(x => x.My_PagedSystemMemorySize64).Single().ToString();
            theBlock5.Text = repository.MonitoredProcesses.Select(x => x.My_NonpagedSystemMemorySize64).Single().ToString();
            theBlock6.Text = repository.MonitoredProcesses.Select(x => x.My_PeakPagedMemorySize64).Single().ToString();
            theBlock7.Text = repository.MonitoredProcesses.Select(x => x.My_PeakVirtualMemorySize64).Single().ToString();
            theBlock8.Text = repository.MonitoredProcesses.Select(x => x.My_PeakWorkingSet64).Single().ToString();
            theBlock9.Text = repository.MonitoredProcesses.Select(x => x.My_PrivateMemorySize64).Single().ToString();
            theBlock10.Text = repository.MonitoredProcesses.Select(x => x.My_StartTime).Single().ToString();
            theBlock11.Text = repository.MonitoredProcesses.Select(x => x.My_TotalProcessorTime).Single().ToString();
            theBlock12.Text = repository.MonitoredProcesses.Select(x => x.My_UserProcessorTime).Single().ToString();
        }

        private void RibbonApplicationMenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process[] processes;
            processes = System.Diagnostics.Process.GetProcesses();
            foreach (Process instance in processes)
            {
                try
                {
                    ((MonitoredProcessesRepository)Resources["repository"]).MonitoredProcesses.Add(
                        item: new MonitoredProcess()
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
                        });
                }
                catch (Exception)
                {
                    //throw;
                }
            }
        }
    };
}