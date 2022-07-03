using PhoneBook.Core.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Helper
{
    public class FileHelper
    {
        public static void SaveCSV<T>(IEnumerable<T> data,string columns,string path)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(columns);
            foreach (T view in data)
            {
                sb.AppendLine(view.ToString());
            }

            File.WriteAllText(path, sb.ToString());
        }

    }
}
