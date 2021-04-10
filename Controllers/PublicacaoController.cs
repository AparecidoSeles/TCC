using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCC.Models;
using System.IO; 
using System; 

namespace TCC.Controllers
{
    [Route("Publicacao")]
    public class PublicacaoController : Controller
    {
        Publicacao publicacaomodel = new Publicacao();

        [Route("Listar")]
        public IActionResult Logado()
        {
            ViewBag.Publicacoes = publicacaomodel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Publicacao novapublicacao  = new Publicacao();
            novapublicacao.Legenda     = form["Legenda"];
            novapublicacao.Data        = DateTime.Parse(form["Data"]);
            
            if (form.Files.Count > 0)
            {
                // Arquivo é recebido e armazenado na variável file
                var file   = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Publicacao");

                // Verificamos se o diretório já existe, se não, a criamos
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                using( var stream = new FileStream(path,FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                novapublicacao.Imagem = file.FileName;
            }else{
                novapublicacao.Imagem = "padrao.png";
            }

            publicacaomodel.Create(novapublicacao);
            ViewBag.Publicacoes = publicacaomodel.ReadAll();
            return LocalRedirect("~/Publicacao/Listar");
        }

        [Route("Excluir")]
        public IActionResult Excluir(int id)
        {
            publicacaomodel.Delet(id);
            ViewBag.Publicacoes = publicacaomodel.ReadAll();
            return LocalRedirect("~/Publicacao/Listar");
        }
    }
}