using System;
using System.IO;
using System.Collections.Generic;

namespace TCC.Models
{
    public class Publicacao : TccBase
    {
        public System.Guid IdPublicacao { get; set; }
        
        public string Imagem { get; set; }

        public DateTime Data = new DateTime();
        
        public string Legenda { get; set; }
        
        public const string PATH = "Database/Publicacoes.csv";

        public Publicacao(){
            CreateFolderAndFile(PATH);
        }

        public string Prepare( Publicacao p)
        {
            return $"{p.IdPublicacao}; {p.Imagem}; {p.Legenda};{p.Data}";
        }

        public void CriarPublicacao(Publicacao p)
        {
            string [] linhas = {Prepare(p)};

            File.AppendAllLines(PATH, linhas);
        }
        
        public List<Publicacao> ListarPublicacao()
        {
            List<Publicacao> publicacoes = new List<Publicacao>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
                string[] linha = item.Split(";");

                Publicacao novaPublicacao   = new Publicacao();
                novaPublicacao.IdPublicacao = Guid.Parse(linha[0]);
                novaPublicacao.Imagem       = linha[1];
                novaPublicacao.Legenda      = linha[2];
                novaPublicacao.Data         = DateTime.Parse(linha[3]);
                
                publicacoes.Add(novaPublicacao);
            }

            return publicacoes;
        }

        public void EditarPublicacao( Publicacao p)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";") [0] == p.Legenda.ToString());

            linhas.Add( Prepare(p));

            RewriteCSV(PATH, linhas);
        }

        public void ExcluirPublicacao(int id)
        {

        }
    }
}