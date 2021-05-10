using System;
using System.Collections.Generic;
using System.Configuration;

namespace zaunfarbe
{
    internal static class Config
    {
        internal static IReadOnlyDictionary<string, string> ReadConfig()
        {
            try
            {
                var palette = ConfigurationManager.AppSettings["colorPalette"];
                Console.WriteLine("ColorPalette: " + palette);

                foreach (var weekday in Colors.Weekdays)
                {
                    var configDay = ConfigurationManager.AppSettings[weekday];
                    Colors.Custom.Add(weekday, Colors.Prefix + configDay);
                    Console.WriteLine($"{weekday}: {configDay}");
                }

                switch (palette)
                {
                    case "FullColor":
                        return Colors.FullColor;
                    case "Custom":
                        return Colors.Custom;
                    case "Risingcode":
                        return Colors.Risingcode;
                    default:
                        const string err = "No supported ColorPalette found (falling back to Risingcode). ";
                        const string info = "Supported color palettes are:";
                        const string full = "\nFullColor: Black--Red--Gold--Green--Blue--Blue--White";
                        const string rcnet = "\nRisingcode: Olive/Green--Gold--Gray/Green--Light/Blue";
                        const string rcnet2 = "--Light/Gray--Light/Gray--Lighter/Gray";
                        const string custom = "\nCustom: Hex color values for Monday through Sunday";
                        Console.WriteLine(err + info + full + rcnet + rcnet2 + custom);
                        return Colors.Risingcode;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while reading config, falling back to Risingcode ColorPalette.");
                Console.WriteLine(e);
                return Colors.Risingcode;
            }
        }
    }
}