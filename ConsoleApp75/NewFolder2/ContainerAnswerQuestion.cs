using ConsoleApp75.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75.NewFolder2
{
   public class ContainerAnswerQuestion
    {
        public float AnswerAndQuestion()
        {           
            Models.Container container = new Models.Container();

            if (container.IsClosed)
            {
                return container.Coef *= 2;

            }
                return container.Coef;

           
        }
    }
}
