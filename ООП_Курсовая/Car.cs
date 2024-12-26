using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_Курсовая
{
    public class Car : Vehicle
    {
        public string EngineType { get; set; }

        public override decimal CalculatePayment() // Абстрактный метод для расчета оплаты
        {
            return PollutionDegree * 10 + Price;
        }
    }

}
