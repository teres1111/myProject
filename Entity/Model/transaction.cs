using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    [Table("transaction",Schema = "Accounting")]
    public class transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string type { get; set; } // "Income" или "Expense"
        public string Category { get; set; } // Категория
        public decimal Amount { get; set; } // Сумма
        public string Comment { get; set; } = null;
    }
}
