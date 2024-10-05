using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Models.RequestModels
{
    public class ContainerRequest
    {
        public bool IsClosed { get; set; }

        public ContainerRequest(bool isClosed)
        {
            IsClosed = isClosed;
        }
    }
}
