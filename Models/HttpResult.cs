using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardTool.Models
{
    public class HttpResult
    {
        public SendHttpResult Result { get; set; }
        public string  Message { get; set; }
    }

    public enum SendHttpResult
    {
        Success,
        WrongData,
        Disconnect,
        Other,
        NoProduction,
    }
}
