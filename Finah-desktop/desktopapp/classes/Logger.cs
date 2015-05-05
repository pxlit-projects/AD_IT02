﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    class Logger
    {
        public string ApplicationName = "Finah";

        //Schrijft een log met de standaard log-type 'error'
        public void log(String msg)
        {
            StreamWriter writer = null;
            try
            {
                Console.WriteLine(msg);
                String DrivePath = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
                String MainPath = DrivePath + "log_" + ApplicationName + ".txt";
                string userName = MainWindow.gebruiker.gebruikersnaam;
                using (writer = new StreamWriter(MainPath, true))
                {
                    string prefix = DateTime.UtcNow.ToString("dd/MM/yyyy hh:mm:ss") + " - " + userName + " - " + "error" + " - ";
                    msg = prefix + msg;
                    writer.WriteLine(msg);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: The logging service is unable to log this event.\n" + ex.Message);
            }
        }

        //Writes a log with a custom log-type
        public void log(String msg, String type)
        {
            StreamWriter writer = null;
            try
            {
                Console.WriteLine(msg);
                String DrivePath = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
                String MainPath = DrivePath + "log_" + ApplicationName + ".txt";
                string userName = MainWindow.gebruiker.gebruikersnaam;
                using (writer = new StreamWriter(MainPath, true))
                {
                    string prefix = DateTime.UtcNow.ToString("dd/MM/yyyy hh:mm:ss") + " - " + userName + " - " + type + " - ";
                    msg = prefix + msg;
                    writer.WriteLine(msg);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: The logging service is unable to log this event.\n" + ex.Message);
            }
        }
    }
}
