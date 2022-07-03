using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Report.Data
{
    public class dbReport
    {
        [Key]
        public Guid UUID { get; set; }
        public DateTime RequestDate { get; set; }
        public EnumReportStatus Status { get; set; }
        public string FileUrl { get; set; }

    }
}
