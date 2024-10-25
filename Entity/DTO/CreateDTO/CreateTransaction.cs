using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO.CreateDTO
{
    public class CreateTransaction
    {
        public DateTime Date { get; set; } = DateTime.Now; // по умолчанию текущая дата
       

        [Required(ErrorMessage = "вы не установили причину дохода/расхода ")]
        public string Class { get; set; } // Категория

        [Required(ErrorMessage = "вы нес установили сумму ")]
        [Range(1, int.MaxValue)]
        public decimal Summa { get; set; } // Сумма

        public string message { get; set; } = null;


    }
}
