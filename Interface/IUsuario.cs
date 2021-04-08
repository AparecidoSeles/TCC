using System.Collections.Generic;
using TCC.Models;

namespace TCC.Interface
{
    public interface IUsuario
    {
        void Create(Usuario u);
        List<Usuario> ReadAll();
        void Update (Usuario u);
        void Delet(int Id);
    }
}