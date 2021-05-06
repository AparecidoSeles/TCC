using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using TCC.Models;

namespace TCC.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        [TempData]
        public string Mensagen { get; set; }
        
        
        Usuario usuarioModel = new Usuario();

        public IActionResult login()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            List<string> csv = usuarioModel.ReadAllLinesCSV(usuarioModel.PATH);

            var logado = csv.Find(
                x => 
                x.Split(";")[2] == form["Senha"] && 
                x.Split(";")[3] == form["Email"]
            );

            //redirecionar o usuario logado caso encontrado
            if(logado != null)
            {
                //Criamos uma sessão com os dados do usuário
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);
            
                return LocalRedirect("~/Publicacao/Listar");
            }
             
            Mensagen = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login");
            
        }
        
        [Route("Deslogar")]
        public IActionResult Deslogar()
        {
            HttpContext.Session.Remove("_UserId");            
            return LocalRedirect("~/");
        }
    }
}