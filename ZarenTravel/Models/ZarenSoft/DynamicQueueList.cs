using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class DynamicQueueList
    {
        public string Service_Name { get; set; }

        public string Schema_Name { get; set; }

        public string Queue_Name { get; set; }

        public string Queue_State { get; set; }

        public string tasks_waiting { get; set; }

        public string last_activated_time { get; set; }

        public string last_empty_rowset_time { get; set; }

        public int? Tran_Message_Count { get; set; }

    }
}