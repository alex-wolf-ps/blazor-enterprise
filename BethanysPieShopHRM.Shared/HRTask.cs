using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.Shared
{
    public class HRTask
    {
        public int TaskId { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public int AssignedTo { get; set; }

        public Status Status { get; set; }

    }

    public enum Status
    {
        Open,
        Assigned,
        InProgress,
        Blocked,
        Complete
    }
}
