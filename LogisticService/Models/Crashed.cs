﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Models
{
    public class Crashed
    {       
        public int Id { get; set; }
        public bool IsCrashed { get; set; }
        public float Coef { get; set; }
    }
}
