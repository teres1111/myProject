using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO.CommonDto
{
    public class TransactionDTO
    {
       public int Tranzaktion_Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now; // по умолчанию текущая дата
        public string Transaktion_Type { get; set; } // "Income" или "Expense"
        public string Class { get; set; } // Категория
        [Required(ErrorMessage = "вы нес установили сумму ")]
        [Range(1, int.MaxValue)]
        public decimal Summa { get; set; } // Сумма
        public string message { get; set; } = null;
    }
}
