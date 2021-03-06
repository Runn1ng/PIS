﻿using System;
using System.Linq;
using System.Windows.Forms;
using PIS.Models;
using PIS.UI.Index;
using PIS.UI;

namespace PIS
{
    internal static class Program
    {
        public static DbContext Db { get; private set; }
        public static User CurrentUser { get;  set; }

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
            //Application.Run(new UI.Plan.PlanForm());
            //Application.Run(new UI.Main.MainForm());
        }
    }
}