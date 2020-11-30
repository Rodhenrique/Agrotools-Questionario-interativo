using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroTools.Models
{
    public class Questionario
    { 
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Url { get; set; }
        public string Descricao { get; set; }
        public int ID_Usuario { get; set; }
    }
}
