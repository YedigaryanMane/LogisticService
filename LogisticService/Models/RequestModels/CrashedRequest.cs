using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Models.RequestModels
{
    public class CrashedRequest
    {       
        public bool IsCrashed { get; set; }

        public CrashedRequest(bool isCrashed)
        {
            IsCrashed = isCrashed;
        }
    }
}
