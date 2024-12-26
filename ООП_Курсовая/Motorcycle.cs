using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_Курсовая
{
    public class Motorcycle : Vehicle
    {
        public string MotorcycleType { get; set; } // Цена мойки

        public override decimal CalculatePayment() // Абстрактный метод для расчета оплаты
        {
            return PollutionDegree * 5 + Price;
        }
    }
}
