﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroTools.Models
{
    public class Resposta
    {
        public int ID { get; set; }
        public int ID_Pergunta { get; set; }
        public string Email { get; set; }
        public int ID_Quest { get; set; }
        public string resposta { get; set; }
    }
}
