using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgroTools.Controllers
{
    public class BaseController : Controller
    {
        protected const string SESSION_CLIENTE_EMAIL = "";
        protected const string SESSION_CLIENTE_NOME = "";
        protected const string SESSION_CLIENTE_ID = "";

        protected string ObterUsuarioSession()
        {
            var emailUsuario = HttpContext.Session.GetString(SESSION_CLIENTE_EMAIL);
            if (!string.IsNullOrEmpty(emailUsuario))
            {
                return emailUsuario;
            }
            else
            {
                return "";
            }
        }

        protected string ObterUsuarioIDSession()
        {
            var ID = HttpContext.Session.GetString(SESSION_CLIENTE_ID);
            if (!string.IsNullOrEmpty(ID))
            {
                return ID;
            }
            else
            {
                return "";
            }
        }
        protected string ObterUsuarioNomeSession()
        {
            var nomeUsuario = HttpContext.Session.GetString(SESSION_CLIENTE_NOME);
            if (!string.IsNullOrEmpty(nomeUsuario))
            {
                return nomeUsuario;
            }
            else
            {
                return "";
            }
        }
    }
}