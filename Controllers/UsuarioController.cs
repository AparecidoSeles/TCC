using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCC.Models;
using System; 

namespace TCC.Controllers
{
    [Route("Usuario")]
    public class UsuarioController : Controller
    {
        Usuario usuarioModel = new Usuario();

        
        public IActionResult cadastro()
        {
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
            
            return LocalRedirect("~/Login");
        }
    }
}