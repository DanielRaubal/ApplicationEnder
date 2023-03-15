using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicationEnder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListProcesses();
        }

        List<Process> listOfProcesses = new List<Process>();
        private void ListProcesses()
        {
            Process[] processCollection = Process.GetProcesses();

            foreach (Process process in processCollection)
            {
                if(process.MainWindowHandle != IntPtr.Zero)
                {
                    RichTextBox1.AppendText(process.ProcessName + Environment.NewLine);
                    listOfProcesses.Add(process);
                }
            }
        }

        private void ProcessKiller(object sender, RoutedEventArgs e)
        {
            foreach (Process process in listOfProcesses)
            {
                if (process.MainWindowHandle != IntPtr.Zero)
                {
                    process.Kill();
                }
            }
        }


    }
}
