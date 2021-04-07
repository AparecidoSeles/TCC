using System;
using System.IO;
using System.Collections.Generic;
using TCC.Interface;

namespace TCC.Models
{
    public class Publicacao : TccBase , IPublicacao
    {
        public System.Guid IdPublicacao { get; set; }
        
        public string Imagem { get; set; }

        public string Legenda { get; set; }

        public DateTime Data = new DateTime();
        
        public const string PATH = "Database/Publicacoes.csv";

        public Publicacao(){
            CreateFolderAndFile(PATH);
        }

        public string Prepare( Publicacao p)
        {
            return $"{p.IdPublicacao}; {p.Imagem}; {p.Legenda};{p.Data}";
        }

        public void Create(Publicacao p)
        {
            string [] linhas = {Prepare(p)};

            File.AppendAllLines(PATH, linhas);
        }

        public List<Publicacao> ReadAll()
        {
            {
            List<Publicacao> publicacoes = new List<Publicacao>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
                string[] linha = item.Split(";");

                Publicacao Publicacao   = new Publicacao();
                Publicacao.IdPublicacao = Guid.Parse(linha[0]);
                Publicacao.Imagem       = linha[1];
                Publicacao.Legenda      = linha[2];
                Publicacao.Data         = DateTime.Parse(linha[3]);
                
                publicacoes.Add(Publicacao);
            }

            return publicacoes;
        }

        }

        public void Update(Publicacao p)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";") [0] == p.Legenda.ToString());

            linhas.Add( Prepare(p));

            RewriteCSV(PATH, linhas);
        }

        public void Delet(int IdPublicacao)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == IdPublicacao.ToString());
            
            RewriteCSV(PATH ,linhas);
        }
    }
}