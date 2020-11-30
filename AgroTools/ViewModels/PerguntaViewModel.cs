using AgroTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroTools.ViewModels
{
    public class PerguntaViewModel : BaseViewModel
    {
        public List<PerguntaModel> Perguntas{get;set;}
        public List<Respondido> Questionarios { get; set; }
        public List<Resposta> Respostas { get; set; }
    }
}
