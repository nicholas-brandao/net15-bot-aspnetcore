using SimpleBotCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Repository
{
    public interface IUsuarioRepository
    {
        List<Usuario> Get();
        Usuario Get(string id);
        string Create(Usuario usuario, int contador);
        void Update(string id, Usuario usuarioIn);
        void Remove(Usuario usuarioIn);
        void Remove(string id);
    }
}
