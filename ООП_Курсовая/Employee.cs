using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_Курсовая
{
    public class Employee : Person
    {
        public int Id { get; set; } // Уникальный идентификатор сотрудника
        public string Position { get; set; }
        public decimal Salary { get; set; }
    }

}
