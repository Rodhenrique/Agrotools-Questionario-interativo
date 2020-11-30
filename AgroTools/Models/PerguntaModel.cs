using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroTools.Models
{
    public class PerguntaModel
    {
        public int ID { get; set; }
        public string Pergunta { get; set; }
        public DateTime DataCricao { get; set; }
        public string TipoResposta { get; set; }
        public int Ordem { get; set; }
        public int ID_Questionario { get; set; }

    }
}
