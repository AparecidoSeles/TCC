using System;
using System.IO;
using System.Collections.Generic;
using TCC.Interface;


namespace TCC.Models
{
    public class Usuario : TccBase , IUsuario
    {
        public int IdUsuario { get; set; }
        
        public string Nome { get; set; }
        
        public string Email { get; set; }
        
        public string Senha { get; set; }
        
        public DateTime DataNascimento = new DateTime();
        public const string PATH = "Database/Usuario.csv";
        
        public Usuario()
        {
            CreateFolderAndFile(PATH);
        } 
        
        public string Prepare(Usuario u)
        {
            return $"{u.IdUsuario}; {u.Nome}; {u.Senha}; {u.Email}; {u.DataNascimento}";
        }
        public void Create(Usuario u)
        {
            u.IdUsuario = ProximoCodigo();
            string[] linhas = {Prepare (u) };

            File.AppendAllLines(PATH,linhas);
        }

        public int ProximoCodigo(){

            var usuarios = ReadAll();

            if (usuarios.Count == 0)
            {
                return 1;
            }
            
            var id = usuarios[usuarios.Count - 1].IdUsuario;

            id ++;
             
            return id;
        }

        public void Delet(int Id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == Id.ToString());
        }

        public List<Usuario> ReadAll()
        {
            List<Usuario> Usuarios = new List<Usuario>();

            string[] linhas = File.ReadAllLines(PATH);
            
            foreach (string item in linhas)
            {
                string[] linha = item.Split(";");

                Usuario USuario = new Usuario();

                USuario.IdUsuario       = int.Parse(linha[0]);
                USuario.Nome            = linha[1];
                USuario.Senha           = linha[2];
                USuario.Email           = linha[3];
                USuario.DataNascimento  = DateTime.Parse(linha[4]);

                Usuarios.Add(USuario);
            }
                return Usuarios;            
        }   

        public void Update(Usuario u)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == u.IdUsuario.ToString());

            linhas.Add(Prepare(u));

            RewriteCSV(PATH, linhas);
            
        }
    }
}