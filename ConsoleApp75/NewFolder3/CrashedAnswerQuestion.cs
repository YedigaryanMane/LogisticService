using ConsoleApp75.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75.NewFolder3
{
    public class CrashedAnswerQuestion
    {
        public float AnswerAndQuestion()
        {           
            Crashed crashed = new Crashed();

            if (crashed.IsCrashed )
            {
                return crashed.Coef *= 2;
            }                                
               return  crashed.Coef ;           
        }
    }   
}
