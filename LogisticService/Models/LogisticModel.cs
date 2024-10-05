using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Models
{
    public class LogisticModel
    {
        public LogisticModel(string carType, bool isCrashed, bool isClosed, string from, string to)
        {
            CarType = carType;
            IsCrashed = isCrashed;
            IsClosed = isClosed;
            From = from;
            To = to;
        }

        public string CarType { get; set; }
        public bool IsCrashed { get; set; }
        public bool IsClosed { get; set; }
        public string From { get; set; }
        public string To { get; set; }

    }
}
