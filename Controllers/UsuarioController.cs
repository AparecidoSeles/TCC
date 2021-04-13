using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCC.Models;
using System.IO; 
using System; 

namespace TCC.Controllers
{
    [Route("Usuario")]
    public class UsuarioController : Controller
    {
        Usuario usuarioModel = new Usuario();

        [Route("Listar")]
        public IActionResult cadastro()
        {
            ViewBag.Usuarios = usuarioModel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Usuario novousuario         = new Usuario();
            novousuario.Nome            = form["Nome"];
            novousuario.Email           = form["Email"];
            novousuario.Senha           = form["Senha"];
            novousuario.DataNascimento  = DateTime.Parse(form["DataNascimento"]);

            usuarioModel.Create(novousuario);
            ViewBag.Usuarios = usuarioModel.ReadAll();
            return LocalRedirect("~/Usuario/Listar");
        }
    }
}