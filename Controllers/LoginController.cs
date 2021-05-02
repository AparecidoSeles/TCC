using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCC.Models;
using System.Collections.Generic;

namespace TCC.Controllers
{
    public class LoginController : Controller
    {
        [TempData]
        public string Mensagem { get; set; }

        Usuario usuarioModel = new Usuario();

        public IActionResult Login()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            List<string> csv = usuarioModel.ReadAllLinesCSV(PATH);

            var logado = csv.Find(
                x => 
                (x.Split(";")[3] == form["Email"] && x.Split(";")[2] == form["Senha"])
            );

            if(logado != null)
            {
                //Criamos uma sessão com os dados do usuário
                HttpContext.Session.SetString("_UserId", logado.Split(";")[0]);
                HttpContext.Session.SetString("_Username", logado.Split(";")[4]);
                return LocalRedirect("~/Publicacao");
            }

            Mensagem = "Dados incorretos! Tente novamente.";


            return LocalRedirect("~/");
        }
        
        [Route("Deslogar")]
        public IActionResult Deslogar()
        {
            HttpContext.Session.Remove("_UserId");            
            return LocalRedirect("~/");
        }
    }
}