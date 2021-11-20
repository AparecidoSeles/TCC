using System.Collections.Generic;
using TCC.Models;

namespace TCC.Interface
{
    public interface IPublicacao
    {
        void Create( Publicacao p);

        List<Publicacao> ReadAll();

        void Update (Publicacao p);
        
        void Delet(int Id);
    }
}