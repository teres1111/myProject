using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO.CreateDTO
{
    public class CreateIncomeDTO
    {
        [Required(ErrorMessage = "внесите сумму")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "обязательно укажите источник дохода")]
        public string Source { get; set; } = null;
        public DateTime Date { get; set; } // Дата дохода
        public string coomment { get; set; } = null;
    }
}
