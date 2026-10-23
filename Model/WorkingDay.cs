using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WorkingDay : BaseEntity
    {
        public int ProviderID { get; set; }
        public int DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public WorkingDay(int providerID, int dayOfWeek, string startTime, string endTime)
        {
            ProviderID = providerID;
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
        }

        public WorkingDay(int id, int providerID, int dayOfWeek, string startTime, string endTime)
        {
            Id = id;
            ProviderID = providerID;
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
        }

        public int ID
        {
            get => Id;
            set => Id = value;
        }
        public WorkingDay()
        {
        }
    }
}
