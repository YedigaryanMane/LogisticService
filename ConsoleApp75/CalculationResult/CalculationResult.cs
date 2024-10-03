using ConsoleApp75.Models;
using ConsoleApp75.NewFolder2;
using ConsoleApp75.NewFolder3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75.CalculationResult
{
   public class Calculate
    {
        CrashedAnswerQuestion crashedAnswerQuestion;
        ContainerAnswerQuestion containerAnswerQuestion;
        CarType carType;
        Direction direction;

        
        public decimal CalculateResult()
        {
            decimal result = System.Convert.ToDecimal(crashedAnswerQuestion.AnswerAndQuestion() + containerAnswerQuestion.AnswerAndQuestion() + carType.Coef);
            return result*direction.Price;
        }
    }
}
