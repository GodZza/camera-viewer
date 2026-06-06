using System;
using System.Windows.Forms;

namespace CameraInfo
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Console.WriteLine("[Program] Starting...");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            try
            {
                Console.WriteLine("[Program] Creating MainForm...");
                MainForm form = new MainForm();
                Console.WriteLine("[Program] MainForm created. Running...");
                Application.Run(form);
                Console.WriteLine("[Program] Exited normally.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Program] FATAL: {0}", ex);
                MessageBox.Show("FATAL ERROR:\n\n" + ex.ToString(), "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Console.WriteLine("[ThreadException] {0}", e.Exception);
            MessageBox.Show(e.Exception.ToString(), "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("[UnhandledException] {0}", e.ExceptionObject);
            MessageBox.Show(e.ExceptionObject.ToString(), "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
