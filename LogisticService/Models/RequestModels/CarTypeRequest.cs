using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Models.RequestModels
{
    public class CarTypeRequest
    {
        public string Type { get; set; }

        public CarTypeRequest(string type)
        {
            Type = type;
        }
    }
}
