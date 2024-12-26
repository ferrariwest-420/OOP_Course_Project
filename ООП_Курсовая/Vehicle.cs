using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_Курсовая
{
    public abstract class Vehicle
    {
        public string Model { get; set; }
        public int PollutionDegree { get; set; }
        public int Price { get; set; }
        public abstract decimal CalculatePayment(); // Абстрактный метод для расчета оплаты
    }
}