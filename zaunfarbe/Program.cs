/*
This Program changes the Registry Key for the global Fence color of Stardock Fences based on the day of the week.
Currently the default colors are from Monday to Sunday in the following order: Black-Red-Gold-Green-Blue-Blue-White
Author: Jean Mattes
Author-URI: risingcode.net
License: MIT 2020

Possible Future Features:
- Config (allow for changeable colors) [DONE]
- Logging [TBD]
- Releases?
*/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using Microsoft.Win32;

namespace zaunfarbe
{
    internal static class Program
    {
        public static void Main() // string[] args
        {
            Console.WriteLine("Starting ZaunFarbe");
            UpdateFenceColor(Config.ReadConfig());
            KillExplorer();
            Console.WriteLine("Stopping ZaunFarbe");
            var debug = ConfigurationManager.AppSettings["debug"];
            if (debug == null || debug != "on") return;
            Console.WriteLine("Press any key to close the window.");
            Console.ReadKey();
        }

        /// <summary>
        /// Updates the Color of all Fences with the Value of the Weekday.
        /// <param name="weekDayColors">Dictionary returned from Config.ReadConfig()</param>
        /// </summary>
        private static void UpdateFenceColor(IReadOnlyDictionary<string, string> weekDayColors)
        {
            var weekday = DateTime.Now.DayOfWeek;
            weekDayColors.TryGetValue(weekday.ToString(), out var weekdayValue);
            var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Stardock\Fences\Settings", true);
            if (key != null)
            {
                key.SetValue("Color", Convert.ToInt32(weekdayValue, 16), RegistryValueKind.DWord);
                key.Close();
            }
            else
            {
                Console.WriteLine("Writing to key failed.");
                Console.ReadKey();
            }
        }

        /// <summary>Killing the explorer will restart it (and apply the changed color).</summary>
        private static void KillExplorer()
        {
            foreach (var exe in Process.GetProcesses())
            {
                if (exe.ProcessName == "explorer")
                {
                    exe.Kill();
                }
            }
        }
    }
}