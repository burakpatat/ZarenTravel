using System;
using System.Collections.Generic;
using System.Text;

namespace WordyWell.Model.Concrete
{
    public class HttpLogs
    {

        public Guid Id { get; set; }
        public long? UserId { get; set; }
        public string Request { get; set; }
        public string Method { get; set; }
        public int ResponseCode { get; set; }
        public string Response { get; set; }
        public string Url { get; set; }
        public Guid? UniqId { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public int? Duration { get; set; }
    }
}
