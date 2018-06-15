using System;
using TaskManager.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace TaskManager.Repository
{
    public class MonitoredProcessesRepository
    {
        private ObservableCollection<MonitoredProcess> monitoredProcesses;

        public ObservableCollection<MonitoredProcess> MonitoredProcesses
        {
            get {
                if (monitoredProcesses == null)
                {
                    Process proc = Process.GetProcessesByName("System")[0];
                    monitoredProcesses = new ObservableCollection<MonitoredProcess>()
                    {
                         new MonitoredProcess()
                         {
                             My_BaisePriority = proc.BasePriority,
                             My_Id = proc.Id,
                             My_NonpagedSystemMemorySize64 = proc.NonpagedSystemMemorySize64,
                             My_PagedSystemMemorySize64 = proc.PagedSystemMemorySize64,
                             My_PagedMemorySize64 = proc.PagedMemorySize64,
                             My_PeakPagedMemorySize64 = proc.PeakPagedMemorySize64,
                             My_PeakVirtualMemorySize64 = proc.PeakVirtualMemorySize64,
                             My_PeakWorkingSet64 = proc.PeakWorkingSet64,
                             My_PrivateMemorySize64 = proc.PrivateMemorySize64,
                             My_ProcessName = proc.ProcessName,
                             My_SessionId = proc.SessionId,
                             My_StartTime = proc.StartTime,
                             My_TotalProcessorTime = proc.TotalProcessorTime,
                             My_UserProcessorTime = proc.UserProcessorTime
                         }
                    };
                }
                return monitoredProcesses;
            }
        }

        public void Add(MonitoredProcess sender)
        {
            monitoredProcesses.Add(sender);
        }
    }
}