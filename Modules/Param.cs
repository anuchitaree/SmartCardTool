using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardTool.Models;

namespace SmartCardTool.Modules
{
    public static class Param
    {
        public static string Setting = "Setting";

        public static Pattern Patterns = new Pattern() { TotalLength = 28, Start = 10, Length = 9 };



        public static string Permition = "on";

        public static string ConnectionString = "";

        public static int Pages = 0;

        public static string CompleteSound = Environment.CurrentDirectory +"\\Setting\\tata.wav";

        public static string InCompleteSound = Environment.CurrentDirectory +  "\\Setting\\Alarm05.wav";
        public static string manual = Environment.CurrentDirectory + "\\Setting\\Smart card manual.pdf";

        public static string DataPath = Environment.CurrentDirectory + "\\Setting\\Smart card manual.pdf";

        public static string StockPath = "";

        public static string UploadUrl = "";
    }
}
