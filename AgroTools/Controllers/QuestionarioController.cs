using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgroTools.Models;
using AgroTools.Repositories;
using AgroTools.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroTools.Controllers
{
    public class QuestionarioController : BaseController
    {
        public IActionResult Index()
        {
            var ninguemLogado = string.IsNullOrEmpty(ObterUsuarioSession());

            if (!ninguemLogado)
            {
                return View(new QuestionarioViewModel { NomeView = "Questionario", UsuarioEmail = ObterUsuarioSession(), UsuarioNome = ObterUsuarioNomeSession() });
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
        }
        [HttpPost]
        public IActionResult NovoQuestionario(IFormCollection form)
        {
            QuestionarioRepository repository = new QuestionarioRepository();
            Questionario quest = new Questionario();
            var names = form["todos"];
            quest.Titulo = form["titulo"];
            quest.Descricao = form["descricao"];
            quest.ID_Usuario = Convert.ToInt32(ObterUsuarioIDSession());
            int ID = repository.Registrar(quest);
           
            string[] nomes = names.ToString().Split(';');


            int cont = 1;
            foreach(var item in nomes)
            {
                PerguntaModel perguntaModel = new PerguntaModel();
                if (item != "")
                {       
                var pergunta = form[item];
                string[] pergunt = pergunta.ToString().Split('¥');
                string str = pergunt[1].Substring(13);
                int tipo = Convert.ToInt32(str);
                if (tipo == 1)
                {
                    perguntaModel.TipoResposta = tipo.ToString();
                }else if (tipo == 2)
                {
                        string got = pergunt[2].Substring(11);
                        int count = Convert.ToInt32(got) +3;
                        string stro = "";
                        for(int i = 3; i< count; i++)
                        {
                            stro += pergunt[i].Substring(7) +";";
                        }
                        perguntaModel.TipoResposta = $"TipoResposta=select;"+stro;
                }
                else
                {
                    string got = pergunt[2].Substring(11);
                    int count = Convert.ToInt32(got) + 3;
                    string stro = "";
                    for (int i = 3; i < count; i++)
                    {
                        stro += pergunt[i].Substring(7) + ";";
                    }
                    perguntaModel.TipoResposta = $"TipoResposta=checkbox;" + stro;
                }
                perguntaModel.ID_Questionario = ID;
                perguntaModel.Ordem = cont;
                perguntaModel.DataCricao = DateTime.Now;
                perguntaModel.Pergunta = pergunt[0].Substring(9);

                   repository.NovaPergunta(perguntaModel);
                cont++;
            }
            }
            return RedirectToAction("Panel", "Usuario");
        }

        [HttpGet("/MyQuestionario/{url}")]
        public IActionResult RespostaQuestionario(IFormCollection form,string url)
        {
            QuestionarioRepository repository = new QuestionarioRepository();
            Questionario questionario = new Questionario();
            List<PerguntaModel> ListaPerguntas = new List<PerguntaModel>();
            questionario = repository.buscar(url);
            if (questionario != null)
            {
            ListaPerguntas = repository.ListarPerguntas(questionario.ID);
            return View(new PerguntaViewModel {Perguntas = ListaPerguntas,NomeView = "RespostaQuest", UsuarioEmail = ObterUsuarioSession(), UsuarioNome = ObterUsuarioNomeSession() });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult NovaResposta(IFormCollection form)
        {
            QuestionarioRepository repository = new QuestionarioRepository();
            Respondido respondido = new Respondido();

            var email = form["email"];
            var el = form["elemento"];
            var todas = form["todas"];
            var IdQuest = form["principal"];

            respondido.Email = email;
            respondido.ID_Quest = Convert.ToInt32(IdQuest);

            string[] elementos = todas.ToString().Split(';');

            foreach (var item in elementos)
            {
                Resposta resposta = new Resposta();
                var busca = form[item];
                if (item != "")
                {
                    string[] words = busca.ToString().Split('¤');
                    string str = words[0].Substring(5);

                    if(str == "3")
                    {
                        string concat = "";
                        for (int i = 2; i < words.Length -1; i++)
                        {
                            concat += words[i] + ";";
                        }
                        resposta.resposta = concat;
                    }
                    else
                    {
                        resposta.resposta = words[2].ToString();
                    }
                    resposta.ID_Pergunta = Convert.ToInt32(words[1].ToString().Substring(8));
                    resposta.ID_Quest = Convert.ToInt32(IdQuest);
                    resposta.Email = email;
                    repository.NovaResposta(resposta);
                }
            }
            repository.Respondido(respondido);
            return RedirectToAction("Index", "Home");
        }

    }
}