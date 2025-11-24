using System.Drawing;
using System.Windows.Forms;

namespace BaylanModemTest.Models
{
    internal class TestStep
    {
        public int Number { get; }
        public string Name { get; }
        private readonly Panel _led;
        private readonly Label _status;

        public TestStep(int number, string name, Panel led, Label statusLabel)
        {
            Number = number;
            Name = name;
            _led = led;
            _status = statusLabel;
        }

        public void SetWaiting()
        {
            _led.BackColor = Color.Silver;
            _status.Text = "Bekliyor";
            _status.ForeColor = Color.Silver;
        }

        public void SetRunning()
        {
            _led.BackColor = Color.Orange;
            _status.Text = "Çalışıyor";
            _status.ForeColor = Color.Orange;
        }

        public void SetPass()
        {
            _led.BackColor = Color.LimeGreen;
            _status.Text = "Geçti";
            _status.ForeColor = Color.LimeGreen;
        }

        public void SetFail(string reason)
        {
            _led.BackColor = Color.Red;
            _status.Text = reason;
            _status.ForeColor = Color.Red;
        }
    }
}
