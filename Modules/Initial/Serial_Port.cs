using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardTool.Modules
{
    public static class Serial_Port
    {
        public static void Init()
        {
            string root = Environment.CurrentDirectory;
            string PortSetting = $"{root}\\{Param.Setting}\\port.txt";

            string pattern = string.Format("{0}\\pattern.txt", root);

            if (!Directory.Exists($"{root}\\{Param.Setting}"))
            {
                Directory.CreateDirectory($"{root}\\{Param.Setting}");
            }

            if (!File.Exists(PortSetting))
            {
                string str = "COM1,19200,None,8,One";
                File.WriteAllText(PortSetting, str);
            }


            if (!File.Exists(pattern))
            {
                string data = string.Format("28,10,15,DSC1002133TG123456-45670T123");
                File.WriteAllText(pattern, data);
            }


        }


        public static void ReadSetting(int port, SerialPort serialPort)
        {
            string root = Environment.CurrentDirectory;
            string PortSetting = $"{root}\\{Param.Setting}\\port.txt";



            if (File.Exists(PortSetting))
            {
                string com = File.ReadAllText(PortSetting);
                string[] parts = com.Split(',');
                if (parts.Length == 6)
                {
                    string comport = parts[0];

                    string stopbit = parts[4];
                    string parity = parts[2];
                    serialPort.PortName = comport;
                    serialPort.BaudRate = Convert.ToInt32(parts[1]);
                    serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), parity);
                    serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopbit);
                    serialPort.DataBits = Convert.ToInt16(parts[3]);

                }


            }

        }

        public static void Close(SerialPort serialPort)
        {
            if (serialPort != null)
            {
                if (serialPort.IsOpen)
                {
                    serialPort.DiscardOutBuffer();
                    serialPort.DiscardInBuffer();
                    serialPort.Close();
                    //serialPort = null;
                }
            }
        }
    }
}
