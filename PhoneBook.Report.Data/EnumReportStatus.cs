using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Data
{
    /// <summary>
    /// Oluşturulan raporların durum bilgileri
    /// </summary>
    public enum EnumReportStatus
    {
        Waiting = 1,
        InProgress = 2,
        Done = 3,
        NoData = 4,
    }
}
