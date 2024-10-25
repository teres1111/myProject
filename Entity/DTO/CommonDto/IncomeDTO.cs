﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO.Get
{
    public class IncomeDTO
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Source { get; set; }
        public DateTime Data { get; set; }
        public string coomment { get; set; } = null;
    }
}
