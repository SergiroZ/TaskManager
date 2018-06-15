using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Entities
{
    public class MonitoredProcess : INotifyPropertyChanged
    {
        private string my_processName;

        public string My_ProcessName
        {
            get { return my_processName; }
            set { my_processName = value; OnPropertyChanged(); }
        }

        private int my_id;

        public int My_Id
        {
            get { return my_id; }
            set { my_id = value; OnPropertyChanged(); }
        }

        private long my_pagedMemorySize64;

        public long My_PagedMemorySize64
        {
            get { return my_pagedMemorySize64; }
            set { my_pagedMemorySize64 = value; OnPropertyChanged(); }
        }

        private long my_pagedSystemMemorySize64;

        public long My_PagedSystemMemorySize64
        {
            get { return my_pagedSystemMemorySize64; }
            set { my_pagedSystemMemorySize64 = value; OnPropertyChanged(); }
        }

        private int my_baisePriority;

        public int My_BaisePriority
        {
            get { return my_baisePriority; }
            set { my_baisePriority = value; OnPropertyChanged(); }
        }

        private int my_sessionId;

        public int My_SessionId
        {
            get { return my_sessionId; }
            set { my_sessionId = value; OnPropertyChanged(); }
        }

        private long my_nonpagedSystemMemorySize64;

        public long My_NonpagedSystemMemorySize64
        {
            get { return my_nonpagedSystemMemorySize64; }
            set { my_nonpagedSystemMemorySize64 = value; OnPropertyChanged(); }
        }

        private long my_peakPagedMemorySize64;

        public long My_PeakPagedMemorySize64
        {
            get { return my_peakPagedMemorySize64; }
            set { my_peakPagedMemorySize64 = value; OnPropertyChanged(); }
        }

        private long my_peakVirtualMemorySize64;

        public long My_PeakVirtualMemorySize64
        {
            get { return my_peakVirtualMemorySize64; }
            set { my_peakVirtualMemorySize64 = value; OnPropertyChanged(); }
        }

        private long my_peakWorkingSet64;

        public long My_PeakWorkingSet64
        {
            get { return my_peakWorkingSet64; }
            set { my_peakWorkingSet64 = value; OnPropertyChanged(); }
        }

        private long my_privateMemorySize64;

        public long My_PrivateMemorySize64
        {
            get { return my_privateMemorySize64; }
            set { my_privateMemorySize64 = value; OnPropertyChanged(); }
        }

        private DateTime my_startTime;

        public DateTime My_StartTime
        {
            get { return my_startTime; }
            set { my_startTime = value; OnPropertyChanged(); }
        }

        private TimeSpan my_totalProcessorTime;

        public TimeSpan My_TotalProcessorTime
        {
            get { return my_totalProcessorTime; }
            set { my_totalProcessorTime = value; OnPropertyChanged(); }
        }

        private TimeSpan my_userProcessorTime;

        public TimeSpan My_UserProcessorTime
        {
            get { return my_userProcessorTime; }
            set { my_userProcessorTime = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}