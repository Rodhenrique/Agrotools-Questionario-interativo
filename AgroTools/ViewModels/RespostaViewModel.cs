using AgroTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroTools.ViewModels
{
    public class RespostaViewModel:BaseViewModel
    {
        public string Mensagem { get; set; }
        public Usuario usuario { get; set; }

        public RespostaViewModel()
        {
        }
        public RespostaViewModel(string mensagem)
        {
            Console.WriteLine(mensagem);
            this.Mensagem = mensagem;
        }
    }
}
