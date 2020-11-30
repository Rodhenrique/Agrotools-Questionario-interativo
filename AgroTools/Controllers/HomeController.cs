using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AgroTools.Models;
using AgroTools.Repositories;
using AgroTools.ViewModels;

namespace AgroTools.Controllers
{
    public class HomeController : BaseController
    {

        public IActionResult Index()
        {
            UsuarioRepository repository = new UsuarioRepository();
            return View(new RespostaViewModel { NomeView = "Home", UsuarioEmail = ObterUsuarioSession(), UsuarioNome = ObterUsuarioNomeSession() });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
