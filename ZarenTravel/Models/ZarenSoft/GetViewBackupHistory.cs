using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class GetViewBackupHistory
    {
        public string destination_database_name { get; set; }

        public DateTime? restore_date { get; set; }

        public DateTime? backup_start_date { get; set; }

        public DateTime? backup_finish_date { get; set; }

        public string source_database_name { get; set; }

        public string backup_file_used_for_restore { get; set; }

    }
}