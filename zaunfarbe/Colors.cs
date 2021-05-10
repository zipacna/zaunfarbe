using System.Collections.Generic;

namespace zaunfarbe
{
    internal static class Colors
    {
        internal const string Prefix = "0xff";
        internal static readonly string[] Weekdays =
        {
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
        };

        internal static readonly Dictionary<string, string> FullColor = new Dictionary<string, string>
        {
            /* nice blue 00297b */
            {"Monday", Prefix + "000000"}, // Black
            {"Tuesday", Prefix + "ff0000"}, // Red
            {"Wednesday", Prefix + "ffd700"}, // Gold
            {"Thursday", Prefix + "00ff00"}, // Green
            {"Friday", Prefix + "0000ff"}, // Blue
            {"Saturday", Prefix + "5b5a5b"}, // Purple
            {"Sunday", Prefix + "ffffff"} // White
        };
        
        internal static readonly Dictionary<string, string> Risingcode = new Dictionary<string, string>
        {
            /* nice blue ff00297b */
            {"Monday", Prefix + "538874"}, // viridian (olive green)
            {"Tuesday", Prefix + "c09122"}, // Dark Goldenrod (Gold)
            {"Wednesday", Prefix + "838b78"}, // Artichoke (gray-ish green)
            {"Thursday", Prefix + "ebf3fa"}, // Alice Blue (light-blue)
            {"Friday", Prefix + "d0cfcd"}, // Light Gray (light gray)
            {"Saturday", Prefix + "d0cfcd"}, // Light Gray (light gray)
            {"Sunday", Prefix + "e4e3e1"} // Platinum (lighter gray)
        };
        
        internal static readonly Dictionary<string, string> Custom = new Dictionary<string, string>();
    }
}