using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberCloudWpf.AppData
{
    public class EmptyFieldValidation
    {
        public static bool IsFieldEmpty(params string[] text)
        {
            foreach (var field in text)
            {
                if (string.IsNullOrEmpty(field))
                    return true;
            }

            return false;
        }
    }
}
