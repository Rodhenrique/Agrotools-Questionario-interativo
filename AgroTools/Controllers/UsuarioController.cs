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
    public class UsuarioController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new RespostaViewModel { NomeView = "Login", UsuarioEmail = ObterUsuarioSession(), UsuarioNome = ObterUsuarioNomeSession(), Mensagem = "" });
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View(new RespostaViewModel { NomeView = "Cadastro", UsuarioEmail = ObterUsuarioSession(), UsuarioNome = ObterUsuarioNomeSession() });
        }

        [HttpGet("QuestionarioSelecionado/{ID}")]
        public IActionResult ListarQuestionario(int ID)
        {
            QuestionarioRepository repository = new QuestionarioRepository();
            List<PerguntaModel> lista = repository.ListarPerguntas(ID);
            List<Respondido> respondidos = repository.ListarRespondidos(ID);
            List<Resposta> respostas = repository.ListarRespostas(ID);
            return View(new PerguntaViewModel {Respostas = respostas,Questionarios = respondidos ,Perguntas = lista, NomeView = "Cadastro", UsuarioEmail = ObterUsuarioSession(), UsuarioNome = ObterUsuarioNomeSession() });
        }

        [HttpGet]
        public IActionResult Panel()
        {
            var ninguemLogado = string.IsNullOrEmpty(ObterUsuarioSession());

            if (!ninguemLogado)
            {
                QuestionarioRepository repository = new QuestionarioRepository();
                int ID = Convert.ToInt32(ObterUsuarioIDSession());
                List<Questionario> questionarios = repository.ListarQuestionarios(ID);
                return View(new QuestionarioViewModel {questionarios=questionarios ,NomeView = "Panel", UsuarioEmail = ObterUsuarioSession(), UsuarioNome = ObterUsuarioNomeSession() });
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(IFormCollection form)
        {
            Usuario usuario = new Usuario();

            usuario.Nome = form["nome"];
            usuario.Email = form["email"];
            usuario.Senha = form["senha"];

            UsuarioRepository repository = new UsuarioRepository();
            if(usuario.Email != "" && usuario.Nome != "" && usuario.Senha != "")
            {
                repository.Cadastro(usuario);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Cadastro", "Usuario");
            }

        }

        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            Usuario usuario = new Usuario();

            usuario.Email = form["email"];
            usuario.Senha = form["senha"];

            UsuarioRepository repository = new UsuarioRepository();

           Usuario recebido = repository.Login(usuario.Email);
            if (recebido != null && recebido.Email != "" && recebido.Nome != "" && recebido.Senha == usuario.Senha)
            {
                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, recebido.Email);
                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, recebido.Nome);
                HttpContext.Session.SetString(SESSION_CLIENTE_ID, recebido.ID.ToString());

                return RedirectToAction("Panel", "Usuario");
            }
            else
            {
                return View("Index", new RespostaViewModel($"Senha ou email inválido"));
            }
        }

        [HttpGet]
        public IActionResult Logoff()
        {
            HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove(SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}