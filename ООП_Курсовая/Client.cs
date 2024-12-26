using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_Курсовая
{
    public class Client : Person
    {
        public bool IsRegular { get; set; }
        public string IsRegularText => IsRegular ? "Да" : "Нет";
    }
}
