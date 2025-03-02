using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ColorGradientView.Parameters
{
    public class Config
    {
        public string[] Colors { get; set; } = new string[0];

        public static Config Load()
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            string path = Path.Combine(dir, "config.txt");

            Config c = new Config();
            if (File.Exists(path)) { 
                c.Colors = File.ReadAllLines(path);
            }
            return c;
        }

        public static void Save(List<string> colors)
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            string path = Path.Combine(dir, "config.txt");

            File.WriteAllLines(path, colors);
        }
    }
}
