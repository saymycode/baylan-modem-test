using System.IO.Ports;

namespace BaylanModemTest.Models
{
    public class AppSettings
    {
        public string ComPort { get; set; }
        public int BaudRate { get; set; }
        public Parity Parity { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }
        public string MeterFlag { get; set; }
        public int MeterBaudRate { get; set; }
        public string TcpIp { get; set; }
        public int PushPort { get; set; }
        public int PullPort { get; set; }
        public string MeterSerial { get; set; }

        public AppSettings Clone()
        {
            return (AppSettings)MemberwiseClone();
        }

        public static AppSettings CreateDefault()
        {
            return new AppSettings
            {
                ComPort = "COM1",
                BaudRate = 57600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                MeterFlag = "0",
                MeterBaudRate = 9600,
                TcpIp = "192.168.1.1",
                PushPort = 4069,
                PullPort = 5200,
                MeterSerial = "00112233"
            };
        }
    }
}
