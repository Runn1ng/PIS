using System;
using System.Linq;
using System.Windows.Forms;
using PIS.UI.Index;

namespace PIS
{
    internal static class Program
    {
        public static DbContext Db { get; private set; }

        [STAThread]
        private static void Main()
        {
            SetupDbConnection();
            RenderApplication();
        }

        private static void SetupDbConnection()
        {
            Db = new DbContext();
            // initial render костыль
            _ = Db.Users.FirstOrDefault();
        }

        private static void RenderApplication()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IndexForm());
        }
    }
}