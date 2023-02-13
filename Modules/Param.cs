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
    }
}
