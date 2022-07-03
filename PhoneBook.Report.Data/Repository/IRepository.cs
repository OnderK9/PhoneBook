using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Data.Repository
{
    public interface IRepository
    {
        bool SaveChanges();
    }
}
