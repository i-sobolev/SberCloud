using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SberCloudWpf.AppData
{
    public class DefaultMessage
    {
        public static void WarningMessage(string message)
        {
            MessageBox.Show($"{message}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        public static void InformationMessage(string message)
        {
            MessageBox.Show($"{message}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
